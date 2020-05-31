using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _Local;

        public HomeController(IStringLocalizer<HomeController> Local) => _Local = Local;

        public IActionResult Index()
        {
            ViewBag.Title = _Local["Электронный магазин"];
            return View();
        }

        public IActionResult Throw(string id) => throw new ApplicationException(id ?? "Error!");

        public IActionResult Blog() => View();
        
        public IActionResult BlogSingle() => View();
        
        public IActionResult Cart() => View();
        
        public IActionResult CheckOut() => View();
        
        public IActionResult ContactUs() => View();
        
        public IActionResult Login() => View();
        
        public IActionResult ProductDetails() => View();
        
        public IActionResult Shop() => View();
    }
}