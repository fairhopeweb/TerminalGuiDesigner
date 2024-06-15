
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.18.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace TerminalGuiDesigner.UI.Windows; 
using System;
using Terminal.Gui;


public partial class ChoicesDialog : Terminal.Gui.Window {
    
    private Terminal.Gui.ColorScheme dialogBackground;
    
    private Terminal.Gui.ColorScheme buttons;
    
    private Terminal.Gui.Label label1;
    
    private Terminal.Gui.View buttonPanel;
    
    private Terminal.Gui.Button btn1;
    
    private Terminal.Gui.Button btn2;
    
    private Terminal.Gui.Button btn3;
    
    private Terminal.Gui.Button btn4;
    
    private void InitializeComponent() {
        this.btn4 = new Terminal.Gui.Button();
        this.btn3 = new Terminal.Gui.Button();
        this.btn2 = new Terminal.Gui.Button();
        this.btn1 = new Terminal.Gui.Button();
        this.buttonPanel = new Terminal.Gui.View();
        this.label1 = new Terminal.Gui.Label();
        this.dialogBackground = new Terminal.Gui.ColorScheme(
            new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.DarkGray),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.DarkGray),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.DarkGray),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.Black, Terminal.Gui.Color.Black),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.DarkGray)
            );
        this.buttons = new Terminal.Gui.ColorScheme(
            new Terminal.Gui.Attribute(Terminal.Gui.Color.DarkGray, Terminal.Gui.Color.White),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Yellow),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.Black, Terminal.Gui.Color.White),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.Black, Terminal.Gui.Color.Black),
            new Terminal.Gui.Attribute(Terminal.Gui.Color.Black, Terminal.Gui.Color.Yellow)
            );

        this.Width = Dim.Percent(85);
        this.Height = Dim.Percent(85);
        this.X = Pos.Center();
        this.Y = Pos.Center();
        this.ColorScheme = this.dialogBackground;
        this.Modal = true;
        this.Text = "";
        this.Border.BorderStyle = Terminal.Gui.LineStyle.Double;
        this.TextAlignment = Terminal.Gui.Alignment.Start;
        this.Title = "";
        this.label1.Width = Dim.Fill(0);
        this.label1.Height = Dim.Fill(0);
        this.label1.X = 0;
        this.label1.Y = 1;
        this.label1.Data = "label1";
        this.label1.Text = "lblMessage";
        this.label1.TextAlignment = Terminal.Gui.Alignment.Center;
        this.Add(this.label1);
        this.buttonPanel.Width = 50;
        this.buttonPanel.Height = 2;
        this.buttonPanel.X = Pos.Center();
        this.buttonPanel.Y = Pos.AnchorEnd(2);
        this.buttonPanel.Data = "buttonPanel";
        this.buttonPanel.Text = "";
        this.buttonPanel.TextAlignment = Terminal.Gui.Alignment.Start;
        this.Add(this.buttonPanel);
        this.btn1.Width = 10;
        this.btn1.Height = 2;
        this.btn1.X = 0;
        this.btn1.Y = Pos.AnchorEnd(2);
        this.btn1.ColorScheme = this.buttons;
        this.btn1.Data = "btn1";
        this.btn1.Text = "btn1";
        this.btn1.TextAlignment = Terminal.Gui.Alignment.Center;
        this.btn1.IsDefault = true;
        this.buttonPanel.Add(this.btn1);
        this.btn2.Width = 9;
        this.btn2.Height = 2;
        this.btn2.X = Pos.Right(btn1) + 1;
        this.btn2.Y = Pos.AnchorEnd(2);
        this.btn2.ColorScheme = this.buttons;
        this.btn2.Data = "btn2";
        this.btn2.Text = "btn2";
        this.btn2.TextAlignment = Terminal.Gui.Alignment.Center;
        this.btn2.IsDefault = false;
        this.buttonPanel.Add(this.btn2);
        this.btn3.Width = 8;
        this.btn3.Height = 2;
        this.btn3.X = Pos.Right(btn2) + 1;
        this.btn3.Y = Pos.AnchorEnd(2);
        this.btn3.ColorScheme = this.buttons;
        this.btn3.Data = "btn3";
        this.btn3.Text = "btn3";
        this.btn3.TextAlignment = Terminal.Gui.Alignment.Center;
        this.btn3.IsDefault = false;
        this.buttonPanel.Add(this.btn3);
        this.btn4.Width = 8;
        this.btn4.Height = 2;
        this.btn4.X = Pos.Right(btn3) + 1;
        this.btn4.Y = Pos.AnchorEnd(2);
        this.btn4.ColorScheme = this.buttons;
        this.btn4.Data = "btn4";
        this.btn4.Text = "btn4";
        this.btn4.TextAlignment = Terminal.Gui.Alignment.Center;
        this.btn4.IsDefault = false;
        this.buttonPanel.Add(this.btn4);
    }
}
