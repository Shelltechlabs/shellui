using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class FormFieldTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "form-field",
        DisplayName = "Form Field",
        Description = "Generic field context primitive for the shadcn-style form pattern",
        Category = ComponentCategory.Form,
        FilePath = "FormField.razor",
        IsAvailable = false,
        Dependencies = new List<string>(),
        Tags = new List<string> { "form", "field", "primitive" }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI
@typeparam TValue

<CascadingValue Value=""this"" IsFixed=""true"">
    @ChildContent
</CascadingValue>

@code {
    [Parameter] public string? Name { get; set; }
    [Parameter] public System.Linq.Expressions.Expression<Func<TValue>>? For { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    public string? FieldName
    {
        get
        {
            if (For != null)
            {
                var fi = Microsoft.AspNetCore.Components.Forms.FieldIdentifier.Create(For);
                return fi.FieldName;
            }
            return Name;
        }
    }

    public System.Linq.Expressions.Expression<Func<TValue>>? Expression => For;
}
";
}
