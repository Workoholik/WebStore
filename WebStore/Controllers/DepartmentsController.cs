using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WebStore.Data;
using WebStore.Models;
using WebStore.ViewModels;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentsData _DepartmentData;
        private ILogger<DepartmentsController> _Logger;

        public DepartmentsController(IDepartmentsData DepartmentData, ILogger<DepartmentsController> Logger)
        {
            _DepartmentData = DepartmentData;
            _Logger = Logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Departments";
            IEnumerable<Department> departments = _DepartmentData.GetAll();

            return View(departments);
        }

        public IActionResult Details(int Id)
        {

            Department department = _DepartmentData.GetById(Id);
            if (department is null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Department: " + department.Title;


            return View("Details", department);
        }

        public IActionResult Create() => View("Edit", new DepartmentViewModel());

        public IActionResult Edit(int? Id)
        {
            if (Id is null)
                return View(new DepartmentViewModel());

            Department department = _DepartmentData.GetById((int)Id);
            if (department is null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Department: " + department.Title;

            DepartmentViewModel model = new DepartmentViewModel
            {
                Id = department.Id,
                Code = department.Code,
                Title = department.Title,
            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model)
        {
            Department department = new Department
            {
                Id = model.Id,
                Code = model.Code,
                Title = model.Title,
            };

            if (model.Id == 0)
            {
                int Id = _DepartmentData.Add(department);
                if (Id <= 0)
                {
                    return NotFound(); 
                } 
            }
            else if(!_DepartmentData.Edit(department))
            {
                return NotFound();
            } 

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            Department department = _DepartmentData.GetById((int)Id);
            if (department is null)
            {
                return NotFound();
            }

            DepartmentViewModel model = new DepartmentViewModel
            {
                Id = department.Id,
                Code = department.Code,
                Title = department.Title,
            };

            return View("Delete", model);
        }

        public IActionResult DeleteConfirmed(int Id)
        {

            if (!_DepartmentData.Delete(Id))
            {
                return NotFound();
            }
              
            return RedirectToAction("Index");
        }
    }
}
