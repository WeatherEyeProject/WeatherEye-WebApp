using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Services
{
    public class RainSensorService : IRainSensor
    {
        private readonly DataContext _context;
        public RainSensorService(DataContext context)
        {
            this._context = context;
        }

        public RainSensor GetRainSensorById(int id)
        {
            var rainSensor = _context.RainSensors.Find(id);
            return rainSensor;
        }

        public List<RainSensor> GetRainSensorsList()
        {
            var rainSensor = _context.RainSensors.ToList();
            return rainSensor;
        }
    }
}
