using WeatherEye.Models;

namespace WeatherEye.Interfaces
{
    public interface ISensorsDataGatherer
    {
        Task AddDataAsync(List<SensorsData> data);
        Task AddDataAsync(SensorsData data);
    }
}
