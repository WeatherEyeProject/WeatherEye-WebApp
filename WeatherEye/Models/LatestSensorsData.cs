namespace WeatherEye.Models
{
    public class LatestSensorsData
    {
        public DustSensor dustSensor { get; set; }
        public EnvironmentalSensor environmentalSensor { get; set; }
        public LightSensor lightSensor { get; set; }
        public RainSensor rainSensor { get; set; }
        public UVSensor uvSensor { get; set; }   
    }
}
