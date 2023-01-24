using Microsoft.EntityFrameworkCore;
using nutcache_challenge_LeopoldoReginato_backend.Models;
using nutcache_challenge_LeopoldoReginato_backend.Services.Contract;

namespace nutcache_challenge_LeopoldoReginato_backend.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DBNutcacheContext _dbContext;

        public EmployeeService(DBNutcacheContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                Employee? employee = new Employee();
                employee = await _dbContext.Employee.Include(t => t.IdTeamNavigation).Include(g => g.IdGenderNavigation).Where(e => e.Id == id).FirstOrDefaultAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Employee>> GetList()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                employees = await _dbContext.Employee.Include(t => t.IdTeamNavigation).Include(g => g.IdGenderNavigation).ToListAsync();

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Add(Employee employee)
        {
            try
            {
                _dbContext.Employee.Add(employee);
                await _dbContext.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Update(Employee employee)
        {
            try
            {
                _dbContext.Employee.Update(employee);
                await _dbContext.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Employee employee)
        {
            try
            {
                _dbContext.Employee.Remove(employee);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
