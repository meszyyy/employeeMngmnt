using EmployeeManagement.Core.Models;
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
        await LoadEmployeesAsync();
    }

    private async Task LoadEmployeesAsync()
    {
        try
        {
            var employees = await _employeeRepository.GetAllAsync();
            employeesGrid.DataSource = employees;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading employees: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void refreshButton_Click(object sender, EventArgs e)
    {
        await LoadEmployeesAsync();
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        if (employeesGrid.CurrentRow?.DataBoundItem is not Employee employee)
            return;

        var result = MessageBox.Show($"Are you sure you want to delete {employee.FirstName} {employee.LastName}?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);

        if (result != DialogResult.Yes)
        {
            return;
        }

        try
        {
            var isDeleted = await _employeeRepository.DeleteAsync(employee.Id);
            if (!isDeleted)
            {
                MessageBox.Show("This employee has already been deleted by someone else.",
                    "Already deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while deleting the employee: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }
        await LoadEmployeesAsync();
    }
}
