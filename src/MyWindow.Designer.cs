//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YourNamespace {
    using System;
    using Terminal.Gui;
    
    
    public partial class MyWindow {
        
        private Terminal.Gui.Label label1;
        
        private Terminal.Gui.Label lbl2;
        
        private void InitializeComponent() {
            this.label1 = new Terminal.Gui.Label();
            this.label1.Text = "Hello World";
            this.label1.Width = Dim.Fill(0);
            this.label1.Height = 1;
            this.label1.X = 14;
            this.label1.Y = 5;
            this.label1.Data = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Design><FieldName>label1</FieldName><Desi" +
                "gnedProperties><Width><Code>Dim.Fill(0)</Code></Width></DesignedProperties></Des" +
                "ign>";
            this.Add(this.label1);
            this.lbl2 = new Terminal.Gui.Label();
            this.lbl2.Text = "Its a small world after all";
            this.lbl2.Width = 27;
            this.lbl2.Height = 1;
            this.lbl2.X = 42;
            this.lbl2.Y = Pos.Bottom(label1) + 1;
            this.lbl2.Data = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Design><FieldName>lbl2</FieldName><Design" +
                "edProperties><Y><Code>Pos.Bottom(label1) + 1</Code></Y></DesignedProperties></De" +
                "sign>";
            this.Add(this.lbl2);
        }
    }
}
