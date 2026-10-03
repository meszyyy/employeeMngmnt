namespace EmployeeManagement.WinForms;

partial class EmployeeEditForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        layoutPanel = new TableLayoutPanel();
        firstNameLabel = new Label();
        firstNameTextBox = new TextBox();
        lastNameLabel = new Label();
        lastNameTextBox = new TextBox();
        emailLabel = new Label();
        emailTextBox = new TextBox();
        departmentLabel = new Label();
        departmentComboBox = new ComboBox();
        entryDateLabel = new Label();
        entryDatePicker = new DateTimePicker();
        buttonPanel = new FlowLayoutPanel();
        cancelButton = new Button();
        saveButton = new Button();
        errorProvider = new ErrorProvider(components);
        layoutPanel.SuspendLayout();
        buttonPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // layoutPanel
        // 
        layoutPanel.ColumnCount = 2;
        layoutPanel.ColumnStyles.Add(new ColumnStyle());
        layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPanel.Controls.Add(firstNameLabel, 0, 0);
        layoutPanel.Controls.Add(firstNameTextBox, 1, 0);
        layoutPanel.Controls.Add(lastNameLabel, 0, 1);
        layoutPanel.Controls.Add(lastNameTextBox, 1, 1);
        layoutPanel.Controls.Add(emailLabel, 0, 2);
        layoutPanel.Controls.Add(emailTextBox, 1, 2);
        layoutPanel.Controls.Add(departmentLabel, 0, 3);
        layoutPanel.Controls.Add(departmentComboBox, 1, 3);
        layoutPanel.Controls.Add(entryDateLabel, 0, 4);
        layoutPanel.Controls.Add(entryDatePicker, 1, 4);
        layoutPanel.Controls.Add(buttonPanel, 0, 5);
        layoutPanel.Dock = DockStyle.Fill;
        layoutPanel.Location = new Point(0, 0);
        layoutPanel.Name = "layoutPanel";
        layoutPanel.Padding = new Padding(12, 12, 30, 12);
        layoutPanel.RowCount = 6;
        layoutPanel.RowStyles.Add(new RowStyle());
        layoutPanel.RowStyles.Add(new RowStyle());
        layoutPanel.RowStyles.Add(new RowStyle());
        layoutPanel.RowStyles.Add(new RowStyle());
        layoutPanel.RowStyles.Add(new RowStyle());
        layoutPanel.RowStyles.Add(new RowStyle());
        layoutPanel.Size = new Size(424, 241);
        layoutPanel.TabIndex = 0;
        // 
        // firstNameLabel
        // 
        firstNameLabel.Anchor = AnchorStyles.Left;
        firstNameLabel.AutoSize = true;
        firstNameLabel.Location = new Point(15, 19);
        firstNameLabel.Name = "firstNameLabel";
        firstNameLabel.Size = new Size(62, 15);
        firstNameLabel.TabIndex = 0;
        firstNameLabel.Text = "First name";
        // 
        // firstNameTextBox
        // 
        firstNameTextBox.Dock = DockStyle.Fill;
        firstNameTextBox.Location = new Point(96, 15);
        firstNameTextBox.MaxLength = 100;
        firstNameTextBox.Name = "firstNameTextBox";
        firstNameTextBox.Size = new Size(313, 23);
        firstNameTextBox.TabIndex = 1;
        // 
        // lastNameLabel
        // 
        lastNameLabel.Anchor = AnchorStyles.Left;
        lastNameLabel.AutoSize = true;
        lastNameLabel.Location = new Point(15, 48);
        lastNameLabel.Name = "lastNameLabel";
        lastNameLabel.Size = new Size(61, 15);
        lastNameLabel.TabIndex = 2;
        lastNameLabel.Text = "Last name";
        // 
        // lastNameTextBox
        // 
        lastNameTextBox.Dock = DockStyle.Fill;
        lastNameTextBox.Location = new Point(96, 44);
        lastNameTextBox.MaxLength = 100;
        lastNameTextBox.Name = "lastNameTextBox";
        lastNameTextBox.Size = new Size(313, 23);
        lastNameTextBox.TabIndex = 3;
        // 
        // emailLabel
        // 
        emailLabel.Anchor = AnchorStyles.Left;
        emailLabel.AutoSize = true;
        emailLabel.Location = new Point(15, 77);
        emailLabel.Name = "emailLabel";
        emailLabel.Size = new Size(41, 15);
        emailLabel.TabIndex = 4;
        emailLabel.Text = "E-mail";
        // 
        // emailTextBox
        // 
        emailTextBox.Dock = DockStyle.Fill;
        emailTextBox.Location = new Point(96, 73);
        emailTextBox.MaxLength = 320;
        emailTextBox.Name = "emailTextBox";
        emailTextBox.Size = new Size(313, 23);
        emailTextBox.TabIndex = 5;
        // 
        // departmentLabel
        // 
        departmentLabel.Anchor = AnchorStyles.Left;
        departmentLabel.AutoSize = true;
        departmentLabel.Location = new Point(15, 106);
        departmentLabel.Name = "departmentLabel";
        departmentLabel.Size = new Size(70, 15);
        departmentLabel.TabIndex = 6;
        departmentLabel.Text = "Department";
        // 
        // departmentComboBox
        // 
        departmentComboBox.Dock = DockStyle.Fill;
        departmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        departmentComboBox.Location = new Point(96, 102);
        departmentComboBox.Name = "departmentComboBox";
        departmentComboBox.Size = new Size(313, 23);
        departmentComboBox.TabIndex = 7;
        // 
        // entryDateLabel
        // 
        entryDateLabel.Anchor = AnchorStyles.Left;
        entryDateLabel.AutoSize = true;
        entryDateLabel.Location = new Point(15, 135);
        entryDateLabel.Name = "entryDateLabel";
        entryDateLabel.Size = new Size(75, 15);
        entryDateLabel.TabIndex = 8;
        entryDateLabel.Text = "Date of entry";
        // 
        // entryDatePicker
        // 
        entryDatePicker.Dock = DockStyle.Fill;
        entryDatePicker.Format = DateTimePickerFormat.Short;
        entryDatePicker.Location = new Point(96, 131);
        entryDatePicker.Name = "entryDatePicker";
        entryDatePicker.Size = new Size(313, 23);
        entryDatePicker.TabIndex = 9;
        // 
        // buttonPanel
        // 
        buttonPanel.AutoSize = true;
        layoutPanel.SetColumnSpan(buttonPanel, 2);
        buttonPanel.Controls.Add(cancelButton);
        buttonPanel.Controls.Add(saveButton);
        buttonPanel.Dock = DockStyle.Fill;
        buttonPanel.FlowDirection = FlowDirection.RightToLeft;
        buttonPanel.Location = new Point(15, 169);
        buttonPanel.Margin = new Padding(3, 12, 3, 3);
        buttonPanel.Name = "buttonPanel";
        buttonPanel.Size = new Size(394, 57);
        buttonPanel.TabIndex = 10;
        // 
        // cancelButton
        // 
        cancelButton.BackColor = Color.White;
        cancelButton.Cursor = Cursors.Hand;
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
        cancelButton.FlatStyle = FlatStyle.Flat;
        cancelButton.ForeColor = Color.FromArgb(55, 65, 81);
        cancelButton.Location = new Point(303, 3);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(88, 30);
        cancelButton.TabIndex = 1;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        //
        // saveButton
        //
        saveButton.BackColor = Color.FromArgb(37, 99, 235);
        saveButton.Cursor = Cursors.Hand;
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
        saveButton.FlatStyle = FlatStyle.Flat;
        saveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        saveButton.ForeColor = Color.White;
        saveButton.Location = new Point(209, 3);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(88, 30);
        saveButton.TabIndex = 0;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.Click += saveButton_Click;
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // EmployeeEditForm
        // 
        AcceptButton = saveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = cancelButton;
        ClientSize = new Size(440, 252);
        ForeColor = Color.FromArgb(55, 65, 81);
        Controls.Add(layoutPanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EmployeeEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Employee";
        FormClosing += EmployeeEditForm_FormClosing;
        Load += EmployeeEditForm_Load;
        layoutPanel.ResumeLayout(false);
        layoutPanel.PerformLayout();
        buttonPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel layoutPanel;
    private Label firstNameLabel;
    private TextBox firstNameTextBox;
    private Label lastNameLabel;
    private TextBox lastNameTextBox;
    private Label emailLabel;
    private TextBox emailTextBox;
    private Label departmentLabel;
    private ComboBox departmentComboBox;
    private Label entryDateLabel;
    private DateTimePicker entryDatePicker;
    private FlowLayoutPanel buttonPanel;
    private Button cancelButton;
    private Button saveButton;
    private ErrorProvider errorProvider;
}
