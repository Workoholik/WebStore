using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Product> __Products = new()
        {
            new Product { Id = 1, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product12.jpg" },
            new Product { Id = 2, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product11.jpg" },
            new Product { Id = 3, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product10.jpg" },
            new Product { Id = 4, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product9.jpg" },
            new Product { Id = 5, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product8.jpg" },
            new Product { Id = 6, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product12.jpg" },
            new Product { Id = 7, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product11.jpg" },
            new Product { Id = 8, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product10.jpg" },
            new Product { Id = 9, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product9.jpg" },
            new Product { Id = 10, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product8.jpg" },
            new Product { Id = 11, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product12.jpg" },
            new Product { Id = 12, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product11.jpg" },
            new Product { Id = 13, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product10.jpg" },
            new Product { Id = 14, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product9.jpg" },
            new Product { Id = 15, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product8.jpg" },
            new Product { Id = 16, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product12.jpg" },
            new Product { Id = 17, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product11.jpg" },
            new Product { Id = 18, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product10.jpg" },
            new Product { Id = 19, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product9.jpg" },
            new Product { Id = 120, Name = "Easy Polo Black Edition", Price = 56, Image = "/images/shop/product8.jpg" },
        }; 

        private readonly string CustomControllerContent;
        public HomeController(IConfiguration configuration)
        {
            this.CustomControllerContent = configuration.GetSection("Custom")["Controller"];
        }

        public IActionResult Index() => View(__Products);

        public IActionResult Contacts() => View();

        public IActionResult Login() => View();

    }
}
