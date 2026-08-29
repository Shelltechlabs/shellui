using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class FormMessageTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "form-message",
        DisplayName = "Form Message",
        Description = "Validation-aware error message for a form field",
        Category = ComponentCategory.Form,
        FilePath = "FormMessage.razor",
        IsAvailable = false,
        Dependencies = new List<string>(),
        Tags = new List<string> { "form", "message", "validation" }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI
@using Microsoft.AspNetCore.Components.Forms

@if (!string.IsNullOrEmpty(Message))
{
    <p class=""@Shell.Cn(""text-sm font-medium text-destructive"", Class)"" @attributes=""AdditionalAttributes"">
        @Message
    </p>
}
else if (_validationMessages.Length > 0)
{
    <p class=""@Shell.Cn(""text-sm font-medium text-destructive"", Class)"" @attributes=""AdditionalAttributes"">
        @string.Join("", "", _validationMessages)
    </p>
}

@code {
    [CascadingParameter] private EditContext? EditContext { get; set; }
    [Parameter] public string? Message { get; set; }
    [Parameter] public string? FieldName { get; set; }
    [Parameter] public string? Class { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    private string[] _validationMessages = Array.Empty<string>();

    protected override void OnParametersSet()
    {
        _validationMessages = Array.Empty<string>();
        if (EditContext != null && !string.IsNullOrEmpty(FieldName))
        {
            var field = new FieldIdentifier(EditContext.Model, FieldName);
            _validationMessages = EditContext.GetValidationMessages(field).ToArray();
        }
    }
}
";
}
