using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Checkout() => View();
    }
}
