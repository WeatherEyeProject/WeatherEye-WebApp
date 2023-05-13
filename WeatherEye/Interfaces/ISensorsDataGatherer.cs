using WeatherEye.Models;

namespace WeatherEye.Interfaces
{
    public interface ISensorsDataGatherer
    {
        Task<bool> AddDataAsync(List<SensorsData> data);
    }
}
