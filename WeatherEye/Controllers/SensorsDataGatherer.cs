using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Controllers
{
    [Route("api/SensorsDataGatherer")]
    [ApiController]
    public class SensorsDataGatherer : ControllerBase
    {
        private readonly ISensorsDataGatherer _sensorsDataGatherer;

        public SensorsDataGatherer(ISensorsDataGatherer sensorsDataGatherer)
        {
            _sensorsDataGatherer = sensorsDataGatherer;
        }

        [HttpPost]
        public async Task<IActionResult> PostSensorsData([FromBody] List<SensorsData> sensorsDataList)
        {
            await _sensorsDataGatherer.AddDataAsync(sensorsDataList);
            return Ok(sensorsDataList);
        }
    }
}
