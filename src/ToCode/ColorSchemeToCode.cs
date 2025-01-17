using System.CodeDom;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

namespace TerminalGuiDesigner.ToCode;

/// <summary>
/// Handles generating code for a <see cref="NamedColorScheme"/> into .Designer.cs
/// file (See <see cref="CodeDomArgs"/>).  This will be a private field within the
/// class generated e.g.:
/// <code>private Terminal.Gui.ColorScheme dialogBackground;</code>
/// </summary>
public class ColorSchemeToCode : ToCodeBase
{
    private NamedColorScheme scheme;

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorSchemeToCode"/> class.
    /// </summary>
    /// <param name="scheme">The <see cref="ColorScheme"/> tracked by
    /// <see cref="ColorSchemeManager"/> that is to be added to .Designer.cs.</param>
    public ColorSchemeToCode(NamedColorScheme scheme)
    {
        this.scheme = scheme;
    }

    /// <summary>
    /// Generates CodeDOM statements to declare private <see cref="ColorScheme"/> field,
    /// constructor call and property initializations for the <see cref="NamedColorScheme"/>.
    /// </summary>
    /// <param name="args">State object for the .Designer.cs file being generated.</param>
    public void ToCode(CodeDomArgs args)
    {
        this.AddFieldToClass(args, typeof(ColorScheme), this.scheme.Name);

        this.AddConstructorCall(args, $"this.{this.scheme.Name}", typeof(ColorScheme),
            GetColorCode(this.scheme.Scheme.Normal),
            GetColorCode(this.scheme.Scheme.Focus),
            GetColorCode(this.scheme.Scheme.HotNormal),
            GetColorCode(this.scheme.Scheme.Disabled),
            GetColorCode(this.scheme.Scheme.HotFocus));
    }

    private CodeObjectCreateExpression GetColorCode(Attribute attr)
    {
        return new CodeObjectCreateExpression(
            typeof(Attribute),
            new CodePrimitiveExpression(attr.Foreground.Argb),
            new CodePrimitiveExpression(attr.Background.Argb));
    }

    private void AddColorSchemeField(CodeDomArgs args, Attribute color, string colorSchemeSubfield)
    {
        this.AddPropertyAssignment(
            args,
            $"this.{this.scheme.Name}.{colorSchemeSubfield}",
            new CodeObjectCreateExpression(
                new CodeTypeReference(typeof(Attribute)),
                this.GetEnumExpression(color.Foreground),
                this.GetEnumExpression(color.Background)));
    }

    private CodeExpression GetEnumExpression(Color color)
    {
        return new CodeFieldReferenceExpression(
            new CodeTypeReferenceExpression(typeof(Color)),
            color.ToString());
    }
}