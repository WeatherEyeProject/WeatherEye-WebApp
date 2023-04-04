using Microsoft.AspNetCore.Mvc;
using WeatherEye.Models;

namespace WeatherEye.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult DustSensorView()
        {
            var dusts = _context.DustSensors.ToList();
            return View(dusts);
        }

        public IActionResult EnvironmentalSensorView()
        {
            var environmental = _context.EnvironmentalSensors.ToList();
            return View(environmental);
        }

        public IActionResult LightSensorView()
        {
            var light = _context.LightSensors.ToList();
            return View(light);
        }

        public IActionResult RainSensorView()
        {
            var rain = _context.RainSensors.ToList();
            return View(rain);
        }

        public IActionResult UVSensorView()
        {
            var uv = _context.UVSensors.ToList();
            return View(uv);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
