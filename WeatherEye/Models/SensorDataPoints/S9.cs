namespace WeatherEye.Models
{
    public record S9(DateTime date, double value) : SensorDataPoint(date, value);
}
