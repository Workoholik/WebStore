using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Data;
using WebStore.ViewModels;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{ 
    public class EmployeesController : Controller
    {
        private ILogger<EmployeesController> _Logger;
        private IEmployeesData __EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData, ILogger<EmployeesController> Logger)
        {
            _Logger = Logger;
            __EmployeesData = EmployeesData;
        }

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

        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        public IActionResult Edit(int? Id)
        {
            if (Id is null)
                return View(new EmployeeViewModel());

            var employee = __EmployeesData.GetById((int)Id);
            if (employee is null)
            {
                _Logger.LogWarning("Попытка редактирования не сущ. сотрудника с id:{0}", Id);
                return NotFound();
            }

            var model = new EmployeeViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Department = employee.Department.Id,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Model)
        {
            Department department = null ; 
            if ((int)Model.Department > 0)
            {
                department = TestDepartment.Departments.Find(dep => dep.Id == Model.Department);
            }

            if (department is null)
            {
                department = TestDepartment.Departments.First();
            }

            var employee = new Employee 
            {
                Id = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.FirstName,
                Patronymic = Model.Patronymic,
                Age = Model.Age,
                Department = department,
            };

            if (Model.Id == 0)
            {
                __EmployeesData.Add(employee);
                _Logger.LogInformation("Создан новый сотрудник с id:{0}", employee.Id);
            }
            else if (!__EmployeesData.Edit(employee))
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

            _Logger.LogInformation("Cотрудник с id:{0} был удален", Id);

            // обработка модели
            return RedirectToAction("Index");
        }
    }

}
