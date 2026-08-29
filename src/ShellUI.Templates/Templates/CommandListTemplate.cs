using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class CommandListTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "command-list",
        DisplayName = "Command List",
        Description = "Scrollable list subcomponent for the compositional Command pattern",
        Category = ComponentCategory.Overlay,
        FilePath = "CommandList.razor",
        IsAvailable = false,
        Dependencies = new List<string>(),
        Tags = new List<string> { "overlay", "command", "list" }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI

<div class=""@Shell.Cn(""max-h-[300px] overflow-y-auto overflow-x-hidden"", Class)"" @attributes=""AdditionalAttributes"">
    @ChildContent
</div>

@code {
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public string? Class { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}
";
}
