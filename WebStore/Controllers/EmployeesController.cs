using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Data;
using WebStore.ViewModels;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{ 
    public class EmployeesController : Controller
    { 
        private IEmployeesData __EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData) => __EmployeesData = EmployeesData;
         
        public IActionResult Index()
        {
            ViewData["Title"] = "Employees";

            IEnumerable<Employee> result = __EmployeesData.GetAll(); 
            return View(result);
        }
         
       public IActionResult Details(int Id)
        {
            var employee = __EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();

            ViewData["Title"] = "Employee " + employee.FirstName;
            ViewData["CustomTitle"] = employee;

            return View("Details", employee);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(int Id)
        {
            var employee = __EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();

            var model = new EmployeeEditViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel Model)
        {
            var employee = new Employee 
            {
                Id = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.FirstName,
                Patronymic = Model.Patronymic,
                Age = Model.Age,
            };

            if (!__EmployeesData.Edit(employee))
                return NotFound();

            // обработка модели
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View();

    }
}
