using Dapper;
using EmployeeManagement.Core.Exceptions;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Repositories;
using Microsoft.Data.SqlClient;

namespace EmployeeManagement.Data.Repositories;

public class EmployeeRepository(string connectionString) : IEmployeeRepository
{
    public async Task<int> CreateAsync(Employee employee)
    {
        await using var connection = new SqlConnection(connectionString);

        const string sql = """
            INSERT INTO dbo.Employee (FirstName, LastName, Email, EntryDate, DepartmentId) 
            OUTPUT INSERTED.Id
            VALUES (@FirstName, @LastName, @Email, @EntryDate, @DepartmentId);
            """;

        try
        {
            var newId = await connection.ExecuteScalarAsync<int>(sql, new
            {
                employee.FirstName,
                employee.LastName,
                employee.Email,
                employee.EntryDate,
                DepartmentId = employee.Department.Id
            });

            return newId;
        }
        catch (SqlException ex) when (IsDuplicateEmail(ex))
        {
            throw new DuplicateEmailException(employee.Email);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var connection = new SqlConnection(connectionString);

        const string sql = """
            DELETE FROM dbo.Employee WHERE Id = @Id;
            """;

        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<IReadOnlyList<Employee>> GetAllAsync()
    {
        await using var connection = new SqlConnection(connectionString);

        const string sql = """
        SELECT e.Id, e.FirstName, e.LastName, e.Email, e.EntryDate, d.Id, d.Name
        FROM dbo.Employee e
        JOIN dbo.Department d ON e.DepartmentId = d.Id
        ORDER BY e.LastName, e.FirstName
        """;

        var employees = await connection.QueryAsync<Employee, Department, Employee>(
         sql,
         (employee, department) =>
         {
             employee.Department = department;
             return employee;
         },
         splitOn: "Id");

        return employees.ToList();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        await using var connection = new SqlConnection(connectionString);

        const string sql = """
        SELECT e.Id, e.FirstName, e.LastName, e.Email, e.EntryDate, d.Id, d.Name
        FROM dbo.Employee e
        JOIN dbo.Department d ON e.DepartmentId = d.Id
        WHERE e.Id = @Id
        """;

        var employees = await connection.QueryAsync<Employee, Department, Employee>(
         sql,
         (employee, department) =>
         {
             employee.Department = department;
             return employee;
         },
         param: new { Id = id },
         splitOn: "Id");

        return employees.FirstOrDefault();
    }

    public async Task<bool> UpdateAsync(Employee employee)
    {
        await using var connection = new SqlConnection(connectionString);

        const string sql = """
            UPDATE dbo.Employee
            SET FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            EntryDate = @EntryDate,
            DepartmentId = @DepartmentId
            WHERE Id = @Id;
            """;

        try
        {
            var affectedRows = await connection.ExecuteAsync(sql, new { Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName, Email = employee.Email, EntryDate = employee.EntryDate, DepartmentId = employee.Department.Id });
            return affectedRows > 0;
        }
        catch (SqlException ex) when (IsDuplicateEmail(ex))
        {
            throw new DuplicateEmailException(employee.Email);
        }
    }

    // 2627 = unique constraint violation, 2601 = unique index violation.
    // The constraint name check makes sure we only translate the e-mail uniqueness error.
    private static bool IsDuplicateEmail(SqlException ex) =>
        ex.Number is 2627 or 2601
        && ex.Message.Contains("UQ_Employee_Email", StringComparison.OrdinalIgnoreCase);
}
