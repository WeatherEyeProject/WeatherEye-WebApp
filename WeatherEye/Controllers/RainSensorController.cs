using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherEye.Interfaces;

namespace WeatherEye.Controllers
{
    [Route("api/rainSensor")]
    [ApiController]
    public class RainSensorController : Controller
    {
        private IRainSensor _irainSensor;

        public RainSensorController(IRainSensor irainSensor)
        {
            _irainSensor = irainSensor;
        }

        [HttpGet("")]
        public IActionResult GetRainSensorData()
        {
            var rainSensor = _irainSensor.GetRainSensorsList();
            return Ok(rainSensor);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRainSensorDataById(int id)
        {
            var rainSensorIdData = _irainSensor.GetRainSensorById(id);
            return Ok(rainSensorIdData);
        }

        [HttpGet("{dateOfReading}")]
        public IActionResult GetRainSensorDataByDate(DateTime dateOfReading)
        {
            var rainSensorDate = _irainSensor.GetRainSensorByDate(dateOfReading);
            return Ok(rainSensorDate);
        }


        [HttpGet("{dateOfReadingStart}/{dateOfReadingEnd}")]
        public IActionResult GetRainSensorDataByPeriodDate(DateTime dateOfReadingStart, DateTime dateOfReadingEnd)
        {
            var rainSensorDate = _irainSensor.GetRainSensorByPeriodDate(dateOfReadingStart, dateOfReadingEnd);
            return Ok(rainSensorDate);
        }
    }
}
