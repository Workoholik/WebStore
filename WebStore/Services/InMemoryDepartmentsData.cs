using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryDepartmentsData : IDepartmentsData
    {
        private int _MaxFreeId;

        private readonly ILogger<InMemoryDepartmentsData> _Logger;
        private readonly ICollection<Department> _Departments;

        public InMemoryDepartmentsData(ILogger<InMemoryDepartmentsData> Logger) // ILogger - логер это интерфейс, InMemoryEmployeesData - это заголовок
        {
            _Logger = Logger;
            _Departments = TestDepartment.Departments;
            _MaxFreeId = _Departments.DefaultIfEmpty().Max(e => e?.Id ?? 0) + 1;
        }


        public int Add(Department department)
        {
            if(department is null)
            {
                _Logger.LogWarning("Добавление сущности не являющейся подразделением");
                throw new ArgumentNullException(nameof(department));
            }

            if (_Departments.Contains(department))
            {
                _Logger.LogWarning("Попытка добавления существующего подразделения с id:{0}", department.Id);
                return department.Id;
            }

            department.Id = _MaxFreeId++;
            _Logger.LogWarning("Добавлен новое подразделение с id:{0}", department.Id);

            _Departments.Add(department);

            return department.Id;
        }

        public bool Delete(int id)
        {
            var department = GetById(id);
            if (department is null)
            {
                _Logger.LogWarning("Удаления не существующего подразделения с id:{0}", id);
                return false;
            }

            _Departments.Remove(department);
            _Logger.LogInformation("Подразделение id:{0} было удалено", department.Id);

            return true;
        }

        public bool Edit(Department department)
        {
            if (department is null)
            {
                _Logger.LogWarning("Редактирование сущности не являющейся подразделением");
                throw new ArgumentNullException(nameof(department));
            }

            if (_Departments.Contains(department))
            {
                _Logger.LogWarning("Попытка редактирования подразделения, данные не изменены");
                return true;
            }

            var db_department = GetById(department.Id);
            if (db_department is null)
            {
                _Logger.LogWarning("Попытка редактирования не существующего подразделения с id:{0}", department.Id);
                return false;
            }

            db_department.Code = department.Code;
            db_department.Title = department.Title;

            _Logger.LogInformation("Информация о подразделении  id:{0} была изменена", department.Id);

            return true;
        }

        public IEnumerable<Department> GetAll() => _Departments;

        public Department? GetById(int id) => _Departments.FirstOrDefault(department => department.Id == id);
    }
}
