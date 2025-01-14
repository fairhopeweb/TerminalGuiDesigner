
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
    using System.Drawing;
    
    
    public partial class DimEditor : Terminal.Gui.Dialog {
        
        private Terminal.Gui.RadioGroup rgDimType;
        
        private Terminal.Gui.LineView lineview1;
        
        private Terminal.Gui.Label lblValue;
        
        private Terminal.Gui.TextField tbValue;
        
        private Terminal.Gui.Label lblOffset;
        
        private Terminal.Gui.TextField tbOffset;
        
        private Terminal.Gui.Button btnOk;
        
        private Terminal.Gui.Button btnCancel;
        
        private void InitializeComponent() {
            this.btnCancel = new Terminal.Gui.Button();
            this.btnOk = new Terminal.Gui.Button();
            this.tbOffset = new Terminal.Gui.TextField();
            this.lblOffset = new Terminal.Gui.Label();
            this.tbValue = new Terminal.Gui.TextField();
            this.lblValue = new Terminal.Gui.Label();
            this.lineview1 = new Terminal.Gui.LineView();
            this.rgDimType = new Terminal.Gui.RadioGroup();
            this.Width = 40;
            this.Height = 10;
            this.X = Pos.Center();
            this.Y = Pos.Center();
            this.Visible = true;
            this.Arrangement = Terminal.Gui.ViewArrangement.Movable;
            this.Modal = true;
            this.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Title = "";
            this.rgDimType.Width = 11;
            this.rgDimType.Height = 4;
            this.rgDimType.X = 1;
            this.rgDimType.Y = 1;
            this.rgDimType.Visible = true;
            this.rgDimType.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.rgDimType.Data = "rgDimType";
        this.rgDimType.Text = "";
            this.rgDimType.TextAlignment = Terminal.Gui.Alignment.Start;
            this.rgDimType.RadioLabels = new string[] {
                    "Absolute",
                    "Percent",
                    "Fill",
                    "Auto"};
            this.Add(this.rgDimType);
            this.lineview1.Width = 1;
            this.lineview1.Height = 3;
            this.lineview1.X = 12;
            this.lineview1.Y = 1;
            this.lineview1.Visible = true;
            this.lineview1.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.lineview1.Data = "lineview1";
            this.lineview1.TextAlignment = Terminal.Gui.Alignment.Start;
            this.lineview1.LineRune = new System.Text.Rune('│');
            this.lineview1.Orientation = Terminal.Gui.Orientation.Vertical;
            this.Add(this.lineview1);
            this.lblValue.Width = 6;
            this.lblValue.Height = 1;
            this.lblValue.X = 14;
            this.lblValue.Y = 1;
            this.lblValue.Visible = true;
            this.lblValue.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.lblValue.Data = "lblValue";
            this.lblValue.Text = "Value:";
            this.lblValue.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.lblValue);
            this.tbValue.Width = 15;
            this.tbValue.Height = 1;
            this.tbValue.X = Pos.Right(lblValue) + 2;
            this.tbValue.Y = Pos.Top(lblValue);
            this.tbValue.Visible = true;
            this.tbValue.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.tbValue.Secret = false;
            this.tbValue.Data = "tbValue";
            this.tbValue.Text = "";
            this.tbValue.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.tbValue);
            this.lblOffset.Width = 7;
            this.lblOffset.Height = 1;
            this.lblOffset.X = 14;
            this.lblOffset.Y = 3;
            this.lblOffset.Visible = true;
            this.lblOffset.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.lblOffset.Data = "lblOffset";
            this.lblOffset.Text = "Offset:";
            this.lblOffset.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.lblOffset);
            this.tbOffset.Width = 15;
            this.tbOffset.Height = 1;
            this.tbOffset.X = Pos.Right(lblOffset) + 1;
            this.tbOffset.Y = Pos.Top(lblOffset);
            this.tbOffset.Visible = true;
            this.tbOffset.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.tbOffset.Secret = false;
            this.tbOffset.Data = "tbOffset";
            this.tbOffset.Text = "";
            this.tbOffset.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.tbOffset);
            this.btnOk.Width = 8;
            this.btnOk.Height = Dim.Auto();
            this.btnOk.X = 5;
            this.btnOk.Y = 6;
            this.btnOk.Visible = true;
            this.btnOk.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.btnOk.Data = "btnOk";
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlignment = Terminal.Gui.Alignment.Center;
            this.btnOk.IsDefault = true;
            this.Add(this.btnOk);
            this.btnCancel.Width = 10;
            this.btnCancel.Height = Dim.Auto();
            this.btnCancel.X = 16;
            this.btnCancel.Y = 6;
            this.btnCancel.Visible = true;
            this.btnCancel.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.btnCancel.Data = "btnCancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = Terminal.Gui.Alignment.Center;
            this.btnCancel.IsDefault = false;
            this.Add(this.btnCancel);
        }
    }
}
