using Dapper;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Repositories;
using Microsoft.Data.SqlClient;

namespace EmployeeManagement.Data.Repositories;

public class DepartmentRepository(string connectionString) : IDepartmentRepository
{
    public async Task<IReadOnlyList<Department>> GetAllAsync()
    {
        await using var connection = new SqlConnection(connectionString);

        var departments = await connection.QueryAsync<Department>("SELECT Id, Name FROM dbo.Department ORDER BY Name");

        return departments.ToList();
    }
}
