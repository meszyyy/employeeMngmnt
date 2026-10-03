using EmployeeManagement.Core.Repositories;

namespace EmployeeManagement.WinForms;

public partial class MainForm : Form
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public MainForm(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        InitializeComponent();
        employeesGrid.AutoGenerateColumns = false;
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        var employees = await _employeeRepository.GetAllAsync();
        employeesGrid.DataSource = employees;
    }
}
