using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Domain.Entities.Employees;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InMemory
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> _Employees = TestData.Employees;

        public IEnumerable<Employee> Get() => _Employees;

        public Employee GetById(int id) => _Employees.FirstOrDefault(e => e.Id == id);

        public int Add(Employee Employee)
        {
            if(Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (_Employees.Contains(Employee)) 
                return Employee.Id;

            Employee.Id = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
            _Employees.Add(Employee);
            return Employee.Id;
        }

        public void Edit(Employee Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (_Employees.Contains(Employee))
                return;

            var db_item = GetById(Employee.Id);

            db_item.FirstName = Employee.FirstName;
            db_item.Surname = Employee.Surname;
            db_item.Patronymic = Employee.Patronymic;
            db_item.Age = Employee.Age;
        }

        public bool Delete(int id)
        {
            var db_item = GetById(id);
            if (db_item is null)
                return false;

            return _Employees.Remove(db_item);
        }

        public void SaveChanges() { }
    }
}
