//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TerminalGuiDesigner.UI.Windows
{
    using Terminal.Gui;
    using System.Linq;
    using TerminalGuiDesigner;
    using TerminalGuiDesigner.ToCode;
    using TerminalGuiDesigner.UI.Windows;

    public partial class DimEditor : Window {

        public SnippetProperty Result { get; private set; }
        public bool Cancelled { get; private set; }

        public Design Design { get; }
        public Property Property { get; }

        public DimEditor(Design design, Property property) {
            InitializeComponent();
            
            Design = design;
            Property = property;

            X = Pos.Percent(25);
            Y = Pos.Percent(25);
            Width = Dim.Percent(50);
            Height = 10;

            Title = "Dim Designer";
            Border.BorderStyle = BorderStyle.Double;

            btnOk.Clicked += BtnOk_Clicked;
            btnCancel.Clicked += BtnCancel_Clicked;
            Cancelled = true;
            Modal = true;

            ddType.SetSource(Enum.GetValues(typeof(DimType)).Cast<Enum>().ToList());

            ddType.SelectedItemChanged += DdType_SelectedItemChanged;
        }

        private void DdType_SelectedItemChanged(ListViewItemEventArgs obj)
        {
            switch(GetDimType())
            {
                case DimType.Absolute:
                case DimType.Fill:
                    lblOffset.Visible = false;
                    tbOffset.Visible = false;
                    SetNeedsDisplay();
                    break;
                case DimType.Percent:
                    lblOffset.Visible = true;
                    tbOffset.Visible = true;
                    SetNeedsDisplay();
                    break;

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private bool GetValue(out int newPos)
        {
            return int.TryParse(tbValue.Text.ToString(),out newPos);
        }

        private void BtnCancel_Clicked()
        {
            Cancelled = true;
            Application.RequestStop();
        }

        private void BtnOk_Clicked()
        {
            Cancelled = !GetDimDesign(out var result);
            Result = result;
            Application.RequestStop();
        }

        public bool GetDimDesign(out SnippetProperty result)
        {

            // pick what type of Pos they want
            var type = GetDimType();

            if (type == null)
            {
                result = null;
                return false;
            }

            switch (type)
            {
                case DimType.Absolute:
                    return DesignDimAbsolute(out result);
                case DimType.Percent:
                    return DesignDimPercent(out result);
                case DimType.Fill:
                    return DesignDimFill(out result);

                default: throw new ArgumentOutOfRangeException(nameof(type));

            }
        }

        private DimType? GetDimType()
        {
            return ddType.SelectedItem == -1 ? null : (DimType)ddType.Source.ToList()[ddType.SelectedItem];
        }

        private bool DesignDimAbsolute(out SnippetProperty result)
        {

            if (GetValue(out int newDim))
            {
                result = new SnippetProperty(Property, newDim.ToString(), (Dim)newDim);
                return true;
            }

            result = null;
            return false;
        }

        private bool GetOffset(out int offset)
        {
            return int.TryParse(tbOffset.Text.ToString(),out offset);
        }

        private bool DesignDimPercent(out SnippetProperty result)
        {
            if (GetValue(out var newPercent))
            {
                if (GetOffset(out var offset))
                {
                    result = BuildOffsetDim($"Dim.Percent({newPercent})", Dim.Percent(newPercent), offset);
                    return true;
                }
            }

            result = null;
            return false;
        }

        private bool DesignDimFill(out SnippetProperty result)
        {
            if (GetValue(out int margin))
            {
                result = new SnippetProperty(Property,$"Dim.Fill({margin})", Dim.Fill(margin));
                return true;
            }

            result = null;
            return false;
        }
        private SnippetProperty BuildOffsetDim(string code, Dim dim, int offset, params Func<string>[] codeParameters)
        {
            if (offset == 0)
            {
                return new SnippetProperty(Property, code, dim, codeParameters);
            }
            else
            if (offset > 0)
            {
                return new SnippetProperty(Property, $"{code} + {offset}", dim + offset, codeParameters);
            }
            else
            {
                return new SnippetProperty(Property, $"{code} - {-offset}", dim - offset, codeParameters);
            }
        }
    }
}
