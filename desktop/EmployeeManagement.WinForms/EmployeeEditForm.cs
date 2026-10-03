using EmployeeManagement.Core.Models;

namespace EmployeeManagement.WinForms;

public partial class EmployeeEditForm : Form
{
    private readonly IReadOnlyList<Department> _departments;
    private readonly Employee? _employee;

    public EmployeeEditForm(IReadOnlyList<Department> departments, Employee? employee = null)
    {
        InitializeComponent();
        _departments = departments;
        _employee = employee;
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
}
