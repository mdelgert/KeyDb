var services = Startup.ConfigureServices();
var serviceProvider = services.BuildServiceProvider();
serviceProvider.GetService<EntryPoint>()?.Run(args);
