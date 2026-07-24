using ShellDocs.Components;
using ShellUI.Docs.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddShellDocs(o =>
{
    o.ContentRoot = Path.Combine(builder.Environment.ContentRootPath, "content");
    o.SiteName = "ShellUI";
    o.SiteTagline = "shadcn-flavoured Blazor components";
    o.GitHubRepo = "shellui-dev/shellui";
    o.LayoutVariant = DocsLayoutVariant.Sidebar;

    o.AddNavLink("Documentation", "/docs/introduction");
    o.AddNavLink("Components", "/docs/components");

    /* Sidebar package selector — one entry per ShellUI monorepo package.
       ShellDocs' PackageSelector hides itself if fewer than 2 packages are
       declared; four is comfortably above that threshold. RootUrl paths are
       matched by longest-prefix against the current URL to resolve which
       package is "active". IconPath is optional — omit to fall through to
       the default box glyph. */
    o.AddPackage("shellui",            "ShellUI",            "The component library.",     "/docs/introduction",     "M3 3h7v7H3z M14 3h7v7h-7z M3 14h7v7H3z M14 14h7v7h-7z");
    o.AddPackage("shellui.components", "ShellUI.Components", "60+ Blazor primitives.",     "/docs/components",       "M12 2 4 6v6c0 5 3.5 9.5 8 10 4.5-.5 8-5 8-10V6z");
    o.AddPackage("shellui.cli",        "ShellUI.CLI",        "Add, list, scaffold.",       "/docs/cli",              "m8 6-6 6 6 6 M16 6l6 6-6 6");
    o.AddPackage("shellui.templates",  "ShellUI.Templates",  "Starter markdown + files.",  "/docs/templates",        "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z M14 2l6 6 M14 2v6h6");

    /* Register every public ShellUI component under its type name so any of
       them can be embedded in markdown via <Button />, <Alert />, etc. — or
       inside a razor:preview fence. Marker type: any concrete ShellUI
       component; Button is a stable anchor. Filter narrows the scan to the
       ShellUI.Components assembly's own components (skips any nested test
       doubles or generic base types). */
    o.RegisterComponentsFromAssembly<ShellUI.Components.Button>(
        t => t.Namespace?.StartsWith("ShellUI.Components") == true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
