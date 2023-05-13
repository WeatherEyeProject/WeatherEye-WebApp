namespace WeatherEye.Models
{
    public class DustSensor
    {
        public int Id { get; set; }
        public double? IntensityPm2_5 { get; set; }
        public double? IntensityPm10 { get; set; }
        public DateTime DateOfReading { get; set; }
    }
}
