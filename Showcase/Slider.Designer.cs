
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v2.0.0.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace Showcase {
    using System;
    using Terminal.Gui;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    
    
    public partial class Slider : Terminal.Gui.Window {
        
        private Terminal.Gui.Label label;
        
        private Terminal.Gui.Slider<int> slider1;
        
        private Terminal.Gui.Label lblStringSlider;
        
        private Terminal.Gui.Slider<string> slider2;
        
        private Terminal.Gui.Label lblStringSliderThin;
        
        private Terminal.Gui.Slider<string> slider3;
        
        private void InitializeComponent() {
            this.slider3 = new Terminal.Gui.Slider<string>();
            this.lblStringSliderThin = new Terminal.Gui.Label();
            this.slider2 = new Terminal.Gui.Slider<string>();
            this.lblStringSlider = new Terminal.Gui.Label();
            this.slider1 = new Terminal.Gui.Slider<int>();
            this.label = new Terminal.Gui.Label();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Visible = true;
            this.Arrangement = (Terminal.Gui.ViewArrangement.Movable | Terminal.Gui.ViewArrangement.Overlapped);
            this.Modal = false;
            this.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Title = "";
            this.label.Width = Dim.Auto();
            this.label.Height = 1;
            this.label.X = 0;
            this.label.Y = 0;
            this.label.Visible = true;
            this.label.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.label.Data = "label";
            this.label.Text = "Int Slider (0 to 1):";
            this.label.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.label);
            this.slider1.Width = 20;
            this.slider1.Height = 2;
            this.slider1.X = 24;
            this.slider1.Y = 0;
            this.slider1.Visible = true;
            this.slider1.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.slider1.Options = new System.Collections.Generic.List<Terminal.Gui.SliderOption<int>>(new Terminal.Gui.SliderOption<int>[] {
                        new Terminal.Gui.SliderOption<int>("0", new System.Text.Rune('0'), 0),
                        new Terminal.Gui.SliderOption<int>("1", new System.Text.Rune('1'), 1)});
            this.slider1.Orientation = Terminal.Gui.Orientation.Horizontal;
            this.slider1.RangeAllowSingle = false;
            this.slider1.AllowEmpty = false;
            this.slider1.MinimumInnerSpacing = 1;
            this.slider1.LegendsOrientation = Terminal.Gui.Orientation.Horizontal;
            this.slider1.ShowLegends = true;
            this.slider1.ShowEndSpacing = false;
            this.slider1.Type = Terminal.Gui.SliderType.Single;
            this.slider1.Data = "slider1";
            this.slider1.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.slider1);
            this.lblStringSlider.Width = Dim.Auto();
            this.lblStringSlider.Height = 1;
            this.lblStringSlider.X = 0;
            this.lblStringSlider.Y = 2;
            this.lblStringSlider.Visible = true;
            this.lblStringSlider.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.lblStringSlider.Data = "lblStringSlider";
            this.lblStringSlider.Text = "String Slider (Wide):";
            this.lblStringSlider.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.lblStringSlider);
            this.slider2.Width = 31;
            this.slider2.Height = 2;
            this.slider2.X = Pos.Right(lblStringSlider) + 2;
            this.slider2.Y = 2;
            this.slider2.Visible = true;
            this.slider2.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.slider2.Options = new System.Collections.Generic.List<Terminal.Gui.SliderOption<string>>(new Terminal.Gui.SliderOption<string>[] {
                        new Terminal.Gui.SliderOption<string>("Fish", new System.Text.Rune('F'), "Fish"),
                        new Terminal.Gui.SliderOption<string>("Cat", new System.Text.Rune('C'), "Cat"),
                        new Terminal.Gui.SliderOption<string>("Ball", new System.Text.Rune('B'), "Ball")});
            this.slider2.Orientation = Terminal.Gui.Orientation.Horizontal;
            this.slider2.RangeAllowSingle = false;
            this.slider2.AllowEmpty = false;
            this.slider2.MinimumInnerSpacing = 1;
            this.slider2.LegendsOrientation = Terminal.Gui.Orientation.Horizontal;
            this.slider2.ShowLegends = true;
            this.slider2.ShowEndSpacing = false;
            this.slider2.Type = Terminal.Gui.SliderType.Single;
            this.slider2.Data = "slider2";
            this.slider2.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.slider2);
            this.lblStringSliderThin.Width = Dim.Auto();
            this.lblStringSliderThin.Height = 1;
            this.lblStringSliderThin.X = 0;
            this.lblStringSliderThin.Y = 4;
            this.lblStringSliderThin.Visible = true;
            this.lblStringSliderThin.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.lblStringSliderThin.Data = "lblStringSliderThin";
            this.lblStringSliderThin.Text = "String Slider (Thin):";
            this.lblStringSliderThin.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.lblStringSliderThin);
            this.slider3.Width = 6;
            this.slider3.Height = 2;
            this.slider3.X = Pos.Right(lblStringSliderThin) + 2;
            this.slider3.Y = 4;
            this.slider3.Visible = true;
            this.slider3.Arrangement = Terminal.Gui.ViewArrangement.Fixed;
            this.slider3.Options = new System.Collections.Generic.List<Terminal.Gui.SliderOption<string>>(new Terminal.Gui.SliderOption<string>[] {
                        new Terminal.Gui.SliderOption<string>("Fish", new System.Text.Rune('F'), "Fish"),
                        new Terminal.Gui.SliderOption<string>("Cat", new System.Text.Rune('C'), "Cat"),
                        new Terminal.Gui.SliderOption<string>("Ball", new System.Text.Rune('B'), "Ball")});
            this.slider3.Orientation = Terminal.Gui.Orientation.Horizontal;
            this.slider3.RangeAllowSingle = false;
            this.slider3.AllowEmpty = false;
            this.slider3.MinimumInnerSpacing = 1;
            this.slider3.LegendsOrientation = Terminal.Gui.Orientation.Horizontal;
            this.slider3.ShowLegends = true;
            this.slider3.ShowEndSpacing = false;
            this.slider3.Type = Terminal.Gui.SliderType.Single;
            this.slider3.Data = "slider3";
            this.slider3.TextAlignment = Terminal.Gui.Alignment.Start;
            this.Add(this.slider3);
        }
    }
}