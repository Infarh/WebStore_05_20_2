using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration Configuration) : base(Configuration, WebAPI.Employees) { }

        public IEnumerable<Employee> Get() { throw new System.NotImplementedException(); }

        public Employee GetById(int id) { throw new System.NotImplementedException(); }

        public int Add(Employee Employee) { throw new System.NotImplementedException(); }

        public void Edit(Employee Employee) { throw new System.NotImplementedException(); }

        public bool Delete(int id) { throw new System.NotImplementedException(); }

        public void SaveChanges() { throw new System.NotImplementedException(); }
    }
}
