using WaterDrinkingLoggerMVC.Models;

namespace WaterDrinkingLoggerMVC.Service;

public class WaterLoggingService
{
    private readonly IWaterRepository<WaterDrinking> _waterRepository;
    
    public WaterLoggingService(IWaterRepository<WaterDrinking> waterRepository)
    {
        _waterRepository = waterRepository ?? throw new ArgumentNullException(nameof(waterRepository));
    }
    
    public void AddWaterDrinking(WaterDrinking waterDrinking)
    {
        if (waterDrinking == null)
            throw new ArgumentNullException(nameof(waterDrinking));

        _waterRepository.Add(waterDrinking);
    }
    
    public void  UpdateWaterDrinking(int id, WaterDrinking updatedWaterDrinking)
    {
        var existingWaterDrinking = _waterRepository.GetById(id);
        existingWaterDrinking.Amount = updatedWaterDrinking.Amount;
        existingWaterDrinking.Time = updatedWaterDrinking.Time;
        existingWaterDrinking.User = updatedWaterDrinking.User;
        _waterRepository.Update(existingWaterDrinking);
    }
    
    public void DeleteWaterDrinking(int id)
    {
        var waterDrinkingToDelete = _waterRepository.GetById(id);
        _waterRepository.Delete(waterDrinkingToDelete);
    }

    public WaterDrinking GetWaterDrinkingById(int id)
    {
        var waterDrinking = _waterRepository.GetById(id);
        return waterDrinking;
    }
    
    public IEnumerable<WaterDrinking> GetAllWaterDrinkings()
    {
        return _waterRepository.GetAll();
    }
}