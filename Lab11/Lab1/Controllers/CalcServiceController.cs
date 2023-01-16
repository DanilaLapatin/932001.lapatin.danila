using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class CalcServiceController : Controller
    {
        private readonly CalcService _service;

        public CalcServiceController(CalcService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassUsingModel()
        {
            return View(_service.GetCalcModel());
        }

        public IActionResult PassUsingViewData()
        {
            var model = _service.GetCalcModel();
            ViewData["X"] = model.X;
            ViewData["Y"] = model.Y;
            ViewData["Sum"] = model.Sum;
            ViewData["Dif"] = model.Dif;
            ViewData["Mult"] = model.Mult;
            ViewData["Div"] = model.Div;
            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            var model = _service.GetCalcModel();
            ViewBag.X = model.X;
            ViewBag.Y = model.Y;
            ViewBag.Sum = model.Sum;
            ViewBag.Dif = model.Dif;
            ViewBag.Mult = model.Mult;
            ViewBag.Div = model.Div;
            return View();
        }

        public IActionResult AccessServiceDirectly()
        {
            return View();
        }
    }
}