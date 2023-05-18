using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization; 
using WeatherEye.Interfaces;
using WeatherEye.Models;
using System.Text.Json;

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
            var res = await _sensorsDataGatherer.AddDataAsync(sensorsDataList);
            return res ? Ok(sensorsDataList) : BadRequest(sensorsDataList);
        }

        [HttpPost("/test")]
        public async Task<IActionResult> PostSensorData2([FromBody] string data, [FromHeader] string authorization)
        {
            if(!isAuthValid(data, authorization))
            {
                return Unauthorized();
            }
            List<SensorsData> models = JsonSerializer.Deserialize<List<SensorsData>>(data);
            var res = await _sensorsDataGatherer.AddDataAsync(models);
            return res ? Ok(models) : BadRequest();
        }

        private bool isAuthValid(string data, string auth)
        {
            string[] headerVals = auth.Split(':');
            if(headerVals.Length != 2 || headerVals[0] != "HMAC")
            {
                return false;
            }
            return headerVals[1] == calcHmac(data);
        }

        private string calcHmac(string data)
        {
            byte[] secretBytes = readFile("key.txt"); //Encoding.UTF8.GetBytes(secretKey);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using (HMACSHA256 hmac = new HMACSHA256(secretBytes))
            {
                byte[] hmacBytes = hmac.ComputeHash(dataBytes);
                return Convert.ToBase64String(hmacBytes);
            }
        }

        private byte[] readFile(string path)
        {
            byte[] res = null;
            using(StreamReader sr =  new StreamReader(path)) 
            {
                var strBytes = sr.ReadToEnd();
                var splits = strBytes.Split(',');
                res = splits.Select(s => Convert.ToByte(s, 16)).ToArray();
            }
            return res;
        }
    }
}
