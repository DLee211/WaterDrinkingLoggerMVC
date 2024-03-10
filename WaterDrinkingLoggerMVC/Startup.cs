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
    
    public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapFallbackToPage("/Index");
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddMvc();
        
        services.AddDbContext<WaterDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestDb;Integrated Security=True;"));
        
        services.AddScoped<IWaterRepository<WaterDrinking>, WaterRepository<WaterDrinking>>();
        services.AddScoped<WaterLoggingService>();
        services.AddControllersWithViews();
    }
}