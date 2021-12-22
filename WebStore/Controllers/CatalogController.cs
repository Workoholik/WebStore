using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{

    public class CatalogController : Controller
    {
        private static readonly List<Product> __Products = new()
        {
            new Product { Id = 1, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product12.jpg" },
            new Product { Id = 2, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product11.jpg" },
            new Product { Id = 3, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product10.jpg" },
            new Product { Id = 4, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product9.jpg" },
            new Product { Id = 5, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product8.jpg" },
            new Product { Id = 6, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product12.jpg" },
            new Product { Id = 7, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product11.jpg" },
            new Product { Id = 8, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product10.jpg" }, 
            new Product { Id = 9, Name = "Easy Polo Black Edition", Price = 56, Image= "/images/shop/product9.jpg" }, 
        };
         
        public IActionResult Index()
        { 
            List<Product> result = __Products;
            return View(result);
        }

        public IActionResult Details() => View();
    }
}
