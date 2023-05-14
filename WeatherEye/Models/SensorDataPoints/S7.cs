namespace WeatherEye.Models
{
    public record S7(DateTime date, double value) : SensorDataPoint(date, value);
}
