using EmployeeManagement.Core.Models;

namespace EmployeeManagement.Core.Repositories;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(Employee employee);
    Task<int> CreateAsync(Employee employee);
}
