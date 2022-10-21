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

        if (args.Length == 0)
        {
            Console.WriteLine("Invalid args");
            return;
        }

        var command = args[0];

        switch (command)
        {
            case "-a":
                await _keyService.ReadAll();
                break;
            case "-s":
                await _keyService.SearchName(args[1]);
                break;
            case "-i":
                await _keyService.Import(args[1]);
                break;

            default:
                Console.WriteLine("Invalid command");
                break;
        }

        _logger.LogInformation("End:");
    }
}

//https://makolyte.com/csharp-parsing-commands-and-arguments-in-a-console-app/

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
