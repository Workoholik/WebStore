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

        private static readonly List<Employee> __Employee = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 25 },
            new Employee { Id = 1, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 32 },
            new Employee { Id = 1, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 46 },
        };

        public IActionResult Index()
        { 

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Employees()
        {
            return View(__Employee);
        }

        public string ConfiguredAction(string id, string Value1)
        { 
            return $"ID: {id}, Value1: {Value1}, CustomControllerContent: {this.CustomControllerContent}";
        }

    }
}
