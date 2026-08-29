using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class CommandGroupTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "command-group",
        DisplayName = "Command Group",
        Description = "Grouping wrapper (with optional heading) for the compositional Command pattern",
        Category = ComponentCategory.Overlay,
        FilePath = "CommandGroup.razor",
        IsAvailable = false,
        Dependencies = new List<string>(),
        Tags = new List<string> { "overlay", "command", "group" }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI

<div class=""@Shell.Cn(""overflow-hidden p-1 text-foreground"", Class)"" @attributes=""AdditionalAttributes"">
    @if (!string.IsNullOrEmpty(Heading))
    {
        <div class=""px-2 py-1.5 text-xs font-medium text-muted-foreground"">@Heading</div>
    }
    @ChildContent
</div>

@code {
    [CascadingParameter] private Command? Parent { get; set; }
    [Parameter] public string? Heading { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public string? Class { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}
";
}
