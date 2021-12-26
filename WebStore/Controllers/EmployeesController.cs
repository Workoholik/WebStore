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

        private static readonly List<Employee> __Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 25, Department = department["IT"] },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 32, Department = department["IT"] },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 46, Department = department["bookkeping"] }
        };

        public IActionResult Index()
        {
            ViewData["Title"] = "Employees";

            List<Employee> result = __Employees; 
            return View(result);
        }

       public IActionResult Details(int Id)
        {
            var result = __Employees.FirstOrDefault(e => e.Id == Id);
            if (result is null)
                return NotFound();

            ViewData["Title"] = "Employee " + result.FirstName;
            ViewData["CustomTitle"] = result;

            return View("Details", result);
        }
    }
}
