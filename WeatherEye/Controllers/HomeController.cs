using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var dusts = _context.DustSensors
                .ToList();
            return View(dusts);
        }

        public ActionResult LineChart() 
        {
            return View();
        }

        public IActionResult EnvironmentalSensorView()
        {
            var environmental = _context.EnvironmentalSensors
                .ToList();
            return View(environmental);
        }

        public IActionResult LightSensorView()
        {
            var light = _context.LightSensors
                .ToList();
            return View(light);
        }

        public IActionResult RainSensorView()
        {
            var rain = _context.RainSensors
                .OrderBy(d => d.DateOfReading.Date)
                .ThenBy(d => d.DateOfReading.TimeOfDay)
                .ToList();
            return View(rain);
        }

        public IActionResult UVSensorView()
        {
            List<UVSensor> uv = _context.UVSensors
                .GroupBy(x => x.DateOfReading.Date)
                .Select(group => new UVSensor
                {
                    DateOfReading = group.Key,
                    IlluminanceUV = group.Average(x => x.IlluminanceUV)
                })
                .ToList();
            return View(uv);
        }

        public IActionResult UVSensorDetails( DateTime date )
        {
            var uv = _context.UVSensors
                .Where(x => x.DateOfReading.Date == date.Date)
                .FirstOrDefault();
            if ( uv == null)
            {
                return NotFound();
            }
            return View(uv);
        }

        public IActionResult Index()
        {
            var temperature = _context.EnvironmentalSensors
                .OrderBy(x => x.Id)
                .LastOrDefault();
            var dust = _context.DustSensors
                .OrderBy (x => x.Id)
                .LastOrDefault();
            var light = _context.LightSensors
                .OrderBy(x => x.Id)
                .LastOrDefault();
            var rain = _context.RainSensors
                .OrderBy(x => x.Id)
                .LastOrDefault();
            ViewBag.Temperature = temperature;
            ViewBag.Dust = dust;
            ViewBag.Light = light;
            ViewBag.Rain = rain;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
