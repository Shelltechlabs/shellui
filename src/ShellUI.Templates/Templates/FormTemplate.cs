using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class FormTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "form",
        DisplayName = "Form",
        Description = "Form wrapper component with validation support",
        Category = ComponentCategory.Form,
        FilePath = "Form.razor",

        Tags = new List<string> { "form", "validation", "input", "wrapper" },
        Dependencies = new List<string>
        {
            "label", "input", "button",
            "form-field", "form-item", "form-label", "form-control", "form-description", "form-message"
        }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI
@using Microsoft.AspNetCore.Components.Forms

<form @onsubmit=""HandleSubmit""
      @attributes=""AdditionalAttributes""
      class=""@ClassName""
      novalidate>
    @ChildContent
</form>

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback OnValidSubmit { get; set; }

    [Parameter]
    public EventCallback OnInvalidSubmit { get; set; }

    [Parameter]
    public string ClassName { get; set; } = ""space-y-6"";

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    // novalidate on the <form> suppresses the browser's native validation popover
    // (the balloon that overlaps the next field). Consumers wanting real validation
    // should use <EditForm> + DataAnnotationsValidator + FormMessage instead.
    private async Task HandleSubmit()
    {
        if (OnValidSubmit.HasDelegate)
        {
            await OnValidSubmit.InvokeAsync();
        }
    }
}
";
}


