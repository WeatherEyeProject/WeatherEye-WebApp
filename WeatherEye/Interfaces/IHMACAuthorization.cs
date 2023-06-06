using Microsoft.Extensions.Primitives;

namespace WeatherEye.Interfaces
{
    public interface IHMACAuthorization
    {
        bool validateAuth(string body, StringValues auth);

    }
}
