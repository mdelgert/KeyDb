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
        await _keyService.Import("C:\\Debug");
        _logger.LogInformation("End:");
    }
}

//var settings = _configuration.GetRequiredSection("Settings").Get<SettingsModel>();
//foreach (var arg in args)
//{
//    _logger.LogInformation($"arg={arg}");
//}
//XmlHelper.ParseFolder("C:\\Debug");