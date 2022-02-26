using System.Collections.Concurrent;
using Terminal.Gui;

namespace TerminalGuiDesigner.Windows;


internal class BigListBox<T>
{
    private readonly string _okText;
    private readonly bool _addSearch;
    private readonly string _prompt;
    private IList<ListViewObject<T>> _collection;

    /// <summary>
    /// If the public constructor was used then this is the fixed list we were initialized with
    /// </summary>
    private IList<T> _publicCollection;

    private bool _addNull;

    public T Selected { get; private set; }

    /// <summary>
    /// Determines what is rendered in the list visually
    /// </summary>
    public Func<T, string> AspectGetter { get; set; }

    /// <summary>
    /// Ongoing filtering of a large collection should be cancelled when the user changes the filter even if it is not completed yet
    /// </summary>
    ConcurrentBag<CancellationTokenSource> _cancelFiltering = new ConcurrentBag<CancellationTokenSource>();
    Task _currentFilterTask;
    object _taskCancellationLock = new object();

    private ListView _listView;
    private bool _changes;
    private TextField mainInput;
    private DateTime _lastKeypress = DateTime.Now;

    /// <summary>
    /// Protected constructor for derived classes that want to do funky filtering and hot swap out lists as search
    /// enters (e.g. to serve a completely different collection on each keystroke)
    /// </summary>
    /// <param name="prompt"></param>
    /// <param name="okText"></param>
    /// <param name="addSearch"></param>
    /// <param name="displayMember"></param>
    protected BigListBox(string prompt, string okText, bool addSearch, Func<T, string> displayMember)
    {
        _okText = okText;
        _addSearch = addSearch;
        _prompt = prompt;

        AspectGetter = displayMember ?? (arg => arg?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Public constructor that uses normal (contains text) search to filter the fixed <paramref name="collection"/>
    /// </summary>
    /// <param name="prompt"></param>
    /// <param name="okText"></param>
    /// <param name="addSearch"></param>
    /// <param name="collection"></param>
    /// <param name="displayMember">What to display in the list box (defaults to <see cref="object.ToString"/></param>
    /// <param name="addNull">Creates a selection option "Null" that returns a null selection</param>
    public BigListBox(string prompt, string okText, bool addSearch, IList<T> collection,
        Func<T, string> displayMember, bool addNull) : this(prompt, okText, addSearch, displayMember)
    {
        if (collection == null)
            throw new ArgumentNullException("collection");

        _publicCollection = collection;
        _addNull = addNull;
    }

    private class ListViewObject<T2> where T2 : T
    {
        private readonly Func<T2, string> _displayFunc;
        public T2 Object { get; }

        public ListViewObject(T2 o, Func<T2, string> displayFunc)
        {
            _displayFunc = displayFunc;
            Object = o;
        }

        public override string ToString()
        {
            return _displayFunc(Object);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ListViewObject<T2> other)
                return Object.Equals(other.Object);

            return false;
        }
    }

    /// <summary>
    /// Runs the dialog as modal blocking and returns true if a selection was made. 
    /// </summary>
    /// <returns>True if selection was made (see <see cref="Selected"/>) or false if user cancelled the dialog</returns>
    public bool ShowDialog()
    {
        bool okClicked = false;

        var win = new Window(_prompt)
        {
            X = 0,
            Y = 0,

            // By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            Modal = true,
        };

        _listView = new ListView(new List<string>(new[] { "Error" }))
        {
            X = 0,
            Y = 0,
            Height = Dim.Fill(2),
            Width = Dim.Fill(2)
        };

        _listView.SetSource((_collection = BuildList(GetInitialSource())).ToList());
        win.Add(_listView);

        var btnOk = new Button(_okText, true)
        {
            Y = Pos.Bottom(_listView),
            Width = 8,
            Height = 1
        };
        btnOk.Clicked += () =>
        {
            if (_listView.SelectedItem >= _collection.Count)
                return;

            okClicked = true;
            Application.RequestStop();
            Selected = _collection[_listView.SelectedItem].Object;
        };

        var btnCancel = new Button("Cancel")
        {
            Y = Pos.Bottom(_listView),
            Width = 10,
            Height = 1
        };
        btnCancel.Clicked += () => Application.RequestStop();

        if (_addSearch)
        {
            var searchLabel = new Label("Search:")
            {
                X = 0,
                Y = Pos.Bottom(_listView),
            };

            win.Add(searchLabel);

            mainInput = new TextField("")
            {
                X = Pos.Right(searchLabel),
                Y = Pos.Bottom(_listView),
                Width = 30,
            };

            btnOk.X = 38;
            btnCancel.X = 48;

            win.Add(mainInput);
            mainInput.SetFocus();

            mainInput.TextChanged += (s) =>
            {
                // Don't update the UI while user is hammering away on the keyboard
                _lastKeypress = DateTime.Now;
                RestartFiltering();
            };
        }
        else
        {
            btnOk.X = Pos.Center() - 5;
            btnCancel.X = Pos.Center() + 5;
        }


        win.Add(btnOk);
        win.Add(btnCancel);

        AddMoreButtonsAfter(win, btnCancel);

        var callback = Application.MainLoop.AddTimeout(TimeSpan.FromMilliseconds(500), Timer);

        Application.Run(win);

        Application.MainLoop.RemoveTimeout(callback);

        return okClicked;
    }



    /// <summary>
    /// Last minute method for adding extra stuff to the window (to the right of <paramref name="btnCancel"/>)
    /// </summary>
    /// <param name="btnCancel"></param>
    protected virtual void AddMoreButtonsAfter(Window win, Button btnCancel)
    {
    }

    bool Timer(MainLoop caller)
    {
        if (_changes && DateTime.Now.Subtract(_lastKeypress) > TimeSpan.FromSeconds(1))
        {
            lock (_taskCancellationLock)
            {
                var oldSelected = _listView.SelectedItem;
                _listView.SetSource(_collection.ToList());

                if (oldSelected < _collection.Count)
                    _listView.SelectedItem = oldSelected;

                _changes = false;
                return true;
            }
        }

        return true;
    }
    protected void RestartFiltering()
    {
        RestartFiltering(mainInput.Text.ToString());
    }

    protected void RestartFiltering(string searchTerm)
    {

        lock (_taskCancellationLock)
        {
            //cancel any previous searches
            foreach (var c in _cancelFiltering)
                c.Cancel();

            _cancelFiltering.Clear();
        }

        var cts = new CancellationTokenSource();
        _cancelFiltering.Add(cts);

        _currentFilterTask = Task.Run(() =>
        {
            var result = BuildList(GetListAfterSearch(searchTerm, cts.Token));

            lock (_taskCancellationLock)
            {
                _collection = result;
                _changes = true;
            }

        });
    }

    private IList<ListViewObject<T>> BuildList(IList<T> listOfT)
    {
        var toReturn = listOfT.Select(o => new ListViewObject<T>(o, AspectGetter)).ToList();

        if (_addNull)
            toReturn.Add(new ListViewObject<T>((T)(object)null, (o) => "Null"));

        return toReturn;
    }

    protected virtual IList<T> GetListAfterSearch(string searchString, CancellationToken token)
    {
        if (_publicCollection == null)
            throw new InvalidOperationException("When using the protected constructor derived classes must override this method ");

        //stop the Contains searching when the user cancels the search
        return _publicCollection.Where(o => !token.IsCancellationRequested &&
            AspectGetter(o).Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    protected virtual IList<T> GetInitialSource()
    {
        if (_publicCollection == null)
            throw new InvalidOperationException("When using the protected constructor derived classes must override this method ");

        return _publicCollection;
    }
}