using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Services
{
    public class SensorsDataService : ISensors
    {
        private readonly DataContext _context;
        public SensorsDataService(DataContext context) 
        {
            _context = context;
        }

        public List<SensorDataPoint> getSensorData(Type sensorType)
        {
            List<SensorDataPoint> res = new List<SensorDataPoint>();
            if (sensorType == null) throw new ArgumentNullException();
            if(sensorType ==  typeof(S1))
            {
                getFromS1(res);
            }
            else if(sensorType == typeof(S2))
            {
                getFromS2(res);
            }
            else if (sensorType == typeof(S3))
            {
                getFromS3(res);
            }
            else if (sensorType == typeof(S4))
            {
                getFromS4(res);
            }
            else if (sensorType == typeof(S5))
            {
                getFromS5(res);
            }
            else if (sensorType == typeof(S6))
            {
                getFromS6(res);
            }
            else if (sensorType == typeof(S7))
            {
                getFromS7(res);
            }
            else if (sensorType == typeof(S8))
            {
                getFromS8(res);
            }
            else if (sensorType == typeof(S10))
            {
                getFromS10(res);
            }
            else if (sensorType == typeof(S11))
            {
                getFromS11(res);
            }
            else
            {
                throw new ArgumentException();
            }
            return res;
        }

        public List<SensorDataPoint> getSensorData(Type sensorType, DateTime from, DateTime to)
        {
            List<SensorDataPoint> res = new List<SensorDataPoint>();
            if (sensorType == null) throw new ArgumentNullException();
            if (sensorType == typeof(S1))
            {
                getFromS1(res,from,to);
            }
            else if (sensorType == typeof(S2))
            {
                getFromS2(res, from, to);
            }
            else if (sensorType == typeof(S3))
            {
                getFromS3(res, from, to);
            }
            else if (sensorType == typeof(S4))
            {
                getFromS4(res, from, to);
            }
            else if (sensorType == typeof(S5))
            {
                getFromS5(res, from, to);
            }
            else if (sensorType == typeof(S6))
            {
                getFromS6(res, from, to);
            }
            else if (sensorType == typeof(S7))
            {
                getFromS7(res, from, to);
            }
            else if (sensorType == typeof(S8))
            {
                getFromS8(res, from, to);
            }
            else if (sensorType == typeof(S10))
            {
                getFromS10(res, from, to);
            }
            else if (sensorType == typeof(S11))
            {
                getFromS11(res, from, to);
            }
            else
            {
                throw new ArgumentException();
            }
            return res;
        }

        private void getFromS1(List<SensorDataPoint> dataPoints)
        {
            getFromS1(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS1(List<SensorDataPoint> dataPoints,DateTime start, DateTime end)
        {
            var data = (from m in _context.EnvironmentalSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.Temperature.HasValue
                        select new S1 ( m.DateOfReading, m.Temperature.Value)).ToList();
            foreach ( var dataPoint in data ) 
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS2(List<SensorDataPoint> dataPoints)
        {
            getFromS2(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS2(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.EnvironmentalSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.Dampness.HasValue
                        select new S2(m.DateOfReading, m.Dampness.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS3(List<SensorDataPoint> dataPoints)
        {
            getFromS3(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS3(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.EnvironmentalSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.Pressure.HasValue
                        select new S3(m.DateOfReading, m.Pressure.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS4(List<SensorDataPoint> dataPoints)
        {
            getFromS4(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS4(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.EnvironmentalSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.IAQuality.HasValue
                        select new S4(m.DateOfReading, m.IAQuality.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS5(List<SensorDataPoint> dataPoints)
        {
            getFromS5(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS5(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.LightSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end
                        select new S5(m.DateOfReading, m.IlluminanceLux)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS6(List<SensorDataPoint> dataPoints)
        {
            getFromS6(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS6(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.UVSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end
                        select new S6(m.DateOfReading, m.IlluminanceUV)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS7(List<SensorDataPoint> dataPoints)
        {
            getFromS7(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS7(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.DustSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.IntensityPm10.HasValue
                        select new S7(m.DateOfReading, m.IntensityPm10.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS8(List<SensorDataPoint> dataPoints)
        {
            getFromS8(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS8(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.DustSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.IntensityPm2_5.HasValue
                        select new S8(m.DateOfReading, m.IntensityPm2_5.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS10(List<SensorDataPoint> dataPoints)
        {
            getFromS10(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS10(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.RainSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.Rain.HasValue
                        select new S10(m.DateOfReading, m.Rain.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

        private void getFromS11(List<SensorDataPoint> dataPoints)
        {
            getFromS11(dataPoints, DateTime.MinValue, DateTime.MaxValue);
        }

        private void getFromS11(List<SensorDataPoint> dataPoints, DateTime start, DateTime end)
        {
            var data = (from m in _context.RainSensors
                        where m.DateOfReading >= start && m.DateOfReading <= end && m.IntensityOfRain.HasValue
                        select new S11(m.DateOfReading, m.IntensityOfRain.Value)).ToList();
            foreach (var dataPoint in data)
            {
                dataPoints.Add(dataPoint);
            }
        }

    }
}
