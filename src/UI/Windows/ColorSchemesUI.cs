
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.15.0
//      You can make changes to this file and they will not be overwritten when saving.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace TerminalGuiDesigner.UI.Windows; 
using System;
using System.Collections.Generic;
using System.Data;
using Terminal.Gui;
using TerminalGuiDesigner.Operations;
using static Terminal.Gui.TableView;
using Attribute = Terminal.Gui.Attribute;

/// <summary>
/// View that shows all <see cref="ColorScheme"/> tracked by <see cref="ColorSchemeManager"/>.
/// This is all the custom schemes user has created plus any default ones supplied with the designer.
/// </summary>
public partial class ColorSchemesUI {
    const string NameColumn = "Name";
    const string EditColumnName = " ";
    const string DeleteColumnName = "  ";

    private Design design;

    private NamedColorScheme[] _schemes;

    /// <summary>
    /// Creates a new instance of the <see cref="ColorSchemesUI"/> class.
    /// </summary>
    /// <param name="design"></param>
    public ColorSchemesUI(Design design) {
        
        InitializeComponent();

        this.design = design;

        tvColorSchemes.NullSymbol = " ";

        var tbl = tvColorSchemesTable;
        
        foreach(DataColumn col in tbl.Columns)
        {
            col.DataType = typeof(int);
        }

        var sName = tvColorSchemes.Style.GetOrCreateColumnStyle(tbl.Columns[NameColumn].Ordinal);
        sName.RepresentationGetter = GetName;

        var sEdit = tvColorSchemes.Style.GetOrCreateColumnStyle(tbl.Columns[EditColumnName].Ordinal);
        sEdit.RepresentationGetter = GetEditString;
        sEdit.MinWidth = 7;
        
        var sDelete = tvColorSchemes.Style.GetOrCreateColumnStyle(tbl.Columns[DeleteColumnName].Ordinal);
        sDelete.RepresentationGetter = GetDeleteString;
        sDelete.MinWidth = 8;

        SetupSwatchColumn(tbl,tbl.Columns["0"],(s)=>s.Normal.Foreground);
        SetupSwatchColumn(tbl,tbl.Columns["1"],(s)=>s.Normal.Background);
        SetupSwatchColumn(tbl,tbl.Columns["2"],(s)=>s.HotNormal.Foreground);
        SetupSwatchColumn(tbl,tbl.Columns["3"],(s)=>s.HotNormal.Background);

        SetupSwatchColumn(tbl,tbl.Columns["4"],(s)=>s.Focus.Foreground);
        SetupSwatchColumn(tbl,tbl.Columns["5"],(s)=>s.Focus.Background);
        SetupSwatchColumn(tbl,tbl.Columns["6"],(s)=>s.HotFocus.Foreground);
        SetupSwatchColumn(tbl,tbl.Columns["7"],(s)=>s.HotFocus.Background);

        SetupSwatchColumn(tbl,tbl.Columns["8"],(s)=>s.Disabled.Foreground);
        SetupSwatchColumn(tbl,tbl.Columns["9"],(s)=>s.Disabled.Background);

        BuildDataTableRows();

        tvColorSchemes.CellActivated += CellActivated;
        tvColorSchemes.SelectedCellChanged += CellChanged;

        // When entering control for the first time ensure a valid selection
        CellChanged(this,
            new SelectedCellChangedEventArgs(
                tvColorSchemes.Table,
                tvColorSchemes.SelectedColumn,
                tvColorSchemes.SelectedColumn,
                tvColorSchemes.SelectedRow,
                tvColorSchemes.SelectedRow));
    }

    private void CellChanged(object sender, SelectedCellChangedEventArgs e)
    {
        // don't let user select the color swatches
        if(e.NewCol > 2)
            tvColorSchemes.SelectedColumn = 2;

        // if selecting last row in the table
        if(e.NewRow == tvColorSchemes.Table.Rows-1)
        {
            // only let them press the Add button
            tvColorSchemes.SelectedColumn = 2;
        }
    }

