namespace WeatherEye.Models
{
    public record S6(DateTime date, double value) : SensorDataPoint(date, value);
}
