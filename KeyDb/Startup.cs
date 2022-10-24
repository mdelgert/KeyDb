namespace KeyDb;

public static class Startup
{
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

        IConfiguration configuration = builder.Build();

        var settings = configuration.GetRequiredSection("Settings").Get<SettingsModel>();

        services.AddSingleton(configuration);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        services.AddLogging(builder =>
        {
            builder.AddConfiguration(configuration.GetSection("Logging"));
            //builder.AddConsole();
            builder.AddSerilog();
        });

        if (settings.DbConnection != null)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(settings.DbConnection));
        }

        if (settings.SqliteDb != null)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlite(settings.SqliteDb));
        }
        
        services.AddSingleton<IKeyService, KeyService>();
        
        services.AddSingleton<EntryPoint>();
        
        return services;
    }
}

//https://github.com/dotnet/runtime/issues/40978