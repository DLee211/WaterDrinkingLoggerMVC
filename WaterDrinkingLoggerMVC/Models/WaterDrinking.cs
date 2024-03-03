namespace WaterDrinkingLoggerMVC.Models;

public class WaterDrinking
{
    public int Id { get; set; }
    public double Amount { get; set; } //liters
    public DateTime Time { get; set; }
    public string User  { get; set; }
}