
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.1.0.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace TerminalGuiDesigner.UI.Windows {
    using System;
    using Terminal.Gui;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public partial class SliderOptionEditor : Terminal.Gui.Dialog {
        
        private Terminal.Gui.ColorScheme redOnBlack;
        
        private Terminal.Gui.ColorScheme tgDefault;
        
        private Terminal.Gui.Label label;
        
        private Terminal.Gui.TextField tfLegend;
        
        private Terminal.Gui.Label label2;
        
        private Terminal.Gui.TextField tfLegendAbbr;
        
        private Terminal.Gui.Label lblOneChar;
        
        private Terminal.Gui.Label label3;
        
        private Terminal.Gui.TextField tfData;
        
        private Terminal.Gui.Label lblType;
        
        private Terminal.Gui.Button btnOk;
        
        private Terminal.Gui.Button btnCancel;
        
        private void InitializeComponent() {
            this.btnCancel = new Terminal.Gui.Button();
            this.btnOk = new Terminal.Gui.Button();
            this.lblType = new Terminal.Gui.Label();
            this.tfData = new Terminal.Gui.TextField();
            this.label3 = new Terminal.Gui.Label();
            this.lblOneChar = new Terminal.Gui.Label();
            this.tfLegendAbbr = new Terminal.Gui.TextField();
            this.label2 = new Terminal.Gui.Label();
            this.tfLegend = new Terminal.Gui.TextField();
            this.label = new Terminal.Gui.Label();
            this.redOnBlack = new Terminal.Gui.ColorScheme(
                new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Black),
                new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Yellow),
                new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightRed, Terminal.Gui.Color.Black),
                new Terminal.Gui.Attribute(Terminal.Gui.Color.Gray, Terminal.Gui.Color.Black),
                new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightRed, Terminal.Gui.Color.Yellow)
                );

            this.tgDefault = new Terminal.Gui.ColorScheme(
                new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Blue),
                new Terminal.Gui.Attribute(Terminal.Gui.Color.Black, Terminal.Gui.Color.Gray),
                 new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightCyan, Terminal.Gui.Color.Blue),
                 new Terminal.Gui.Attribute(Terminal.Gui.Color.Yellow, Terminal.Gui.Color.Blue),
                 new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightBlue, Terminal.Gui.Color.Gray)
                );
            this.Width = 50;
            this.Height = 8;
            this.X = Pos.Center();
            this.Y = Pos.Center();
            this.Visible = true;
            this.Modal = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Title = "OptionEditor";
            this.label.Width = 4;
            this.label.Height = 1;
            this.label.X = 6;
            this.label.Y = 0;
            this.label.Visible = true;
            this.label.Data = "label";
            this.label.Text = "Legend:";
            this.label.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.label);
            this.tfLegend.Width = Dim.Fill(0);
            this.tfLegend.Height = 1;
            this.tfLegend.X = 14;
            this.tfLegend.Y = 0;
            this.tfLegend.Visible = true;
            this.tfLegend.Secret = false;
            this.tfLegend.Data = "tfLegend";
            this.tfLegend.Text = "";
            this.tfLegend.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.tfLegend);
            this.label2.Width = 4;
            this.label2.Height = 1;
            this.label2.X = 0;
            this.label2.Y = 1;
            this.label2.Visible = true;
            this.label2.Data = "label2";
            this.label2.Text = "Abbreviation:";
            this.label2.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.label2);
            this.tfLegendAbbr.Width = 1;
            this.tfLegendAbbr.Height = 1;
            this.tfLegendAbbr.X = 14;
            this.tfLegendAbbr.Y = 1;
            this.tfLegendAbbr.Visible = true;
            this.tfLegendAbbr.Secret = false;
            this.tfLegendAbbr.Data = "tfLegendAbbr";
            this.tfLegendAbbr.Text = "";
            this.tfLegendAbbr.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.tfLegendAbbr);
            this.lblOneChar.Width = 10;
            this.lblOneChar.Height = 1;
            this.lblOneChar.X = 0;
            this.lblOneChar.Y = 2;
            this.lblOneChar.Visible = true;
            this.lblOneChar.Data = "lblOneChar";
            this.lblOneChar.Text = "(Single Char)  ";
            this.lblOneChar.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.Add(this.lblOneChar);
            this.label3.Width = 4;
            this.label3.Height = 1;
            this.label3.X = 7;
            this.label3.Y = 3;
            this.label3.Visible = true;
            this.label3.Data = "label3";
            this.label3.Text = "Data:";
            this.label3.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.label3);
            this.tfData.Width = Dim.Fill(0);
            this.tfData.Height = 1;
            this.tfData.X = 14;
            this.tfData.Y = 3;
            this.tfData.Visible = true;
            this.tfData.Secret = false;
            this.tfData.Data = "tfData";
            this.tfData.Text = "";
            this.tfData.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.tfData);
            this.lblType.Width = Dim.Fill(0);
            this.lblType.Height = 1;
            this.lblType.X = 0;
            this.lblType.Y = 4;
            this.lblType.Visible = true;
            this.lblType.Data = "lblType";
            this.lblType.Text = "( Type ) ";
            this.lblType.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.Add(this.lblType);
            this.btnOk.Width = 8;
            this.btnOk.Height = 1;
            this.btnOk.X = 11;
            this.btnOk.Y = 5;
            this.btnOk.Visible = true;
            this.btnOk.Data = "btnOk";
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.btnOk.IsDefault = true;
            this.Add(this.btnOk);
            this.btnCancel.Width = 8;
            this.btnCancel.Height = 1;
            this.btnCancel.X = 23;
            this.btnCancel.Y = 5;
            this.btnCancel.Visible = true;
            this.btnCancel.Data = "btnCancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.btnCancel.IsDefault = false;
            this.Add(this.btnCancel);
        }
    }
}
