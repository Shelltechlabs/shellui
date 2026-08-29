using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class CommandSeparatorTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "command-separator",
        DisplayName = "Command Separator",
        Description = "Horizontal divider between groups in the compositional Command pattern",
        Category = ComponentCategory.Overlay,
        FilePath = "CommandSeparator.razor",
        IsAvailable = false,
        Dependencies = new List<string>(),
        Tags = new List<string> { "overlay", "command", "separator" }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI

<div class=""@Shell.Cn(""-mx-1 h-px bg-border"", Class)"" @attributes=""AdditionalAttributes""></div>

@code {
    [Parameter] public string? Class { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}
";
}
