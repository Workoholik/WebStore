using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    
    public interface IDepartmentsData
    {
        IEnumerable<Department> GetAll();
        Department? GetById(int id);

        int Add(Department department);
        bool Edit(Department department);
        bool Delete(int id);
    }
}
