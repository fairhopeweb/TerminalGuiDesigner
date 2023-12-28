using TerminalGuiDesigner.Operations.MenuOperations;

namespace UnitTests;

[TestFixture]
[TestOf(typeof(OperationManager))]
[Category("UI")]
internal class MenuBarTests : Tests
{
    [Test]
    public void RoundTrip_PreserveMenuItems()
    {
        var viewToCode = new ViewToCode();

        var file = new FileInfo($"{nameof(RoundTrip_PreserveMenuItems)}.cs");
        var designOut = viewToCode.GenerateNewView(file, "YourNamespace", typeof(Dialog));

        using MenuBar mbOut = ViewFactory.Create<MenuBar>( );

        Assume.That( mbOut, Is.Not.Null.And.InstanceOf<MenuBar>( ) );

        // 1 visible root menu (e.g. File)
        Assert.That( mbOut.Menus, Has.Exactly( 1 ).InstanceOf<MenuBarItem>( ) );

        // 1 child menu item (e.g. Open)
        Assert.That( mbOut.Menus[ 0 ].Children, Is.Not.Null.And.Not.Empty );
        Assert.That( mbOut.Menus[ 0 ].Children, Has.Exactly(1).InstanceOf<MenuItem>(  ) );

        AddViewOperation? addViewOperation = null;
        Assume.That( ( ) => addViewOperation = new ( mbOut, designOut, "myMenuBar" ), Throws.Nothing );
        Assume.That( addViewOperation, Is.Not.Null.And.InstanceOf<AddViewOperation>( ) );

        bool addViewOperationSucceeded = false;
        Assert.That( ( ) => addViewOperationSucceeded = OperationManager.Instance.Do( addViewOperation ), Throws.Nothing );
        Assert.That( addViewOperationSucceeded );

        Assume.That( ( ) => viewToCode.GenerateDesignerCs( designOut, typeof( Dialog ) ), Throws.Nothing );

        CodeToView? codeToView = null;
        Assert.That( ( ) => codeToView = new( designOut.SourceCode ), Throws.Nothing );
        Assert.That( codeToView, Is.Not.Null.And.InstanceOf<CodeToView>( ) );

        Design? designBackIn = null;
        Assert.That( ( ) => designBackIn = codeToView.CreateInstance( ), Throws.Nothing );
        Assert.That( designBackIn, Is.Not.Null.And.InstanceOf<Design>( ) );

        // 1 visible root menu (e.g. File)
        MenuBar? mbIn = null;
        Assert.That( designBackIn.View, Is.Not.Null.And.InstanceOf<View>( ) );
        IList<View> actualSubviews = designBackIn.View.GetActualSubviews();
        Assert.That( actualSubviews, Has.Exactly( 1 ).InstanceOf<MenuBar>( ) );
        Assert.That( ( ) => mbIn = actualSubviews.OfType<MenuBar>(  ).Single( ), Throws.Nothing );
        Assert.That( mbIn, Is.Not.Null.And.InstanceOf<MenuBar>( ) );

        // 1 child menu item (e.g. Open)
        Assert.That( mbIn.Menus, Is.Not.Null.And.Not.Empty );
        Assert.That( mbIn.Menus, Has.Exactly( 1 ).InstanceOf<MenuBarItem>( ) );
        Assert.That( mbIn.Menus[ 0 ].Children, Has.Exactly( 1 ).InstanceOf<MenuItem>( ) );
        Assert.That( mbIn.Menus[ 0 ].Children[ 0 ].Title, Is.EqualTo( mbOut.Menus[ 0 ].Children[ 0 ].Title ) );
    }

