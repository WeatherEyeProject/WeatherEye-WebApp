using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.Text;
using WeatherEye.Interfaces;
using WeatherEye.Models;

namespace WeatherEye.Services
{
    public class HMACAuthorizadtionService : IHMACAuthorization
    {
        public bool validateAuth(string body, StringValues auth)
        {
            var calculated = calcHmac(body);
            if (calculated != null && auth.Contains(calculated)) 
            { 
                return true;
            }
            return false;
        }
        private string calcHmac(string data)
        {
            byte[] secretBytes;
            try
            {
                secretBytes = readKey(); //Encoding.UTF8.GetBytes(secretKey);
            }
            catch(Exception ex) 
            {
                throw new Exception($"PLIK: {ex.Message}");
            }
            try
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                using (HMACSHA256 hmac = new HMACSHA256(secretBytes))
                {
                    byte[] hmacBytes = hmac.ComputeHash(dataBytes);
                    return Convert.ToBase64String(hmacBytes);
                }
            }
            catch(Exception eee) 
            {
                throw new Exception($"obliczenia: {eee.Message}");
            }
            
        }

        private byte[] readKey()
        {
            byte[] res = null;
            res = Encoding.ASCII.GetBytes("SECRET KEY");
            return res;
        }
    }
}
