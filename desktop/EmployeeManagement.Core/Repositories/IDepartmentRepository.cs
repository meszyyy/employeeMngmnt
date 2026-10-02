using EmployeeManagement.Core.Models;

namespace EmployeeManagement.Core.Repositories;

public interface IDepartmentRepository
{
    Task<IReadOnlyList<Department>> GetAllAsync();
}
