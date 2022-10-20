namespace KeyDb;
public class EntryPoint
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EntryPoint> _logger;

    public EntryPoint(IConfiguration configuration, ILogger<EntryPoint> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async void Run(string[] args)
    {
        _logger.LogInformation("Begin:");
        
        var settings = _configuration.GetRequiredSection("Settings").Get<SettingsModel>();

        //foreach (var arg in args)
        //{
        //    _logger.LogInformation($"arg={arg}");
        //}

        XmlHelper.ParseFolder("C:\\Debug");
        
        _logger.LogInformation("End:");
        
    }
}
