namespace WeatherEye.Models
{
    public record S4(DateTime date, double value) : SensorDataPoint(date, value);
}
