using Microsoft.AspNetCore.Mvc;
using WaterDrinkingLoggerMVC.Service;

namespace WaterDrinkingLoggerMVC.Controller;
[ApiController]
[Route("WaterLogging")]
public class WaterLoggingController(WaterLoggingService waterLoggingService) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var waterLoggings = waterLoggingService.GetAllWaterDrinkings();
        return View(waterLoggings);
    }
}