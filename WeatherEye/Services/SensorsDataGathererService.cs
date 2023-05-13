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

        public async Task<bool> AddDataAsync(List<SensorsData> data)
        {
            bool added = false;
            foreach(var sensor in data)
            {
                if(sensor.s1.HasValue ||
                    sensor.s2.HasValue ||
                    sensor.s3.HasValue ||
                    sensor.s4.HasValue)
                {
                    _context.EnvironmentalSensors.Add(
                        new EnvironmentalSensor
                        {
                            DateOfReading = sensor.dateTime,
                            Temperature = sensor.s1,
                            Dampness = sensor.s2,
                            Pressure = sensor.s3,
                            IAQuality = sensor.s4
                        });
                    added = true;
                }

                if(sensor.s5.HasValue)
                {
                    _context.LightSensors.Add(
                        new LightSensor
                        {
                            DateOfReading = sensor.dateTime,
                            IlluminanceLux = (double)sensor.s5
                        });
                    added = true;
                }

                if (sensor.s6.HasValue)
                {
                    _context.UVSensors.Add(
                        new UVSensor
                        {
                            DateOfReading = sensor.dateTime,
                            IlluminanceUV = (double)sensor.s6
                        });
                    added = true;
                }

                if(sensor.s7.HasValue ||
                    sensor.s8.HasValue)
                {
                    _context.DustSensors.Add(
                        new DustSensor
                        {
                            DateOfReading = sensor.dateTime,
                            IntensityPm10 = sensor.s7,
                            IntensityPm2_5 = sensor.s8
                        });
                    added = true;
                }

                if(sensor.s10.HasValue ||
                    sensor.s11.HasValue)
                {
                    _context.RainSensors.Add(
                        new RainSensor 
                        { 
                            DateOfReading = sensor.dateTime, 
                            IntensityOfRain = sensor.s11, 
                            Rain = sensor.s10 
                        });
                    added = true;
                }
            }
            var written = await _context.SaveChangesAsync();
            return added && written > 0;
        }
    }
}
