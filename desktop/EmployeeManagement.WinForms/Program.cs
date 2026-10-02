using Microsoft.Extensions.Configuration;
using EmployeeManagement.Data.Repositories;

namespace EmployeeManagement.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = configuration.GetConnectionString("EmployeeManagement")
            ?? throw new InvalidOperationException("Connection string 'EmployeeManagement' not found.");
        var departmentRepository = new DepartmentRepository(connectionString);
        var employeeRepository = new EmployeeRepository(connectionString);

        Application.Run(new Form1(employeeRepository, departmentRepository));
    }
}
