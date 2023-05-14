namespace WeatherEye.Models
{
    public record S11(DateTime date, double value) : SensorDataPoint(date, value);
}
