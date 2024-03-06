using Microsoft.EntityFrameworkCore;
using WaterDrinkingLoggerMVC.Models;
using WaterDrinkingLoggerMVC.Service;

namespace WaterDrinkingLoggerMVC;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddMvc();
        
        services.AddDbContext<WaterDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TESTDB")));
        
        services.AddScoped<IWaterRepository<WaterDrinking>, WaterRepository<WaterDrinking>>();
        services.AddScoped<WaterLoggingService>();
        services.AddControllersWithViews();
    }
}