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

        public IActionResult Index()
        {  
            return View(__Menu);
        }
         

        public string ConfiguredAction(string id, string Value1)
        { 
            return $"ID: {id}, Value1: {Value1}, CustomControllerContent: {this.CustomControllerContent}";
        }

    }
}