    [Test]
    [TestOf( typeof( AddMenuItemOperation ) )]
    public void RoundTrip_PreserveMenuItems_WithSubmenus( )
    {
        ViewToCode viewToCode = new( );

        FileInfo file = new( $"{nameof( RoundTrip_PreserveMenuItems_WithSubmenus )}.cs" );
        Design designOut = viewToCode.GenerateNewView( file, "YourNamespace", typeof( Dialog ) );

        MenuBar mbOut = ViewFactory.Create<MenuBar>( );
        Assume.That( mbOut, Is.Not.Null.And.InstanceOf<MenuBar>( ) );

        AddViewOperation addViewOperation = new( mbOut, designOut, "myMenuBar" );
        Assume.That( addViewOperation, Is.Not.Null.And.InstanceOf<AddViewOperation>( ) );

        bool addViewOperationSucceeded = false;
        Assert.That( ( ) => addViewOperationSucceeded = OperationManager.Instance.Do( addViewOperation ), Throws.Nothing );
        Assert.That( addViewOperationSucceeded );

        // create some more children in the menu
        AddMenuItemOperation addChildMenuOperation1 = new( mbOut.Menus[ 0 ].Children[ 0 ] );
        AddMenuItemOperation addChildMenuOperation2 = new( mbOut.Menus[ 0 ].Children[ 0 ] );
        AddMenuItemOperation addChildMenuOperation3 = new( mbOut.Menus[ 0 ].Children[ 0 ] );

        Assert.Multiple( ( ) =>
        {
            bool addChildMenuOperation1Succeeded = false;
            bool addChildMenuOperation2Succeeded = false;
            bool addChildMenuOperation3Succeeded = false;
            Assert.That( ( ) => addChildMenuOperation1Succeeded = addChildMenuOperation1.Do( ), Throws.Nothing );
            Assert.That( addChildMenuOperation1Succeeded );
            Assert.That( ( ) => addChildMenuOperation2Succeeded = addChildMenuOperation2.Do( ), Throws.Nothing );
            Assert.That( addChildMenuOperation2Succeeded );
            Assert.That( ( ) => addChildMenuOperation3Succeeded = addChildMenuOperation3.Do( ), Throws.Nothing );
            Assert.That( addChildMenuOperation3Succeeded );
        } );

        // move the last child
        MoveMenuItemRightOperation moveMenuItemOperation = new( mbOut.Menus[ 0 ].Children[ 1 ] );
        Assert.That( ( ) => moveMenuItemOperation.Do( ), Throws.Nothing );

        // 1 visible root menu (e.g. File)
        Assert.That( mbOut.Menus, Has.Exactly( 1 ).InstanceOf<MenuBarItem>( ) );

        // 3 child menu item (original one + 3 we added -1 because we moved it to submenu)
        Assert.That( mbOut.Menus[ 0 ].Children, Has.Exactly( 3 ).InstanceOf<MenuItem>( ) );

        // should be 1 submenu item (the one we moved)
        Assert.That( mbOut.Menus[ 0 ].Children[ 0 ], Is.InstanceOf<MenuBarItem>( ) );
        Assert.That( ( (MenuBarItem)mbOut.Menus[ 0 ].Children[ 0 ] ).Children, Has.Exactly( 1 ).InstanceOf<MenuItem>( ) );

        Assume.That( ( ) => viewToCode.GenerateDesignerCs( designOut, typeof( Dialog ) ), Throws.Nothing );
        Assume.That( designOut, Is.Not.Null.And.InstanceOf<Design>( ) );

        CodeToView? codeToView = null;
        Assume.That( ( ) => codeToView = new( designOut.SourceCode ), Throws.Nothing );
        Assume.That( codeToView, Is.Not.Null.And.InstanceOf<CodeToView>( ) );

        Design? designBackIn = null;

        Assume.That( ( ) => designBackIn = codeToView.CreateInstance( ), Throws.Nothing );
        Assume.That( designBackIn, Is.Not.Null.And.InstanceOf<Design>( ) );

        MenuBar? mbIn = null;
        Assume.That( designBackIn!.View, Is.Not.Null.And.InstanceOf<View>( ) );

        IList<View> actualSubviews = designBackIn.View.GetActualSubviews( );
        Assert.That( actualSubviews, Has.Exactly( 1 ).InstanceOf<MenuBar>( ) );
        Assert.That( ( ) => mbIn = actualSubviews.OfType<MenuBar>( ).Single( ), Throws.Nothing );
        Assert.That( mbIn, Is.Not.Null.And.InstanceOf<MenuBar>( ) );

        // 1 visible root menu (e.g. File)
        Assert.That( mbIn.Menus, Has.Exactly( 1 ).InstanceOf<MenuBarItem>( ) );
        // 3 child menu item (original one + 3 we added -1 because we moved it to submenu)
        Assert.That( mbIn.Menus[ 0 ].Children, Has.Exactly( 3 ).InstanceOf<MenuItem>( ) );
        Assert.That( mbIn.Menus[ 0 ].Children, Has.All.Not.Null );

        // should be 1 submenu item (the one we moved)
        Assert.That( ( (MenuBarItem)mbIn.Menus[ 0 ].Children[ 0 ] ).Children, Has.Exactly( 1 ).InstanceOf<MenuItem>( ) );
        Assert.That(
            ( (MenuBarItem)mbIn.Menus[ 0 ].Children[ 0 ] ).Children[ 0 ].Title,
            Is.EqualTo( ( (MenuBarItem)mbOut.Menus[ 0 ].Children[ 0 ] ).Children[ 0 ].Title ) );
    }

