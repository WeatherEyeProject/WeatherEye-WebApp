namespace WeatherEye.Models
{
    public record S8(DateTime date, double value) : SensorDataPoint(date, value);
}
