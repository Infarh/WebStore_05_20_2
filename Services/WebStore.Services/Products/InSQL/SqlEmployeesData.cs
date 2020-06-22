using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Products.InSQL
{
    public class SqlEmployeesData : IEmployeesData
    {
        private readonly WebStoreDB _db;

        public SqlEmployeesData(WebStoreDB db) => _db = db;

        public IEnumerable<Employee> Get() => _db.Employees/*.AsEnumerable()*/;

        public Employee GetById(int id) => /*_db.Employees.Find(id);*/ _db.Employees.FirstOrDefault(e => e.Id == id);

        public int Add(Employee Employee)
        {
            if (Employee is null) throw new ArgumentNullException(nameof(Employee));
            if (Employee.Id != 0) throw new InvalidOperationException("Для добавляемого сотрудника вручную задан первичный ключ");

            _db.Employees.Add(Employee /*?? throw new ArgumentNullException(nameof(Employee))*/);

            return Employee.Id;
        }

        public void Edit(Employee Employee)
        {
            if (Employee is null) throw new ArgumentNullException(nameof(Employee));

            //var db_item = GetById(Employee.Id);
            //if(db_item is null) return;

            //db_item.FirstName = Employee.FirstName;
            //db_item.Surname = Employee.Surname;
            //db_item.Patronymic = Employee.Patronymic;
            //db_item.Age = Employee.Age;

            //_db.Attach(Employee);
            //_db.Entry(Employee).State = EntityState.Modified;

            _db.Update(Employee);
        }

        public bool Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return false;

            //_db.Employees.Remove(employee);

            //_db.Entry(employee).State = EntityState.Deleted;

            _db.Remove(employee);

            return true;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
