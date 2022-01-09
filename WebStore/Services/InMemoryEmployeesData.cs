using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private int _MaxFreeId;

        private readonly ILogger<InMemoryEmployeesData> _Logger;
        private readonly ICollection<Employee> _Employees;

        public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> Logger) // ILogger - логер это интерфейс, InMemoryEmployeesData - это заголовок
        {
            _Logger = Logger;
            _Employees = TestEmployee.Employees;
            _MaxFreeId = _Employees.DefaultIfEmpty().Max(e => e?.Id ?? 0) + 1;
        }


        public int Add(Employee employee)
        {
            if(employee is null)
            {
                _Logger.LogWarning("Добавление сущности не являющейся сотрудником");
                throw new ArgumentNullException(nameof(employee));
            }

            if (_Employees.Contains(employee))
            {
                _Logger.LogWarning("Попытка добавления существующего сотрудника с id:{0}", employee.Id);
                return employee.Id;
            }    

            employee.Id = _MaxFreeId++;

            _Employees.Add(employee);
            _Logger.LogWarning("Добавлен новый сотрудник с id:{0}", employee.Id);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
            {
                _Logger.LogWarning("Удаления не существующего сотрудника с id:{0}", id);
                return false;
            }

            _Employees.Remove(employee);
            _Logger.LogInformation("Сотрудник id:{0} был удален", employee.Id);

            return true;
        }

        public bool Edit(Employee employee)
        {
            if (employee is null)
            {
                _Logger.LogWarning("Редактирование сущности не являющейся сотрудником");
                throw new ArgumentNullException(nameof(employee));
            }

            if (_Employees.Contains(employee))
            {
                _Logger.LogWarning("Попытка редактирование сотрудника, данные не изменены");
                return true;
            }    

            var db_employee = GetById(employee.Id);
            if (db_employee is null) 
            {
                _Logger.LogWarning("Попытка редактирования не существующего сотрудника с id:{0}", employee.Id);
                return false;
            }
             
            db_employee.FirstName = employee.FirstName; 
            db_employee.LastName = employee.LastName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Age = employee.Age;
            db_employee.Department = employee.Department;

            _Logger.LogInformation("Информация о сотруднике  id:{0} была изменена", employee.Id);

            return true;
        }

        public IEnumerable<Employee> GetAll() => _Employees;

        public Employee? GetById(int id) => _Employees.FirstOrDefault(employee => employee.Id == id);
    }
}
