using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Controllers
{
    [Route("api/sensors")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ISensors _sensors;
        public SensorsController(ISensors sensors) 
        { 
            _sensors = sensors;
        }

        [HttpGet("S{sensor}")]
        public IActionResult get(int sensor)
        {
            Type type = getType(sensor);
            if (type == null) return BadRequest();
            var sensorData = _sensors.getSensorData(type);
            return Ok(sensorData);
        }

        [HttpGet("S{sensor}/{start}/{end}")]
        public IActionResult get(int sensor, DateTime start, DateTime end) 
        {
            Type type = getType(sensor);
            if(type == null) return BadRequest();
            var sensorData = _sensors.getSensorData(type, start, end.AddDays(1));
            if(start.CompareTo(end) > 0)
            {
                return BadRequest();
            }
            return Ok(sensorData);
        }

        private Type getType(int sensor)
        {
            Type type = null;
            switch (sensor)
            {
                case 1:
                    type = typeof(S1);
                    break;
                case 2:
                    type = typeof(S2);
                    break;
                case 3:
                    type = typeof(S3);
                    break;
                case 4:
                    type = typeof(S4);
                    break;
                case 5:
                    type = typeof(S5);
                    break;
                case 6:
                    type = typeof(S6);
                    break;
                case 7:
                    type = typeof(S7);
                    break;
                case 8:
                    type = typeof(S8);
                    break;
                case 10:
                    type = typeof(S10);
                    break;
                case 11:
                    type = typeof(S11);
                    break;
                default:
                    type = null;
                    break;
            }
            return type;
        }
    }
}
