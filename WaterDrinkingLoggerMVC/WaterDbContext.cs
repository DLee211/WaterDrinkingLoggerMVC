using Microsoft.EntityFrameworkCore;
using WaterDrinkingLoggerMVC.Models;

namespace WaterDrinkingLoggerMVC;

public class WaterDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<WaterDrinking> WaterDrinkings { get; set; }
    
    public WaterDbContext(DbContextOptions<WaterDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = ""; 
        
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = "";
        
        services.AddDbContext<WaterDbContext>(options => options.UseSqlServer(connectionString));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WaterDrinking>().HasData(
            new WaterDrinking { Id = 1, Amount = 500, Time = DateTime.Now , User = "TestUser1" },
            new WaterDrinking { Id = 2, Amount = 300, Time = DateTime.Now.AddHours(-1), User = "TestUser2"},
            new WaterDrinking { Id = 3, Amount = 700, Time = DateTime.Now.AddHours(-2), User = "TestUser3"}
        );
    }
}