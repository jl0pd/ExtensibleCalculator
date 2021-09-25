namespace Calculator.Program;

using Calculator.Common;
using System.Reflection;

internal static class Program
{
    private static void Main(string[] args)
    {
        var plugins = Directory.EnumerateDirectories(GetExtensionsDirectoryPath()).Select(d => new PluginContext(d)).ToArray();

        var operators = plugins
                            .SelectMany(p => p.Addins.Where(typeof(IOperator).IsAssignableFrom))
                            .Select(Activator.CreateInstance)
                            .Cast<IOperator>(); // It would be better to create factory of these operators with DI containers, but it's too complex

        Console.WriteLine("Available operators: ");

        foreach (var op in operators)
        {
            Console.WriteLine($"{op.Name} {op.Symbol}");
        }
    }

    private static string GetExtensionsDirectoryPath() // maybe load from config, but this app doesn't have it
    {
        string path = Assembly.GetExecutingAssembly().Location;
        return Path.Combine(Path.GetDirectoryName(path)!, "Extensions");
    }
}
