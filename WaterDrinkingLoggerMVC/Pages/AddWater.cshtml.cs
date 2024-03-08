using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterDrinkingLoggerMVC.Models;
using WaterDrinkingLoggerMVC.Service;

namespace WaterDrinkingLoggerMVC.Pages;

public class AddWater : PageModel
{
    private readonly WaterDbContext _context;
    private readonly WaterLoggingService _waterLoggingService;
    
    [BindProperty]
    public WaterDrinking WaterDrinking { get; set; }
    
    public AddWater(WaterDbContext context,WaterLoggingService waterLoggingService)
    {
        _context = context;
        _waterLoggingService = waterLoggingService;
    }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        WaterDrinking.Time = DateTime.Now;
        _waterLoggingService.AddWaterDrinking(WaterDrinking);

        return RedirectToPage("./Index");
    }
}