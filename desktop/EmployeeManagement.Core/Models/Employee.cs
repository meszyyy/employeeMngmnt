namespace EmployeeManagement.Core.Models;

public class Employee
{
    public int Id { get; set; }
    public required Department Department { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public DateOnly EntryDate { get; set; }
}
