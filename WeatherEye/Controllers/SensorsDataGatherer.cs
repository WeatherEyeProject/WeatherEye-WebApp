using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization; 
using WeatherEye.Interfaces;
using WeatherEye.Models;
using System.Text.Json;
using Microsoft.Extensions.Primitives;
using System.Reflection.Metadata.Ecma335;

namespace WeatherEye.Controllers
{
    [Route("api/SensorsDataGatherer")]
    [ApiController]
    public class SensorsDataGatherer : ControllerBase
    {
        private readonly ISensorsDataGatherer _sensorsDataGatherer;
        private readonly IHMACAuthorization _authorization;

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

        [HttpPost("test")]
        public async Task<IActionResult> PostSensorData2([FromBody] List<SensorsData> sensorsDataList)
        {
            try
            {
                StringValues HMACSignature;
                var hasAuth = Request.Headers.TryGetValue("Authorization", out HMACSignature);
                if (!hasAuth || HMACSignature.FirstOrDefault() is null)
                {
                    return BadRequest("Authorization header not provided!");
                }
                var body = getRequestBody(Request);
                /*if(!isAuthValid(body, HMACSignature.FirstOrDefault()))
                {
                    return Unauthorized();
                }*/

                try
                {
                    if (!_authorization.validateAuth(body, HMACSignature.FirstOrDefault()))
                    {
                        return Unauthorized();
                    }
                }
                catch (Exception ex)
                {
                    return Unauthorized(ex);
                }


                var res = await _sensorsDataGatherer.AddDataAsync(sensorsDataList);
                return res ? Ok(sensorsDataList) : BadRequest();
            }
            catch (Exception e)
            {
                return Unauthorized(e);
            }
            
        }

        private string getRequestBody(HttpRequest request)
        {
            string data;
            using (var stream = new StreamReader(request.BodyReader.AsStream()))
            {
                data = stream.ReadToEnd();
            }
            return data;
        }
    

/*        private bool isAuthValid(string data, StringValues auth)
        {
            var calculated = calcHmac(data);
            return auth.Contains(calculated);
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
                *//*var splits = strBytes.Split(',');
                res = splits.Select(s => Convert.ToByte(s, 16)).ToArray();*//*

                res = strBytes.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(
                        S=>byte.Parse(S.Trim().Replace("0x","")
                        , System.Globalization.NumberStyles.HexNumber)
                        )
                    .ToArray();
            }
            return res;
        }*/
    }
}
