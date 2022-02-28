﻿using System.Reflection;
using Terminal.Gui;

namespace TerminalGuiDesigner.Windows;

internal class EditDialog : Window
{
    private List<PropertyInListView> collection;
    private ListView list;

    public Design Design { get; }

    public EditDialog(Design design)
    {
        Design = design;
        collection =
            Design.GetDesignableProperties().Select(p => new PropertyInListView(p, design)).ToList();

        list = new ListView(collection)
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(2),
            Height = Dim.Fill(2)
        };
        list.KeyPress += List_KeyPress;

        var btnSet = new Button("Set")
        {
            X = 0,
            Y = Pos.Bottom(list),
            IsDefault = true
        };

        btnSet.Clicked += () =>
        {
            SetProperty(false);
        };

        var btnClose = new Button("Close")
        {
            X = Pos.Right(btnSet),
            Y = Pos.Bottom(list)
        };
        btnClose.Clicked += () => Application.RequestStop();

        this.Add(list);
        this.Add(btnSet);
        this.Add(btnClose);
    }

    private void SetProperty(bool setNull)
    {
        if (list.SelectedItem != -1)
        {
            try
            {
                var p = collection[list.SelectedItem];

                    
                if(setNull)
                {
                    // user wants to set this property to null/default
                    Design.SetDesignablePropertyValue(p.PropertyInfo,null);
                }
                else
                {
                    // user wants to give us a new value for this property
                    if(GetNewValue(p, out object? newValue))
                    {
                        Design.SetDesignablePropertyValue(p.PropertyInfo, newValue);
                    }
                    else
                    {
                        // user cancelled editing the value
                        return;
                    }
                }
                    

                p.UpdateValue();

                var oldSelected = list.SelectedItem;
                list.SetSource(collection = collection.ToList());
                list.SelectedItem = oldSelected;
                list.EnsureSelectedItemVisible();

            }
            catch (Exception e)
            {
                ExceptionViewer.ShowException("Failed to set Property", e);
            }
        }
    }

    private bool GetNewValue(PropertyInListView propertyInListView, out object? newValue)
    {
        var dlg = new GetTextDialog(new DialogArgs()
        {
            WindowTitle = propertyInListView.PropertyInfo.Name,
            EntryLabel = "New Value",
        }, Design.GetDesignablePropertyValue(propertyInListView.PropertyInfo) ?? string.Empty);

        if(dlg.ShowDialog())
        {
            newValue = dlg.ResultText;
            return true;
        }

        newValue = null;
        return false;
    }

    private void List_KeyPress(KeyEventEventArgs obj)
    {
        if (obj.KeyEvent.Key == Key.DeleteChar)
        {
            int rly = MessageBox.Query("Clear", "Clear Property Value?", "Yes", "Cancel");
            if (rly == 0)
            {
                obj.Handled = true;
                SetProperty(true);
            }
        }
    }

    /// <summary>
    /// A list view entry with the value of the field and 
    /// </summary>
    private class PropertyInListView
    {
        public PropertyInfo PropertyInfo;
        public string DisplayMember;

        public Design Design;

        public PropertyInListView(PropertyInfo p, Design design)
        {
            PropertyInfo = p;
            Design = design;
            UpdateValue();

        }

        public override string ToString()
        {
            return DisplayMember;
        }

        /// <summary>
        /// Updates the <see cref="DisplayMember"/> to indicate the new value
        /// </summary>
        /// <param name="newValue"></param>
        public void UpdateValue()
        {
            var val = Design.GetDesignablePropertyValue(PropertyInfo) ?? string.Empty;

            // If it is a password property
            if (PropertyInfo.Name.Contains("Password", StringComparison.InvariantCultureIgnoreCase))
            {
                // With a non null value
                if (!string.IsNullOrWhiteSpace(val.ToString()))
                {
                    val = "****";
                }
            }

            DisplayMember = PropertyInfo.Name + ":" + val;
        }
    }
}
