namespace WeatherEye.Models
{
    public record S1(DateTime date, double value) : SensorDataPoint(date, value);
}
