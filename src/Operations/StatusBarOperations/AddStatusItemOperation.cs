﻿using Terminal.Gui;
using TerminalGuiDesigner.Operations.Generics;

namespace TerminalGuiDesigner.Operations.StatusBarOperations
{
    /// <summary>
    /// Operation for adding a new <see cref="StatusItem"/> to a <see cref="StatusBar"/>.
    /// </summary>
    public class AddStatusItemOperation : AddOperation<StatusBar, StatusItem>
    {
        public AddStatusItemOperation(Design design, string? name)
            : base(
                  (d) => d.Items,
                  (d, v) => d.Items = v,
                  (v) => v.Title.ToString() ?? Operation.Unnamed,
                  (d, name) => { return new StatusItem(Key.Null, name, null); },
                  design,
                  name)
        {
        }
    }
}