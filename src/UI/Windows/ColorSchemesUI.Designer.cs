
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.15.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace TerminalGuiDesigner.UI.Windows; 
using System;
using Terminal.Gui;


public partial class ColorSchemesUI : Terminal.Gui.Window {
    
    private Terminal.Gui.TableView tvColorSchemes;
    private System.Data.DataTable tvColorSchemesTable;

    private void InitializeComponent() {
        this.Width = Dim.Fill(0);
        this.Height = Dim.Fill(0);
        this.X = 0;
        this.Y = 0;
        this.Modal = false;
        this.Text = "";
        this.TextAlignment = Terminal.Gui.TextAlignment.Left;
        this.Title = "Color Schemes (Ctrl+Q to exit)";
        this.tvColorSchemes = new Terminal.Gui.TableView();
        this.tvColorSchemes.Width = Dim.Fill(0);
        this.tvColorSchemes.Height = Dim.Fill(0);
        this.tvColorSchemes.X = 0;
        this.tvColorSchemes.Y = 0;
        this.tvColorSchemes.Data = "tvColorSchemes";
        this.tvColorSchemes.Text = "";
        this.tvColorSchemes.TextAlignment = Terminal.Gui.TextAlignment.Left;
        this.tvColorSchemes.FullRowSelect = false;
        this.tvColorSchemes.Style.AlwaysShowHeaders = false;
        this.tvColorSchemes.Style.ExpandLastColumn = false;
        this.tvColorSchemes.Style.InvertSelectedCellFirstCharacter = true;
        this.tvColorSchemes.Style.ShowHorizontalHeaderOverline = true;
        this.tvColorSchemes.Style.ShowHorizontalHeaderUnderline = true;
        this.tvColorSchemes.Style.ShowVerticalCellLines = true;
        this.tvColorSchemes.Style.ShowVerticalHeaderLines = true;
        tvColorSchemesTable = new System.Data.DataTable();
        System.Data.DataColumn tvColorSchemesTableName;
        tvColorSchemesTableName = new System.Data.DataColumn();
        tvColorSchemesTableName.ColumnName = "Name";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTableName);
        System.Data.DataColumn tvColorSchemesTable2;
        tvColorSchemesTable2 = new System.Data.DataColumn();
        tvColorSchemesTable2.ColumnName = " ";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable2);
        System.Data.DataColumn tvColorSchemesTable3;
        tvColorSchemesTable3 = new System.Data.DataColumn();
        tvColorSchemesTable3.ColumnName = "  ";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable3);
        System.Data.DataColumn tvColorSchemesTable0;
        tvColorSchemesTable0 = new System.Data.DataColumn();
        tvColorSchemesTable0.ColumnName = "0";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable0);
        System.Data.DataColumn tvColorSchemesTable1;
        tvColorSchemesTable1 = new System.Data.DataColumn();
        tvColorSchemesTable1.ColumnName = "1";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable1);
        System.Data.DataColumn tvColorSchemesTable22;
        tvColorSchemesTable22 = new System.Data.DataColumn();
        tvColorSchemesTable22.ColumnName = "2";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable22);
        System.Data.DataColumn tvColorSchemesTable32;
        tvColorSchemesTable32 = new System.Data.DataColumn();
        tvColorSchemesTable32.ColumnName = "3";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable32);
        System.Data.DataColumn tvColorSchemesTable4;
        tvColorSchemesTable4 = new System.Data.DataColumn();
        tvColorSchemesTable4.ColumnName = "4";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable4);
        System.Data.DataColumn tvColorSchemesTable5;
        tvColorSchemesTable5 = new System.Data.DataColumn();
        tvColorSchemesTable5.ColumnName = "5";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable5);
        System.Data.DataColumn tvColorSchemesTable6;
        tvColorSchemesTable6 = new System.Data.DataColumn();
        tvColorSchemesTable6.ColumnName = "6";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable6);
        System.Data.DataColumn tvColorSchemesTable7;
        tvColorSchemesTable7 = new System.Data.DataColumn();
        tvColorSchemesTable7.ColumnName = "7";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable7);
        System.Data.DataColumn tvColorSchemesTable8;
        tvColorSchemesTable8 = new System.Data.DataColumn();
        tvColorSchemesTable8.ColumnName = "8";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable8);
        System.Data.DataColumn tvColorSchemesTable9;
        tvColorSchemesTable9 = new System.Data.DataColumn();
        tvColorSchemesTable9.ColumnName = "9";
        tvColorSchemesTable.Columns.Add(tvColorSchemesTable9);
        this.tvColorSchemes.Table = new DataTableSource(tvColorSchemesTable);
        this.Add(this.tvColorSchemes);
    }
}
