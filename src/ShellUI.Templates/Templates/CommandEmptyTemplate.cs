using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public class CommandEmptyTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "command-empty",
        DisplayName = "Command Empty",
        Description = "Placeholder shown when no items match the current filter",
        Category = ComponentCategory.Overlay,
        FilePath = "CommandEmpty.razor",
        IsAvailable = false,
        Dependencies = new List<string>(),
        Tags = new List<string> { "overlay", "command", "empty" }
    };

    public static string Content => @"@namespace YourProjectNamespace.Components.UI
@implements IDisposable

@if (!string.IsNullOrWhiteSpace(Parent?.Filter))
{
    <div class=""@Shell.Cn(""py-6 text-center text-sm text-muted-foreground"", Class)"" @attributes=""AdditionalAttributes"">
        @ChildContent
    </div>
}

@code {
    [CascadingParameter] private Command? Parent { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public string? Class { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void OnInitialized()
    {
        if (Parent != null) Parent.FilterChanged += OnFilterChanged;
    }

    private void OnFilterChanged() => InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        if (Parent != null) Parent.FilterChanged -= OnFilterChanged;
    }
}
";
}
