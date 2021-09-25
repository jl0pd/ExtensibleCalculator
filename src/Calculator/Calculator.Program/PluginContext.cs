namespace Calculator.Program;

using Calculator.Common;
using System.Collections.Immutable;
using System.Reflection;

internal sealed class PluginContext : IDisposable
{
    public ImmutableArray<Type> Addins { get; }
    public string BaseDirectory { get; }


    private readonly PluginAssemblyLoadContext _loadCtx;
    
    public PluginContext(string directoryPath)
    {
        BaseDirectory = directoryPath;

        _loadCtx = new PluginAssemblyLoadContext(directoryPath);

        var dlls = Directory.EnumerateFiles(directoryPath, "*.dll", SearchOption.TopDirectoryOnly);
        Addins = dlls.Select(_loadCtx.LoadFromAssemblyPath).SelectMany(a => a.GetExportedTypes()).Where(t => t.GetCustomAttribute<AddinAttribute>() is { }).ToImmutableArray();
    }

    public void Dispose() => _loadCtx.Unload();
}