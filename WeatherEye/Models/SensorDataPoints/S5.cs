namespace WeatherEye.Models
{
    public record S5(DateTime date, double value) : SensorDataPoint(date, value);
}
