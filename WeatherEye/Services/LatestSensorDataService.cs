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
            LatestSensorsData res = new LatestSensorsData();
            getEnvData(res);
            getLightData(res);
            getUVData(res);
            getDustData(res);
            getRainData(res);
            return res;
        }

        private void getEnvData(LatestSensorsData data)
        {
            S1 getS1()//TEMP
            {
                var e = _context.EnvironmentalSensors.Where(m => m.Temperature.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S1(e.DateOfReading, e.Temperature.Value);
            }
            S2 getS2()//Humidity
            {
                var e = _context.EnvironmentalSensors.Where(m => m.Dampness.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S2(e.DateOfReading, e.Dampness.Value);
            }
            S3 getS3()//Pressure
            {
                var e = _context.EnvironmentalSensors.Where(m => m.Pressure.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S3(e.DateOfReading, e.Pressure.Value);
            }
            S4 getS4()//IAQ
            {
                var e = _context.EnvironmentalSensors.Where(m => m.IAQuality.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S4(e.DateOfReading, e.IAQuality.Value);
            }
            data.S1 = getS1();
            data.S2 = getS2();
            data.S3 = getS3();
            data.S4 = getS4();
        }

        private void getLightData(LatestSensorsData data)
        {
            var light = _context.LightSensors.OrderByDescending(m=>m.DateOfReading).FirstOrDefault();
            data.S5 = new S5(light.DateOfReading, light.IlluminanceLux);
        }

        private void getUVData(LatestSensorsData data)
        {
            var uv = _context.UVSensors.OrderByDescending(m => m.DateOfReading).FirstOrDefault();
            data.S6 = new S6(uv.DateOfReading, uv.IlluminanceUV);
        }

        private void getDustData(LatestSensorsData data)
        {
            S7 getS7() //PM 10
            {
                var d = _context.DustSensors.Where(m => m.IntensityPm10.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S7(d.DateOfReading, d.IntensityPm10.Value);
            }
            S8 getS8() //PM 2.5
            {
                var d = _context.DustSensors.Where(m => m.IntensityPm2_5.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S8(d.DateOfReading, d.IntensityPm2_5.Value);
            }
            data.S7 = getS7();
            data.S8 = getS8();
        }

        private void getRainData(LatestSensorsData data)
        {
            var rain = _context.RainSensors.Where(m=>m.Rain.HasValue).OrderByDescending(m=>m.DateOfReading).FirstOrDefault();
            data.S10 = new S10(rain.DateOfReading, rain.Rain.Value);
            S11 getS11()//Rain_Intensity
            {
                var r = _context.RainSensors.Where(m => m.IntensityOfRain.HasValue).OrderByDescending(m => m.DateOfReading).FirstOrDefault();
                return new S11(r.DateOfReading, r.IntensityOfRain.Value);
            }
            data.S11 = getS11();
        }
    }
}
