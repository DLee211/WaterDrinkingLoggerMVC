using Microsoft.EntityFrameworkCore;
using WaterDrinkingLoggerMVC.Models;

namespace WaterDrinkingLoggerMVC;

public class WaterDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<WaterDrinking> WaterDrinkings { get; set; }
}