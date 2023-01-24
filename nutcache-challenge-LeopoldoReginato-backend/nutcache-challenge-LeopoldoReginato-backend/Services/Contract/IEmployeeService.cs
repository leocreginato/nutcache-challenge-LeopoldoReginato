using nutcache_challenge_LeopoldoReginato_backend.Models;

namespace nutcache_challenge_LeopoldoReginato_backend.Services.Contract
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetList();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(Employee employee);
    }
}
