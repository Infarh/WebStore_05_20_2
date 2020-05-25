using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

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