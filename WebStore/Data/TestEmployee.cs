using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Data
{
    public class TestEmployee
    {
        public static List<Employee> Employees { get; } = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 25, Department = TestDepartment.Departments?[1] },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 32, Department = TestDepartment.Departments?[1] },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 46, Department = TestDepartment.Departments?[0] }
        };

    }
}
