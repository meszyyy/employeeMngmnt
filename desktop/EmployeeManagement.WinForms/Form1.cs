using EmployeeManagement.Core.Repositories;

namespace EmployeeManagement.WinForms;

public partial class Form1 : Form
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public Form1(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        InitializeComponent();
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }
}
