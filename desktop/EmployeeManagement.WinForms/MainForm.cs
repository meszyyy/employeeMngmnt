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

        UpdateButtonStates();
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

    private async Task<IReadOnlyList<Department>?> LoadDepartmentsAsync()
    {
        try
        {
            return await _departmentRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading departments: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return null;
        }
    }

    private async void newButton_Click(object sender, EventArgs e)
    {
        var departments = await LoadDepartmentsAsync();
        if (departments is null)
            return;

        using var employeeEditForm = new EmployeeEditForm(departments, _employeeRepository);
        if (employeeEditForm.ShowDialog(this) == DialogResult.OK) // this because of StartPosition = CenterParent
        {
            await LoadEmployeesAsync();
        }
    }

    private async void editButton_Click(object sender, EventArgs e)
    {
        await EditSelectedEmployeeAsync();
    }

    private async void employeesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        await EditSelectedEmployeeAsync();
    }

    private async Task EditSelectedEmployeeAsync()
    {
        if (employeesGrid.CurrentRow?.DataBoundItem is not Employee employee)
            return;

        var departments = await LoadDepartmentsAsync();
        if (departments is null)
            return;

        using var employeeEditForm = new EmployeeEditForm(departments, _employeeRepository, employee);
        if (employeeEditForm.ShowDialog(this) == DialogResult.OK) // this because of StartPosition = CenterParent
        {
            await LoadEmployeesAsync();
        }
    }

    private void UpdateButtonStates()
    {
        var hasSelection = employeesGrid.CurrentRow?.DataBoundItem is Employee;
        editButton.Enabled = hasSelection;
        deleteButton.Enabled = hasSelection;
    }

    private void employeesGrid_SelectionChanged(object sender, EventArgs e)
    {
        UpdateButtonStates();
    }
}
