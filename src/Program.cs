﻿using Terminal.Gui;
using TerminalGuiDesigner.UI;

namespace TerminalGuiDesigner;


public partial class Program
{
    public static void Main(string[] args)
    {
        Application.Init();
        
        var editor = new Editor();
        editor.Run(args.Length > 0 ? args[0] : null);
    }
}
