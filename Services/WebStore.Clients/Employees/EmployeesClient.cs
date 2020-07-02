using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        private readonly ILogger<EmployeesClient> _Logger;
        public EmployeesClient(IConfiguration Configuration, ILogger<EmployeesClient> Logger) 
            : base(Configuration, WebAPI.Employees) =>
            _Logger = Logger;

        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(_ServiceAddress);

        public Employee GetById(int id) => Get<Employee>($"{_ServiceAddress}/{id}");

        public int Add(Employee Employee)
        {
            try
            {
                _Logger.LogInformation("Запрос к {0} на редактирование сотрудника id: {1}", _ServiceAddress, Employee.Id);
                return Post(_ServiceAddress, Employee).Content.ReadAsAsync<int>().Result;
            }
            catch (Exception error)
            {

                _Logger.LogError("Ошибка при выполнении запроса к {0} на редактирование сотрудника {1}: {2}",
                    _ServiceAddress, Employee.Id, error);

                throw new InvalidOperationException(
                    $"Ошибка при выполнении запроса к {_ServiceAddress} на редактирование сотрудника {Employee.Id}", 
                    error);
            }
        }

        public void Edit(Employee Employee) => Put(_ServiceAddress, Employee);

        public bool Delete(int id) => Delete($"{_ServiceAddress}/{id}").IsSuccessStatusCode;

        public void SaveChanges() { }
    }
}