    private void SetupSwatchColumn(DataTable tbl, DataColumn col, Func<ColorScheme, Color> func)
    {
        var colStyle = tvColorSchemes.Style.GetOrCreateColumnStyle(col.Ordinal);

        colStyle.RepresentationGetter = (o)=> " ";
        colStyle.ColorGetter = (e)=>(int)e.CellValue == int.MaxValue ? null : ColorToScheme(func(_schemes[(int)e.CellValue].Scheme));
    }

    private ColorScheme ColorToScheme(Color color)
    {
        return new ColorScheme{
            Normal = new Attribute(color,color),
            HotNormal = new Attribute(color,color),
            Focus = new Attribute(color,color),
            HotFocus = new Attribute(color,color),
            Disabled = new Attribute(color,color),
        };
    }

    private void CellActivated(object sender, CellActivatedEventArgs e)
    {
        
        var col = tvColorSchemesTable.Columns[e.Col];
        var val = (int)tvColorSchemesTable.Rows[e.Row][e.Col];

        if(col.ColumnName == EditColumnName && val < _schemes.Length)
        {
            var edit = new ColorSchemeEditor(_schemes[val].Scheme);
            Application.Run(edit);

            if (edit.Cancelled)
                return;
            
            ColorSchemeManager.Instance.AddOrUpdateScheme(_schemes[val].Name, edit.Result, design.GetRootDesign());
            BuildDataTableRows();
        }

        if(col.ColumnName == NameColumn)
        {
            var oldName = GetName(val);
            if(Modals.GetString("Rename Color Scheme","Name",oldName,out var newName) && !string.IsNullOrWhiteSpace(newName))
            {
                ColorSchemeManager.Instance.RenameScheme(oldName,design.GetUniqueFieldName(newName));
                BuildDataTableRows();
            }
        }

        if(col.ColumnName == DeleteColumnName)
        {
            // actually its the [+] button
            if(val == int.MaxValue)
            {
                ColorSchemeManager.Instance.AddOrUpdateScheme(GetNewColorName(),new ColorScheme(), design.GetRootDesign());
                BuildDataTableRows();
                tvColorSchemes.SelectedRow++;
            }
            else
            {
                var cmd = new DeleteColorSchemeOperation(design,_schemes[val]);
                
                if(cmd.IsImpossible)
                    return;

                OperationManager.Instance.Do(cmd);

                BuildDataTableRows();
                tvColorSchemes.SelectedRow--;
            }
        }
    }

    private string GetNewColorName()
    {  
        return design.GetUniqueFieldName("scheme");
    }

    private string GetDeleteString(object arg)
    {
        return (int)arg == int.MaxValue ? "[New]" : "[Delete]";
    }

    private string GetEditString(object arg)
    {
        return (int)arg == int.MaxValue ? "" : "[ Edit ]";
    }

    private string GetName(object arg)
    {
        if(arg is int i && i <_schemes.Length)
        {
            return _schemes[i].Name;
        }
        return "";
    }

    private void BuildDataTableRows()
    {
        var tbl = tvColorSchemesTable;
        tbl.Rows.Clear();

        _schemes = ColorSchemeManager.Instance.Schemes.ToArray();

        for(int i = 0 ; i < _schemes.Length;i++)
        {
            AddRowToTableWithAllCellsHavingValue(i);
        }

        // Add one last blank row to table for the add row button
        AddRowToTableWithAllCellsHavingValue(int.MaxValue);
        tvColorSchemes.Update();
    }

    private void AddRowToTableWithAllCellsHavingValue(int i)
    {            
        var tbl = tvColorSchemesTable;

        var r = tbl.Rows.Add();
        for(int j = 0;j<tbl.Columns.Count;j++)
        {
            r[j] = i;
        }
    }
}
