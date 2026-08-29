using ShellUI.Core.Models;

namespace ShellUI.Templates.Templates;

public static class CommandModelsTemplate
{
    public static ComponentMetadata Metadata => new()
    {
        Name = "command-models",
        DisplayName = "Command Models",
        Description = "Model class for Command's legacy list-based API",
        Category = ComponentCategory.Overlay,
        FilePath = "Components/Models/CommandModels.cs",
        IsAvailable = false
    };

    public static string Content => @"namespace YourProjectNamespace.Components.Models;

public class CommandItem
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public string? Shortcut { get; set; }
    public Func<Task>? Action { get; set; }
}
";
}
