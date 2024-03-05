using Microsoft.EntityFrameworkCore;

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
        services.AddDbContext<WaterDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TESTDB")));
    }
}