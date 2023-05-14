namespace WeatherEye.Models
{
    public record S3(DateTime date, double value) : SensorDataPoint(date, value);
}
