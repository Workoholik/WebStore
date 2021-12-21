using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {

        private static readonly Dictionary<string, Department> department = new Dictionary<string, Department>()
        {
            {
                "IT", new Department { Code = "it", Title = "IT" }
            },
            {
                "bookkeping", new Department { Code = "bookkeping", Title = "Бухгалтерия" }
            },
        };

        private static readonly List<Employee> __Employee = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 25, Department = department["IT"] },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 32, Department = department["IT"] },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 46, Department = department["bookkeping"] }
        };

        public IActionResult Index(int id)
        {
            if (id > 0)
            {
                return View("Employee", __Employee[id - 1]);
            }
            else
            {
                return View(__Employee);
            }
        }
    }
}
