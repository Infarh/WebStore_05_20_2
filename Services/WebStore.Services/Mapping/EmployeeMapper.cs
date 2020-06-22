using WebStore.Domain.Entities.Employees;
using WebStore.Domain.ViewModels;

namespace WebStore.Services.Mapping
{
    public static class EmployeeMapper
    {
        public static EmployeeViewModel ToView(this Employee e) => new EmployeeViewModel
        {
            Id = e.Id,
            Name = e.FirstName,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
            Age = e.Age
        };

        public static Employee FromView(this EmployeeViewModel e) => new Employee
        {
            Id = e.Id,
            FirstName = e.Name,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
            Age = e.Age
        };
    }
}
