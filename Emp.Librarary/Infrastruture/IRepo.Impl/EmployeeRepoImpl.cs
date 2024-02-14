using Emp.Librarary.Application.IRepository;
using Emp.Librarary.Domain;
using Emp.Librarary.Infrastruture.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Emp.Librarary.Infrastruture.IRepo.Impl
{
    public class EmployeeRepoImpl : IEmployeeRepository
    {
        readonly DbaseContext _context;

        public EmployeeRepoImpl(DbaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Employee employee)
        {
            var res = await _context.AddAsync<Employee>(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.employee.ToListAsync();

        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _context.employee.Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Employee employee)
        {
            var stud = _context.employee.Where(x => x.EmployeeId == employee.EmployeeId).SingleOrDefault();

            _context.Entry(stud).CurrentValues.SetValues(employee);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
