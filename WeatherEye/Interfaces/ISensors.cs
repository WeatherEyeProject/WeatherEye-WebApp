using WeatherEye.Models;

namespace WeatherEye.Interfaces
{
    public interface ISensors
    {
        List<SensorDataPoint> getSensorData(Type sensorType);
        List<SensorDataPoint> getSensorData(Type sensorType, DateTime from, DateTime to);
    }
}
