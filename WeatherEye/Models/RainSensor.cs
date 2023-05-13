namespace WeatherEye.Models
{
    public class RainSensor
    {
        public int Id { get; set; }
        public double? Rain { get; set; }
        public double? IntensityOfRain { get; set; }
        public DateTime DateOfReading { get; set; }
    }
}
