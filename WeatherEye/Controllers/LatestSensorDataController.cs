using Microsoft.AspNetCore.Mvc;
using WeatherEye.Interfaces;
using WeatherEye.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherEye.Controllers
{
    [Route("api/LatestSensorsData")]
    [ApiController]
    public class LatestSensorDataController : ControllerBase
    {
        private readonly ILatestSensorData _latestSensorData;
        public LatestSensorDataController(ILatestSensorData latestSensorData)
        {
            _latestSensorData = latestSensorData;
        }

        // GET: api/<LatestSensorDataController>
        [HttpGet("")]
        public IActionResult GetLatestData()
        {
            var latestDataModel = _latestSensorData.GetLatestSensorsData();
            return Ok(latestDataModel);
        }

    }
}
