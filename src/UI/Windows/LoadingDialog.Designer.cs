//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TerminalGuiDesigner {
    using System;
    using Terminal.Gui;
    
    
    public partial class LoadingDialog : Terminal.Gui.Dialog {
        
        private Terminal.Gui.Label lblLoadingFile;
        
        private void InitializeComponent() {
            this.Text = "";
            this.Width = 40;
            this.Height = 5;
            this.X = Pos.Center();
            this.Y = Pos.Center();
            this.TextAlignment = TextAlignment.Left;
            this.Title = "Loading...";
            this.Title = "Loading...";
            this.lblLoadingFile = new Terminal.Gui.Label();
            this.lblLoadingFile.Data = "lblLoadingFile";
            this.lblLoadingFile.Text = "Please wait while your file loads...";
            this.lblLoadingFile.Width = 36;
            this.lblLoadingFile.Height = 1;
            this.lblLoadingFile.X = 1;
            this.lblLoadingFile.Y = 1;
            this.lblLoadingFile.TextAlignment = TextAlignment.Left;
            this.Add(this.lblLoadingFile);
        }
    }
}
