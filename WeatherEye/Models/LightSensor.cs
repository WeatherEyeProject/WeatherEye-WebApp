namespace WeatherEye.Models
{
    public class LightSensor
    {
        public int Id { get; set; }
        public double IlluminanceLux { get; set; }
        public DateTime DateOfReading { get; set; }
    }
}
