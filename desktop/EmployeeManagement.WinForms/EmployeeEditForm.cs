using EmployeeManagement.Core.Exceptions;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Repositories;
using System.Net.Mail;

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
        if (!ValidateInput())
            return;

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
        catch (DuplicateEmailException)
        {
            errorProvider.SetError(emailTextBox, "This e-mail address is already in use.");
            emailTextBox.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while saving the employee: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private bool ValidateInput()
    {
        errorProvider.Clear();          // remove the old errors
        var isValid = true;

        if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
        {
            errorProvider.SetError(firstNameTextBox, "First name is required.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
        {
            errorProvider.SetError(lastNameTextBox, "Last name is required.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(emailTextBox.Text))
        {
            errorProvider.SetError(emailTextBox, "Email is required.");
            isValid = false;
        }
        else if (!IsValidEmail(emailTextBox.Text.Trim()))
        {
            errorProvider.SetError(emailTextBox, "Email must be a valid email address.");
            isValid = false;
        }

        if (!isValid)
        {
            FocusFirstInvalidControl();
        }

        return isValid;
    }

    private static bool IsValidEmail(string email)
    {
        // MailAddress also accepts display-name formats like "John <john@example.com>",
        // so the parsed address must be exactly what the user typed.
        return MailAddress.TryCreate(email, out var mailAddress)
            && mailAddress.Address == email;
    }

    private void FocusFirstInvalidControl()
    {
        Control[] controlsInTabOrder = [firstNameTextBox, lastNameTextBox, emailTextBox];

        var firstInvalid = controlsInTabOrder.FirstOrDefault(c => errorProvider.GetError(c).Length > 0);
        firstInvalid?.Focus();
    }
}
