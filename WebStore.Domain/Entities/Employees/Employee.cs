using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities.Employees
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public int Age { get; set; }
    }
}
