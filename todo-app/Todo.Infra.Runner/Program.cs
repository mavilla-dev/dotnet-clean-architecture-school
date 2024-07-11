using System.CommandLine;

namespace Todo.Infra;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Database manipulation tool");
        rootCommand.AddInitCommand();
        return await rootCommand.InvokeAsync(args);
    }

    private static void AddInitCommand(this RootCommand root)
    {
        var initCommand = new Command("init");
        root.AddCommand(initCommand);

        var dbOption = new Option<string>(
            name: "--db", 
            description: "type of database to manipulate", 
            getDefaultValue: () => "postgres")
            .FromAmong("postgres", "mysql", "ms-sql");
        var ormCommand = new Option<string>(
            name: "--orm", 
            description: "type of orm to use", 
            getDefaultValue: () => "dapper")
            .FromAmong("dapper", "ef");

        initCommand.AddOption(dbOption);
        initCommand.AddOption(ormCommand);

        initCommand.SetHandler((db, orm) => {
            Console.WriteLine($"Hello World! --db:{db} --orm:{orm}");
        }, dbOption, ormCommand);
    }
}
