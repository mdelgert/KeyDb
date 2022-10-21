namespace KeyDb;
public class EntryPoint
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EntryPoint> _logger;
    private readonly IKeyService _keyService;
    
    public EntryPoint(IConfiguration configuration, ILogger<EntryPoint> logger, IKeyService keyService)
    {
        _configuration = configuration;
        _logger = logger;
        _keyService = keyService;
    }

    public async void Run(string[] args)
    {
        _logger.LogInformation("Begin:");

        var rootCommand = new RootCommand("KeyDb application.");

        var searchOption = new Option<string>(
            name: "--search",
            description: "Search for product name in the database.");
        
        var folderOption = new Option<string>(
            name: "--folder",
            description: "XML folder path to import.");

        rootCommand.Add(searchOption);

        rootCommand.Add(folderOption);

        rootCommand.SetHandler(async (name, folder) =>
        {
            await _keyService.Run(name, folder);
        }, searchOption, folderOption);

        await rootCommand.InvokeAsync(args);

        _logger.LogInformation("End:");
    }
    
}

//https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial
//https://betterprogramming.pub/providing-help-to-your-console-apps-c686e2d5f6c1
//https://github.com/dotnet/command-line-api
//https://www.nuget.org/packages/System.CommandLine
//https://makolyte.com/csharp-parsing-commands-and-arguments-in-a-console-app/
//https://stackoverflow.com/questions/19528669/adding-help-parameter-to-c-sharp-console-application
//https://dotnetcoretutorials.com/2021/01/16/creating-modern-and-helpful-command-line-utilities-with-system-commandline/
//https://github.com/dotnet/command-line-api/blob/main/docs/Your-first-app-with-System-CommandLine-DragonFruit.md
//https://github.com/mayuki/Cocona#options

//var settings = _configuration.GetRequiredSection("Settings").Get<SettingsModel>();
//foreach (var arg in args)
//{
//    _logger.LogInformation($"arg={arg}");
//}
//XmlHelper.ParseFolder("C:\\Debug");

//await _keyService.Import("C:\\Debug");
//await _keyService.ReadAll();
//await _keyService.SearchName("");
//Console.ReadKey();

// if (args.Length == 0)
// {
//     Console.WriteLine("Invalid args");
//     return;
// }

// var command = args[0];
//
// switch (command)
// {
//     case "-a":
//         await _keyService.ReadAll();
//         break;
//     case "-s":
//         await _keyService.SearchName(args[1]);
//         break;
//     case "-i":
//         await _keyService.Import(args[1]);
//         break;
//     case "-h":
//         break;
//     default:
//         Console.WriteLine("Invalid command");
//         break;
// }