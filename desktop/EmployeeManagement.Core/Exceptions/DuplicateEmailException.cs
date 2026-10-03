namespace EmployeeManagement.Core.Exceptions;

public class DuplicateEmailException(string email)
    : Exception($"The e-mail address '{email}' is already in use.")
{
    public string Email { get; } = email;
}
