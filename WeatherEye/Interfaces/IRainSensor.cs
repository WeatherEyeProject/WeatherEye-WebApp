using WeatherEye.Models;

namespace WeatherEye.Interfaces
{
    public interface IRainSensor
    {
        List<RainSensor> GetRainSensorsList();
        RainSensor GetRainSensorById(int id);
        List<RainSensor> GetRainSensorByDate(DateTime dateOfReading);
        List<RainSensor> GetRainSensorByPeriodDate(DateTime dateOfReadingStart, DateTime dateOfReadingEnd);
    }
}
