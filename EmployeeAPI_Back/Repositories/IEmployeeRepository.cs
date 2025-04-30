using EmployeeAPI_Back.Models;

namespace EmployeeAPI_Back.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(int pageNumber, int pageSize, string searchTerm);
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
