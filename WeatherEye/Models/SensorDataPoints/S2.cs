namespace WeatherEye.Models
{
    public record S2(DateTime date, double value) : SensorDataPoint(date, value);
}
