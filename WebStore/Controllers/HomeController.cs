using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly string CustomControllerContent;
        public HomeController(IConfiguration configuration)
        {
            this.CustomControllerContent = configuration.GetSection("Custom")["Controller"];
        }

        public IActionResult Index()
        { 

            return View("Index");
        }

        public string ConfiguredAction(string id, string Value1)
        { 
            return $"ID: {id}, Value1: {Value1}, CustomController: {this.CustomControllerContent}";
        }

    }
}
