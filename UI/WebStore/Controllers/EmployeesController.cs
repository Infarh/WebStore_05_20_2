using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Employees;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebStore.Controllers
{
    //[Route("NewRoute/[controller]/123")]
    //[Route("Staff")]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

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

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id, [FromServices] IMapper Mapper)
        {
            if (Id is null) return View(new EmployeeViewModel());

            if (Id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
                return NotFound();

            return View(Mapper.Map<EmployeeViewModel>(employee));
            //return View(employee.ToView());
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeeViewModel Model, [FromServices] IMapper Mapper)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            if(Model.Age < 18 || Model.Age > 75)
                ModelState.AddModelError("Age", "Сотрудник не проходит по возрасту");

            if(Model.Name == "123" && Model.Surname == "QWE")
                ModelState.AddModelError(string.Empty, "Странное сочетание имени и фамилии");

            if (!ModelState.IsValid)
                return View(Model);

            var employee = Mapper.Map<Employee>(Model);
            //var employee = Model.FromView();

            if (Model.Id == 0)
                _EmployeesData.Add(employee);
            else
                _EmployeesData.Edit(employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Удаление

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee.ToView());
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
