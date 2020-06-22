using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.TestApi;

namespace WebStore.Controllers
{
    public class WebApiTestController : Controller
    {
        private readonly IValueService _ValueService;

        public WebApiTestController(IValueService ValueService) => _ValueService = ValueService;

        public IActionResult Index()
        {
            var values = _ValueService.Get();
            return View(values);
        }
    }
}
