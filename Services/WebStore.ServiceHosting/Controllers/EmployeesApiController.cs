using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    //[Route("api/[controller]")]
    //[Route("api/employees")]
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        [HttpGet]
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        [HttpGet("{id}")]
        public Employee GetById(int id) => _EmployeesData.GetById(id);

        [HttpPost]
        public int Add([FromBody] Employee Employee) => _EmployeesData.Add(Employee);

        [HttpPut]
        public void Edit(Employee Employee) => _EmployeesData.Edit(Employee);

        //[HttpDelete("delete/{id}")] //http://localhost:5001/api/employees/delete/15
        [HttpDelete("{id}")]
        public bool Delete(int id) => _EmployeesData.Delete(id);

        //[HttpGet("Test/{Start}-{Stop}")] //http://localhost:5001/api/employees/Test/2005.05.07-2007.08.09
        //public ActionResult Test(DateTime Start, DateTime Stop) => Ok();

        public void SaveChanges() => _EmployeesData.SaveChanges();
    }
}
