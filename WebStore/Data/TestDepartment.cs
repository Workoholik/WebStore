using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Data
{
    public class TestDepartment
    {
        public static List<Department> Departments { get; } = new ()
        {
            new Department { Id = 1, Code = "it", Title = "IT" },
            new Department { Id = 2, Code = "bookkeping", Title = "Бухгалтерия" },
        };

    }
}
