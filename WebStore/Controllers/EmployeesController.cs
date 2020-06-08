using System;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Employees;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("NewRoute/[controller]/123")]
    //[Route("Staff")]
    //[Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        //[Route("List")]
        public IActionResult Index() => View(_EmployeesData.Get());

        //[Route("{id}")]
        //[Authorize]
        public IActionResult EmployeeDetails(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        #region Редактирование

        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new EmployeeViewModel());

            if (Id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            if(Model.Age < 18 || Model.Age > 75)
                ModelState.AddModelError("Age", "Сотрудник не проходит по возрасту");

            if(Model.Name == "123" && Model.Surname == "QWE")
                ModelState.AddModelError(string.Empty, "Странное сочетание имени и фамилии");

            if (!ModelState.IsValid)
                return View(Model);

            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.Name,
                Surname = Model.Surname,
                Patronymic = Model.Patronymic,
                Age = Model.Age
            };

            if (Model.Id == 0)
                _EmployeesData.Add(employee);
            else
                _EmployeesData.Edit(employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Удаление

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
