using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly string CustomControllerContent;
        public HomeController(IConfiguration configuration)
        {
            this.CustomControllerContent = configuration.GetSection("Custom")["Controller"];
        }


        private static readonly List<Menu> __Menu = new (){ 
            new Menu { Title = "Сотрудники", Code = "employees" },
            new Menu {Title = "Департаменты", Code = "department" },
        };

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

        public IActionResult Index()
        { 

            return View(__Menu);
        }

        public IActionResult Employees(int id)
        { 
            if (id > 0)
            {
                return View("Employee", __Employee[id-1]);
            } 
            else
            {
                return View("Employees", __Employee);
            }
        }

        public string ConfiguredAction(string id, string Value1)
        { 
            return $"ID: {id}, Value1: {Value1}, CustomControllerContent: {this.CustomControllerContent}";
        }

    }
}
