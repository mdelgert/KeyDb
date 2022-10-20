namespace KeyDb.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        //ConfigHelper.SetupValues("local.settings.json");
        //KeyVaultHelper.SetEnvironment();
        //services.AddSingleton<ITest, Test>();
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}
