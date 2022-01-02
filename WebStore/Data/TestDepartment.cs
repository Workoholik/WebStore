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
        public static Dictionary<string, Department> Department { get; } = new Dictionary<string, Department>()
        {
            {
                "IT", new Department { Code = "it", Title = "IT" }
            },
            {
                "bookkeping", new Department { Code = "bookkeping", Title = "Бухгалтерия" }
            },
        };

    }
}
