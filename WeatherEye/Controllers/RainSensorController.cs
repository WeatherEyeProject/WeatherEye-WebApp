using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherEye.Interfaces;

namespace WeatherEye.Controllers
{
    [Route("api/controller")]
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
            var rainSensorData = _irainSensor.GetRainSensorsList();
            return Ok(rainSensorData);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRainSensorDataById(int id)
        {
            var rainSensorData = _irainSensor.GetRainSensorById(id);
            return Ok(rainSensorData);
        }

        //Wszystko poniżej było wygerenowane automatycznie

        //// GET: RainSensorController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: RainSensorController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: RainSensorController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RainSensorController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RainSensorController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RainSensorController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RainSensorController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RainSensorController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
