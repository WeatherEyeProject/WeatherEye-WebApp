using Microsoft.EntityFrameworkCore;
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
            var rainSensorIdData = _context.RainSensors.Find(id);
            return rainSensorIdData;
        }

        public List<RainSensor> GetRainSensorsList()
        {
            var rainSensor = _context.RainSensors.ToList();
            return rainSensor;
        }

        public List<RainSensor> GetRainSensorByDate(DateTime dateOfReading)
        {
            var rainSensorDate = _context.RainSensors.
                Where(d => d.DateOfReading.Date == dateOfReading.Date).
                OrderBy(d => d.DateOfReading.Date).
                ThenBy(d => d.DateOfReading.TimeOfDay).
                ToList();
            return rainSensorDate;
        } 
        public List<RainSensor> GetRainSensorByPeriodDate(DateTime dateOfReadingStart, DateTime dateOfReadingEnd)
        {
            var rainSensorPeriod = _context.RainSensors.
                Where(d => d.DateOfReading.Date >= dateOfReadingStart.Date && d.DateOfReading.Date <= dateOfReadingEnd.Date).
                OrderBy(d => d.DateOfReading.Date).
                ThenBy(d => d.DateOfReading.TimeOfDay).
                ToList();
            return rainSensorPeriod;
        }
    }
}
