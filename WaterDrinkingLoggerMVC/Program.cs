using WaterDrinkingLoggerMVC;

var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    using (var context = services.GetRequiredService<WaterDbContext>())
    {
        if (context.Database.CanConnect())
        {
            Console.WriteLine("Database connected");
            context.Database.EnsureDeleted();
            Console.WriteLine("Former Database deleted");
        }

        context.Database.EnsureCreated();
        Console.WriteLine("Database created");
    }

    host.Run();
}


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddEnvironmentVariables();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((_, services) =>
            services.AddDbContext<WaterDbContext>());