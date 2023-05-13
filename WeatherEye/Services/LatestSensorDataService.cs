using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Services
{
    public class LatestSensorDataService : ILatestSensorData
    {
        private readonly DataContext _context;
        public LatestSensorDataService(DataContext context)
        {
            _context = context;
        }
        public LatestSensorsData GetLatestSensorsData()
        {
            
            var dust = _context.DustSensors.OrderByDescending(m => m.DateOfReading).FirstOrDefault();
            var env = _context.EnvironmentalSensors.OrderByDescending(m => m.DateOfReading).FirstOrDefault();
            var light = _context.LightSensors.OrderByDescending(m => m.DateOfReading).FirstOrDefault();
            var rain =_context.RainSensors.OrderByDescending(m => m.DateOfReading).FirstOrDefault();
            var uv =  _context.UVSensors.OrderByDescending(m => m.DateOfReading).FirstOrDefault();
            return new LatestSensorsData { dustSensor = dust, environmentalSensor = env, lightSensor = light, rainSensor = rain, uvSensor = uv };
        }
    }
}
