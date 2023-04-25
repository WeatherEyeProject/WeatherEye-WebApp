using WeatherEye.Models;

namespace WeatherEye.Interfaces
{
    public interface IRainSensor
    {
        List<RainSensor> GetRainSensorsList();
        RainSensor GetRainSensorById(int id);
        

    }
}
