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
        private static readonly List<Employee> __Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Surname = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Age = 50
            },
            new Employee
            {
                Id = 2,
                Surname = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Age = 25
            },
            new Employee
            {
                Id = 3,
                Surname = "Сидоров",
                FirstName = "Сидор",
                Patronymic = "Сидорович",
                Age = 30
            },
        };


        public IActionResult Index()
        {
            //ViewBag.Title = "Hello World";
            ViewData["Title"] = "Hello World!";

            return View(__Employees);
        }

        public IActionResult AnotherAction()
        {
            return Content("Another action result");
        }
    }
}