    [Test]
    public void TestMenuOperations()
    {
        var viewToCode = new ViewToCode();

        var file = new FileInfo($"{nameof(this.TestMenuOperations)}.cs");
        var designOut = viewToCode.GenerateNewView(file, "YourNamespace", typeof(Dialog));

        var mbOut = ViewFactory.Create<MenuBar>( );

        MenuTracker.Instance.Register(mbOut);

        // 1 visible root menu (e.g. File)
        ClassicAssert.AreEqual(1, mbOut.Menus.Length);
        // 1 child menu item (e.g. Open)
        ClassicAssert.AreEqual(1, mbOut.Menus[0].Children.Length);

        var orig = mbOut.Menus[0].Children[0];

        OperationManager.Instance.Do(
            new AddMenuItemOperation(mbOut.Menus[0].Children[0]));

        // Now 2 child menu item
        ClassicAssert.AreEqual(2, mbOut.Menus[0].Children.Length);
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[0]); // original is still at top

        OperationManager.Instance.Undo();

        // Now only 1 child menu item
        ClassicAssert.AreEqual(1, mbOut.Menus[0].Children.Length);
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[0]); // original is still at top

        OperationManager.Instance.Redo();

        // Now 2 child menu item
        ClassicAssert.AreEqual(2, mbOut.Menus[0].Children.Length);
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[0]); // original is still at top

        // Now test moving an item around
        var toMove = mbOut.Menus[0].Children[1];

        // Move second menu item up
        var up = new MoveMenuItemOperation(toMove, true);
        ClassicAssert.IsFalse(up.IsImpossible);
        OperationManager.Instance.Do(up);

        // Original one should now be bottom
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[1]);

        // can't move top one up
        ClassicAssert.IsTrue(new MoveMenuItemOperation(toMove, true).IsImpossible);
        // cant move bottom one down
        ClassicAssert.IsTrue(new MoveMenuItemOperation(mbOut.Menus[0].Children[1], false).IsImpossible);

        OperationManager.Instance.Undo();

        // Original one should be back on top
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[0]);

        // test moving the top one down
        var toMove2 = mbOut.Menus[0].Children[1];

        // Move first menu item down
        var down = new MoveMenuItemOperation(toMove2, true);
        ClassicAssert.IsFalse(down.IsImpossible);
        OperationManager.Instance.Do(down);

        // Original one should now be bottom
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[1]);
        ClassicAssert.AreNotSame(orig, mbOut.Menus[0].Children[0]);

        OperationManager.Instance.Undo();

        // should be back to how we started now
        ClassicAssert.AreSame(orig, mbOut.Menus[0].Children[0]);
        ClassicAssert.AreNotSame(orig, mbOut.Menus[0].Children[1]);
    }

    private MenuBar GetMenuBar()
    {
        return this.GetMenuBar(out _);
    }

    private MenuBar GetMenuBar(out Design root)
    {
        root = Get10By10View();

        var bar = ViewFactory.Create<MenuBar>( );
        var addBarCmd = new AddViewOperation(bar, root, "mb");
        ClassicAssert.IsTrue(addBarCmd.Do());

        // Expect ViewFactory to have created a single
        // placeholder menu item
        ClassicAssert.AreEqual(1, bar.Menus.Length);
        ClassicAssert.AreEqual(1, bar.Menus[0].Children.Length);

        return bar;
    }

    /// <summary>
    /// Tests removing the last menu item (i.e. 'Do Something')
    /// under the only remaining menu header (e.g. 'File F9')
    /// should result in a completely empty menu bar and be undoable
    /// </summary>
    [Test]
    public void TestRemoveFinalMenuItemOnBar()
    {
        var bar = this.GetMenuBar();

        var fileMenu = bar.Menus[0];
        var placeholderMenuItem = fileMenu.Children[0];

        var remove = new RemoveMenuItemOperation(placeholderMenuItem);

        // we are able to remove the last one
        ClassicAssert.IsTrue(remove.Do());
        ClassicAssert.IsEmpty(bar.Menus, "menu bar should now be completely empty");

        remove.Undo();

        // should be back to where we started
        ClassicAssert.AreEqual(1, bar.Menus.Length);
        ClassicAssert.AreEqual(1, bar.Menus[0].Children.Length);
        ClassicAssert.AreSame(placeholderMenuItem, bar.Menus[0].Children[0]);
    }

    /// <summary>
    /// Tests that when there is only one menu item
    /// that it cannot be moved into a submenu
    /// </summary>
    [Test]
    public void TestMoveMenuItemRight_CannotMoveLast()
    {
        var bar = this.GetMenuBar();

        var mi = bar.Menus[0].Children[0];
        var cmd = new MoveMenuItemRightOperation(mi);
        ClassicAssert.IsFalse(cmd.Do());
    }

    [Test]
    public void TestMoveMenuItemRight_CannotMoveElementZero()
    {
        var bar = this.GetMenuBar();

        var mi = bar.Menus[0].Children[0];
        mi.Data = "yarg";
        mi.Shortcut = Key.Y.WithCtrl.KeyCode;
        var addAnother = new AddMenuItemOperation(mi);
        ClassicAssert.True(addAnother.Do());

        // should have added below us
        ClassicAssert.AreSame(mi, bar.Menus[0].Children[0]);
        ClassicAssert.AreNotSame(mi, bar.Menus[0].Children[1]);
        ClassicAssert.AreEqual(2, bar.Menus[0].Children.Length);

        // cannot move element 0
        ClassicAssert.IsFalse(new MoveMenuItemRightOperation(
            bar.Menus[0].Children[0])
        .Do());

        var cmd = new MoveMenuItemRightOperation(
                    bar.Menus[0].Children[1]);

        // can move element 1
        ClassicAssert.IsTrue(cmd.Do());

        // We will have changed from a MenuItem to a MenuBarItem
        // so element 0 will not be us.  In Terminal.Gui there is
        // a different class for a menu item and one with submenus
        ClassicAssert.AreNotSame(mi, bar.Menus[0].Children[0]);
        ClassicAssert.AreEqual(mi.Title, bar.Menus[0].Children[0].Title);
        ClassicAssert.AreEqual(mi.Data, bar.Menus[0].Children[0].Data);
        ClassicAssert.AreEqual(1, bar.Menus[0].Children.Length);

        cmd.Undo();

        ClassicAssert.AreEqual(mi.Title, bar.Menus[0].Children[0].Title);
        ClassicAssert.AreEqual(mi.Data, bar.Menus[0].Children[0].Data);
        ClassicAssert.AreEqual(mi.Shortcut, bar.Menus[0].Children[0].Shortcut);
        ClassicAssert.AreNotSame(mi, bar.Menus[0].Children[1]);
    }

    [Test]
    public void TestMoveMenuItemLeft_CannotMoveRootItems()
    {
        var bar = this.GetMenuBar();

        var mi = bar.Menus[0].Children[0];

        // cannot move a root item
        ClassicAssert.IsFalse(new MoveMenuItemLeftOperation(
            bar.Menus[0].Children[0])
        .Do());
    }

    private MenuBar GetMenuBarWithSubmenuItems(out MenuBarItem head2, out MenuItem topChild)
    {
        var bar = this.GetMenuBar();
        // Set up a menu like:

        /*
           File
            Head1
            Head2 -> Child1
            Head3    Child2
        */

        var mi = bar.Menus[0].Children[0];
        mi.Title = "Head1";

        bar.Menus[0].Children = new[]
        {
            bar.Menus[0].Children[0],
            head2 = new MenuBarItem(new[]
            {
                topChild = new MenuItem("Child1", null, () => { })
                {
                    Data = "Child1",
                    Shortcut = Key.J.WithCtrl.KeyCode,
                },
                new MenuItem("Child2", null, () => { })
                {
                    Data = "Child2",
                    Shortcut = Key.F.WithCtrl.KeyCode,
                },
            })
            {
                Title = "Head2",
            },
            new MenuItem("Head3", null, () => { }),
        };

        return bar;
    }

    [Test]
    public void TestMoveMenuItemLeft_MoveTopChild()
    {
        var bar = this.GetMenuBarWithSubmenuItems(out var head2, out var topChild);

        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(2, head2.Children.Length);
        ClassicAssert.AreSame(topChild, head2.Children[0]);

        var cmd = new MoveMenuItemLeftOperation(topChild);
        ClassicAssert.IsTrue(cmd.Do());

        // move the top child left should pull
        // it out of the submenu and onto the root
        ClassicAssert.AreEqual(4, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(1, head2.Children.Length);

        // it should be pulled out underneath its parent
        // and preserve its (Name) and Shortcuts
        ClassicAssert.AreEqual(topChild.Title, bar.Menus[0].Children[2].Title);
        ClassicAssert.AreEqual(topChild.Data, bar.Menus[0].Children[2].Data);
        ClassicAssert.AreEqual(topChild.Shortcut, bar.Menus[0].Children[2].Shortcut);
        ClassicAssert.AreSame(topChild, bar.Menus[0].Children[2]);

        // undoing command should return us to
        // previous state
        cmd.Undo();

        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(2, head2.Children.Length);

        ClassicAssert.AreEqual(topChild.Title, head2.Children[0].Title);
        ClassicAssert.AreEqual(topChild.Data, head2.Children[0].Data);
        ClassicAssert.AreEqual(topChild.Shortcut, head2.Children[0].Shortcut);
        ClassicAssert.AreSame(topChild, head2.Children[0]);
    }

    [Test]
    public void TestDeletingMenuItemFromSubmenu_TopChild()
    {
        var bar = this.GetMenuBarWithSubmenuItems(out var head2, out var topChild);

        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(2, head2.Children.Length);
        ClassicAssert.AreSame(topChild, head2.Children[0]);

        var cmd = new RemoveMenuItemOperation(topChild);
        ClassicAssert.IsTrue(cmd.Do());

        // Delete the top child should leave only 1 in submenu
        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(1, head2.Children.Length);
        ClassicAssert.AreNotSame(topChild, head2.Children[0]);

        cmd.Undo();

        // should come back now
        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(2, head2.Children.Length);
        ClassicAssert.AreSame(topChild, head2.Children[0]);
    }

    [Test]
    public void TestDeletingMenuItemFromSubmenu_AllSubmenuChild()
    {
        var bar = this.GetMenuBarWithSubmenuItems(out var head2, out var topChild);
        var bottomChild = head2.Children[1];

        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(typeof(MenuBarItem), bar.Menus[0].Children[1].GetType());
        ClassicAssert.AreEqual(2, head2.Children.Length);
        ClassicAssert.AreSame(topChild, head2.Children[0]);

        var cmd1 = new RemoveMenuItemOperation(topChild);
        ClassicAssert.IsTrue(cmd1.Do());

        var cmd2 = new RemoveMenuItemOperation(bottomChild);
        ClassicAssert.IsTrue(cmd2.Do());

        // Deleting both children should convert us from
        // a dropdown submenu to just a regular MenuItem
        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(typeof(MenuItem), bar.Menus[0].Children[1].GetType());

        cmd2.Undo();

        // should bring the bottom one back
        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(typeof(MenuBarItem), bar.Menus[0].Children[1].GetType());
        ClassicAssert.AreSame(bottomChild, ((MenuBarItem)bar.Menus[0].Children[1]).Children[0]);

        cmd1.Undo();

        // Both submenu items should now be back
        ClassicAssert.AreEqual(3, bar.Menus[0].Children.Length);
        ClassicAssert.AreEqual(typeof(MenuBarItem), bar.Menus[0].Children[1].GetType());
        ClassicAssert.AreSame(topChild, ((MenuBarItem)bar.Menus[0].Children[1]).Children[0]);
        ClassicAssert.AreSame(bottomChild, ((MenuBarItem)bar.Menus[0].Children[1]).Children[1]);
    }

    [Test]
    public void TestDeletingLastMenuItem_ShouldRemoveWholeBar()
    {
        var bar = this.GetMenuBar(out Design root);

        var mi = bar.Menus[0].Children[0];

        ClassicAssert.Contains(bar, root.View.Subviews.ToArray(),
                "The MenuBar should be on the main view being edited");

        var cmd = new RemoveMenuItemOperation(mi);
        ClassicAssert.IsTrue(cmd.Do());

        ClassicAssert.IsEmpty(bar.Menus, "Expected menu bar header (File) to be removed along with it's last (only) child");

        ClassicAssert.IsFalse(
            root.View.Subviews.Contains(bar),
            "Now that the MenuBar is completely empty it should be automatically removed");

        cmd.Undo();

        ClassicAssert.Contains(bar, root.View.Subviews.ToArray(),
                "Undo should put the MenuBar back on the view again");
    }
}