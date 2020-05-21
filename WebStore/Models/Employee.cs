using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public int Age { get; set; }
    }
}
