using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterDrinkingLoggerMVC.Models;
using WaterDrinkingLoggerMVC.Service;

namespace WaterDrinkingLoggerMVC.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly WaterLoggingService _waterLoggingService;
    private readonly WaterDbContext _context;
    
    public List<WaterDrinking> waterLoggings { get; set; } = new List<WaterDrinking>();

    public IndexModel(ILogger<IndexModel> logger, WaterLoggingService waterLoggingService,WaterDbContext context)
    {
        _logger = logger;
        _waterLoggingService = waterLoggingService;
        _context = context;
    }

    public void OnGet()
    {
        waterLoggings = _waterLoggingService.GetAllWaterDrinkings().ToList();
    }
}