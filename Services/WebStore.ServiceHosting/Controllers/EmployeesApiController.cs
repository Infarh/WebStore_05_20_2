using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    /// <summary>Управление сотрудниками</summary>
    //[Route("api/[controller]")]
    //[Route("api/employees")]
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        /// <summary>Получить всех сотрудников</summary>
        /// <returns>Перечисление сотрудников магазина</returns>
        [HttpGet]
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        /// <summary>Получить сотрудника по его идентификатору</summary>
        /// <param name="id">Числовой идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        [HttpGet("{id}")]
        public Employee GetById(int id) => _EmployeesData.GetById(id);

        /// <summary>Добавление нового сотрудника</summary>
        /// <param name="Employee">Добавляемый сотрудник</param>
        /// <returns>Идентификатор добавленного сотрудника</returns>
        [HttpPost]
        public int Add([FromBody] Employee Employee)
        {
            var id = _EmployeesData.Add(Employee);
            SaveChanges();
            return id;
        }

        /// <summary>Редактирование данных сотрудника</summary>
        /// <param name="Employee">Редактируемый сотрудник</param>
        [HttpPut]
        public void Edit(Employee Employee)
        {
            _EmployeesData.Edit(Employee);
            SaveChanges();
        }

        /// <summary>Удаление сотрудника по его идентификатору</summary>
        /// <param name="id">Идентификатор удаляемого сотрудника</param>
        /// <returns>Истина, если сотрудник присутствовал и был удалён</returns>
        //[HttpDelete("delete/{id}")] //http://localhost:5001/api/employees/delete/15
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var success = _EmployeesData.Delete(id);
            SaveChanges();
            return success;
        }

        //[HttpGet("Test/{Start}-{Stop}")] //http://localhost:5001/api/employees/Test/2005.05.07-2007.08.09
        //public ActionResult Test(DateTime Start, DateTime Stop) => Ok();

        [NonAction]
        public void SaveChanges() => _EmployeesData.SaveChanges();
    }
}
