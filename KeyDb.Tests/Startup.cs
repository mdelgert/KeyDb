namespace KeyDb.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        ConfigHelper.SetEnvironment("appsettings.json");
        
        services.AddDbContext<DataContext>(options => options.UseSqlServer(
            "Data Source=localhost;Initial Catalog=KeyDb;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;"));
        
        services.AddSingleton<IKeyService, KeyService>();
        
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}
