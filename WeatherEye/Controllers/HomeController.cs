using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeatherEye.Models;

namespace WeatherEye.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        double utc = Convert.ToDouble(DateTime.Now.ToString("HH")) - Convert.ToDouble(DateTime.UtcNow.ToString("HH"));

        
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult DustSensorView()
        {
            var dusts = _context.DustSensors
                .ToList();

            dusts.ForEach(d =>
            {
                d.DateOfReading = d.DateOfReading.AddHours(utc);
            });

            return View(dusts);
        }

        public IActionResult EnvironmentalSensorView()
        {
            var environmental = _context.EnvironmentalSensors
                .ToList();

            environmental.ForEach(e =>
            {
                e.DateOfReading = e.DateOfReading.AddHours(utc);
            });

            return View(environmental);
        }

        public IActionResult LightSensorView()
        {
            var light = _context.LightSensors
                .ToList();

            light.ForEach(l =>
            {
                l.DateOfReading = l.DateOfReading.AddHours(utc);
            });

            return View(light);
        }

        public IActionResult RainSensorView()
        {
            List<RainSensor> rain = _context.RainSensors
                .GroupBy(x => x.DateOfReading.Date)
                .Select(group => new RainSensor
                {
                    DateOfReading = group.Key,
                    Rain = group.Average(x => x.Rain),
                    IntensityOfRain = group.Average(x => x.IntensityOfRain)

                })
                .ToList();

            return View(rain);
        }
        public IActionResult RainSensorDetails( DateTime date)
        {
            var uv = _context.RainSensors
            .Where(x => x.DateOfReading >= date.AddHours(4) && x.DateOfReading <= date.AddDays(+1).AddHours(4))
            .ToList();
            uv.ForEach(u =>
            {
                u.DateOfReading = u.DateOfReading.AddHours(utc);
            });

            ViewData["Date"] = date.Date.ToString("yyyy-MM-dd");
            return View(uv);

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
                .Where(x => x.DateOfReading >= date.AddHours(4) && x.DateOfReading <= date.AddDays(+1).AddHours(4))
                .ToList();
            uv.ForEach(u =>
            {
                u.DateOfReading = u.DateOfReading.AddHours(utc);
            });

            ViewData["Date"] = date.Date.ToString("yyyy-MM-dd");
            return View(uv);
        }

        public IActionResult Index()
        {
            var environmental = _context.EnvironmentalSensors
                .OrderBy(x => x.Id)
                .LastOrDefault();
            var dust = _context.DustSensors
                .OrderBy (x => x.Id)
                .LastOrDefault();
            var uv = _context.UVSensors
                .OrderBy(x => x.Id)
                .LastOrDefault();
            var rain = _context.RainSensors
                .OrderBy(x => x.Id)
                .LastOrDefault();
            ViewBag.Environmental = environmental;
            ViewBag.Dust = dust;
            ViewBag.UV = uv;
            ViewBag.Rain = rain;
            ViewData["Today"] = _context.EnvironmentalSensors
                .Where(x => x.DateOfReading == DateTime.Today)
                .Average(x => x.Temperature);

            ViewData["Today1"] = _context.EnvironmentalSensors
            .Where(x => x.DateOfReading == DateTime.Today.AddDays(-1))
            .Average(x => x.Temperature);

            ViewData["Today2"] = _context.EnvironmentalSensors
            .Where(x => x.DateOfReading == DateTime.Today.AddDays(-2))
            .Average(x => x.Temperature);

            ViewData["Today3"] = _context.EnvironmentalSensors
            .Where(x => x.DateOfReading == DateTime.Today.AddDays(-3))
            .Average(x => x.Temperature);

            ViewData["Today4"] = _context.EnvironmentalSensors
            .Where(x => x.DateOfReading == DateTime.Today.AddDays(-4))
            .Average(x => x.Temperature);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
