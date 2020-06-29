using System.ComponentModel.DataAnnotations;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities.Employees
{
    /// <summary>Информация о сотруднике</summary>
    public class Employee : BaseEntity
    {
        /// <summary>Имя</summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Возраст</summary>
        public int Age { get; set; }
    }
}
