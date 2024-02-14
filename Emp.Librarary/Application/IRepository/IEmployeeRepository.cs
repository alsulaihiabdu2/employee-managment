
using Emp.Librarary.Domain;

namespace Emp.Librarary.Application.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<bool> Add(Employee employee);
        public Task<bool> Update(Employee employee);
        public Task<List<Employee>> GetAll();
        public Task<Employee> GetById(int employeeId);
    }
}
