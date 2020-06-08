using System.Collections.Generic;
using WebStore.DAL.Context;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlEmployeesData : IEmployeesData
    {
        private readonly WebStoreDB _db;

        public SqlEmployeesData(WebStoreDB db) => _db = db;

        public IEnumerable<Employee> Get() { throw new System.NotImplementedException(); }

        public Employee GetById(int id) { throw new System.NotImplementedException(); }

        public int Add(Employee Employee) { throw new System.NotImplementedException(); }

        public void Edit(Employee Employee) { throw new System.NotImplementedException(); }

        public bool Delete(int id) { throw new System.NotImplementedException(); }

        public void SaveChanges() { throw new System.NotImplementedException(); }
    }
}
