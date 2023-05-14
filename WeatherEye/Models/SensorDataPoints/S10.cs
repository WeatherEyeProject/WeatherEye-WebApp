namespace WeatherEye.Models
{
    public record S10(DateTime date, double value) : SensorDataPoint(date, value);
}
