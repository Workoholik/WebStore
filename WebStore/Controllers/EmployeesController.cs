using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Data;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Route("Staff/{action=index}/{id?}")]
    public class EmployeesController : Controller
    {
        private List<Employee> __Employees;
        public EmployeesController() => __Employees = TestEmployee.Employees;
         
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

        public IActionResult Create() => View();
        public IActionResult Edit(int Id)
        {
            var result = __Employees.FirstOrDefault(e => e.Id == Id);
            if (result is null)
                return NotFound();

            var model = new EmployeeEditViewModel
            {
                Id = result.Id,
                LastName = result.LastName,
                FirstName = result.FirstName,
                Patronymic = result.Patronymic,
                Age = result.Age,
            };

            return View(model);
        }
        public IActionResult Edit(EmployeeEditViewModel Model)
        {
            // обработка модели
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View();

    }
}
