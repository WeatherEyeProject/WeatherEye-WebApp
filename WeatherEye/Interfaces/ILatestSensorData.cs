using WeatherEye.Models;

namespace WeatherEye.Interfaces
{
    public interface ILatestSensorData
    {
        LatestSensorsData GetLatestSensorsData();
    }
}
