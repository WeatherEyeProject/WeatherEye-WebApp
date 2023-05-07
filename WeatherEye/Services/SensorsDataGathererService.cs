using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Services
{
    public class SensorsDataGathererService : ISensorsDataGatherer
    {
        private readonly DataContext _context;

        public SensorsDataGathererService(DataContext context)
        {
            _context = context;
        }

        public async Task AddDataAsync(List<SensorsData> data)
        {
            foreach(var sensorData in data)
            {
                _context.DustSensors.Add(sensorData.dustSensor);
                _context.EnvironmentalSensors.Add(sensorData.environmentalSensor);
                _context.LightSensors.Add(sensorData.lightSensor);
                _context.RainSensors.Add(sensorData.rainSensor);
                _context.UVSensors.Add(sensorData.uvSensor);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddDataAsync(SensorsData data)
        {
            _context.DustSensors.Add(data.dustSensor);
            _context.EnvironmentalSensors.Add(data.environmentalSensor);
            _context.LightSensors.Add(data.lightSensor);
            _context.RainSensors.Add(data.rainSensor);
            _context.UVSensors.Add(data.uvSensor);
            await _context.SaveChangesAsync();
        }
    }
}
