using Emp.Librarary.Application.IRepository;
using Emp.Librarary.Application.IServices;
using Emp.Librarary.Domain;

namespace Emp.Librarary.Application.Services.impl
{
    public class IEmployeeServicesImpl : IEmployeeServices
    {
        public IEmployeeServicesImpl(IEmployeeRepository userManagmetRepository)
        {
            _userManagmetRepository = userManagmetRepository;
        }

        private readonly IEmployeeRepository _userManagmetRepository;


        public async Task<bool> Add(Employee employee)
        {
            return await _userManagmetRepository.Add(employee);

        }

        public async Task<List<Employee>> GetAll()
        {
            return await _userManagmetRepository.GetAll();
        }

        public async Task<Employee> GetById(int employeeId)
        {

            return await _userManagmetRepository.GetById(employeeId);
        }

        public async Task<bool> Update(Employee employee)
        {
            return await _userManagmetRepository.Update(employee);
        }
    }
}
