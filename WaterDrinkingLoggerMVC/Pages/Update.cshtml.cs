using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterDrinkingLoggerMVC.Models;
using WaterDrinkingLoggerMVC.Service;


public class UpdateModel : PageModel
{
    private readonly WaterLoggingService _waterLoggingService;

    [BindProperty]
    public WaterDrinking WaterDrinking { get; set; }

    public UpdateModel(WaterLoggingService waterLoggingService)
    {
        _waterLoggingService = waterLoggingService;
    }

    public void OnGet(int id)
    {
        WaterDrinking = _waterLoggingService.GetWaterDrinkingById(id);
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _waterLoggingService.UpdateWaterDrinking(WaterDrinking.Id, WaterDrinking);
        return RedirectToPage("Index");
    }
}