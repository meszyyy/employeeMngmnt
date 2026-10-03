using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Repositories;

namespace EmployeeManagement.WinForms;

public partial class EmployeeEditForm : Form
{
    private readonly IReadOnlyList<Department> _departments;
    private readonly Employee? _employee;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeEditForm(IReadOnlyList<Department> departments, IEmployeeRepository employeeRepository, Employee? employee = null)
    {
        InitializeComponent();
        _departments = departments;
        _employee = employee;
        _employeeRepository = employeeRepository;
    }

    private void EmployeeEditForm_Load(object sender, EventArgs e)
    {
        departmentComboBox.DisplayMember = nameof(Department.Name);
        departmentComboBox.ValueMember = nameof(Department.Id);
        departmentComboBox.DataSource = _departments;

        if (_employee is null)
        {
            Text = "Add Employee";
            entryDatePicker.Value = DateTime.Today;
        }
        else
        {
            Text = "Edit Employee";
            firstNameTextBox.Text = _employee.FirstName;
            lastNameTextBox.Text = _employee.LastName;
            emailTextBox.Text = _employee.Email;
            departmentComboBox.SelectedValue = _employee.Department.Id;
            entryDatePicker.Value = _employee.EntryDate.ToDateTime(TimeOnly.MinValue);
        }
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        var employee = new Employee
        {
            Id = _employee?.Id ?? 0,
            FirstName = firstNameTextBox.Text.Trim(),
            LastName = lastNameTextBox.Text.Trim(),
            Email = emailTextBox.Text.Trim(),
            Department = (Department)departmentComboBox.SelectedItem!,
            EntryDate = DateOnly.FromDateTime(entryDatePicker.Value)
        };

        try
        {
            if (_employee is null)
            {
                await _employeeRepository.CreateAsync(employee);
            }
            else
            {
                var isUpdated = await _employeeRepository.UpdateAsync(employee);
                if (!isUpdated)
                {
                    MessageBox.Show("The employee could not be updated. It may have been deleted by another user.",
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while saving the employee: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
