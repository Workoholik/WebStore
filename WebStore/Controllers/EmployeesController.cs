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

            var model = new EmployeeViewModel
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
        public IActionResult Edit(EmployeeViewModel Model)
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

        public IActionResult Delete(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var employee = __EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();

            var model = new EmployeeViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            };

            return View(model);
        }

        public IActionResult DeleteConfirmed(int Id)
        {

            if (!__EmployeesData.Delete(Id))
                return NotFound();

            // обработка модели
            return RedirectToAction("Index");
        }
    }

}
