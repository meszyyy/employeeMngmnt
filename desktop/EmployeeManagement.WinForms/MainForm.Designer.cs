namespace EmployeeManagement.WinForms;

partial class MainForm
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        employeesGrid = new DataGridView();
        firstNameColumn = new DataGridViewTextBoxColumn();
        lastNameColumn = new DataGridViewTextBoxColumn();
        emailColumn = new DataGridViewTextBoxColumn();
        departmentColumn = new DataGridViewTextBoxColumn();
        entryDateColumn = new DataGridViewTextBoxColumn();
        mainToolStrip = new ToolStrip();
        newButton = new ToolStripButton();
        editButton = new ToolStripButton();
        deleteButton = new ToolStripButton();
        refreshButton = new ToolStripButton();
        mainStatusStrip = new StatusStrip();
        employeeCountLabel = new ToolStripStatusLabel();
        ((System.ComponentModel.ISupportInitialize)employeesGrid).BeginInit();
        mainToolStrip.SuspendLayout();
        mainStatusStrip.SuspendLayout();
        SuspendLayout();
        //
        // employeesGrid
        //
        employeesGrid.AllowUserToAddRows = false;
        employeesGrid.AllowUserToDeleteRows = false;
        employeesGrid.AllowUserToResizeRows = false;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 251);
        employeesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        employeesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        employeesGrid.BackgroundColor = Color.White;
        employeesGrid.BorderStyle = BorderStyle.None;
        employeesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        employeesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(243, 244, 246);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(55, 65, 81);
        dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(243, 244, 246);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(55, 65, 81);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        employeesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        employeesGrid.ColumnHeadersHeight = 40;
        employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        employeesGrid.Columns.AddRange(new DataGridViewColumn[] { firstNameColumn, lastNameColumn, emailColumn, departmentColumn, entryDateColumn });
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = Color.White;
        dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F);
        dataGridViewCellStyle3.ForeColor = Color.FromArgb(31, 41, 55);
        dataGridViewCellStyle3.Padding = new Padding(8, 0, 0, 0);
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(219, 234, 254);
        dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 24, 39);
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        employeesGrid.DefaultCellStyle = dataGridViewCellStyle3;
        employeesGrid.Dock = DockStyle.Fill;
        employeesGrid.EnableHeadersVisualStyles = false;
        employeesGrid.GridColor = Color.FromArgb(229, 231, 235);
        employeesGrid.Location = new Point(0, 37);
        employeesGrid.MultiSelect = false;
        employeesGrid.Name = "employeesGrid";
        employeesGrid.ReadOnly = true;
        employeesGrid.RowHeadersVisible = false;
        employeesGrid.RowTemplate.Height = 36;
        employeesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        employeesGrid.Size = new Size(1000, 541);
        employeesGrid.TabIndex = 0;
        employeesGrid.CellDoubleClick += employeesGrid_CellDoubleClick;
        employeesGrid.SelectionChanged += employeesGrid_SelectionChanged;
        //
        // firstNameColumn
        //
        firstNameColumn.DataPropertyName = "FirstName";
        firstNameColumn.HeaderText = "First name";
        firstNameColumn.Name = "firstNameColumn";
        firstNameColumn.ReadOnly = true;
        //
        // lastNameColumn
        //
        lastNameColumn.DataPropertyName = "LastName";
        lastNameColumn.HeaderText = "Last name";
        lastNameColumn.Name = "lastNameColumn";
        lastNameColumn.ReadOnly = true;
        //
        // emailColumn
        //
        emailColumn.DataPropertyName = "Email";
        emailColumn.FillWeight = 160F;
        emailColumn.HeaderText = "E-mail";
        emailColumn.Name = "emailColumn";
        emailColumn.ReadOnly = true;
        //
        // departmentColumn
        //
        departmentColumn.DataPropertyName = "Department";
        departmentColumn.HeaderText = "Department";
        departmentColumn.Name = "departmentColumn";
        departmentColumn.ReadOnly = true;
        //
        // entryDateColumn
        //
        entryDateColumn.DataPropertyName = "EntryDate";
        dataGridViewCellStyle4.Format = "d";
        dataGridViewCellStyle4.NullValue = null;
        entryDateColumn.DefaultCellStyle = dataGridViewCellStyle4;
        entryDateColumn.FillWeight = 80F;
        entryDateColumn.HeaderText = "Date of entry";
        entryDateColumn.Name = "entryDateColumn";
        entryDateColumn.ReadOnly = true;
        //
        // mainToolStrip
        //
        mainToolStrip.BackColor = Color.White;
        mainToolStrip.GripStyle = ToolStripGripStyle.Hidden;
        mainToolStrip.Items.AddRange(new ToolStripItem[] { newButton, editButton, deleteButton, refreshButton });
        mainToolStrip.Location = new Point(0, 0);
        mainToolStrip.Name = "mainToolStrip";
        mainToolStrip.Padding = new Padding(8, 6, 8, 6);
        mainToolStrip.RenderMode = ToolStripRenderMode.System;
        mainToolStrip.Size = new Size(1000, 37);
        mainToolStrip.TabIndex = 1;
        mainToolStrip.Text = "toolStrip1";
        //
        // newButton
        //
        newButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        newButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        newButton.ForeColor = Color.FromArgb(37, 99, 235);
        newButton.Image = (Image)resources.GetObject("newButton.Image");
        newButton.ImageTransparentColor = Color.Magenta;
        newButton.Margin = new Padding(0, 1, 4, 2);
        newButton.Name = "newButton";
        newButton.Padding = new Padding(6, 2, 6, 2);
        newButton.Size = new Size(53, 22);
        newButton.Text = "+ New";
        newButton.ToolTipText = "Add a new employee";
        newButton.Click += newButton_Click;
        //
        // editButton
        //
        editButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        editButton.Font = new Font("Segoe UI", 9.75F);
        editButton.Image = (Image)resources.GetObject("editButton.Image");
        editButton.ImageTransparentColor = Color.Magenta;
        editButton.Margin = new Padding(0, 1, 4, 2);
        editButton.Name = "editButton";
        editButton.Padding = new Padding(6, 2, 6, 2);
        editButton.Size = new Size(43, 22);
        editButton.Text = "Edit";
        editButton.ToolTipText = "Edit the selected employee (or double-click a row)";
        editButton.Click += editButton_Click;
        //
        // deleteButton
        //
        deleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        deleteButton.Font = new Font("Segoe UI", 9.75F);
        deleteButton.ForeColor = Color.FromArgb(185, 28, 28);
        deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
        deleteButton.ImageTransparentColor = Color.Magenta;
        deleteButton.Margin = new Padding(0, 1, 4, 2);
        deleteButton.Name = "deleteButton";
        deleteButton.Padding = new Padding(6, 2, 6, 2);
        deleteButton.Size = new Size(56, 22);
        deleteButton.Text = "Delete";
        deleteButton.ToolTipText = "Delete the selected employee";
        deleteButton.Click += deleteButton_Click;
        //
        // refreshButton
        //
        refreshButton.Alignment = ToolStripItemAlignment.Right;
        refreshButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        refreshButton.Font = new Font("Segoe UI", 9.75F);
        refreshButton.Image = (Image)resources.GetObject("refreshButton.Image");
        refreshButton.ImageTransparentColor = Color.Magenta;
        refreshButton.Name = "refreshButton";
        refreshButton.Padding = new Padding(6, 2, 6, 2);
        refreshButton.Size = new Size(62, 22);
        refreshButton.Text = "Refresh";
        refreshButton.ToolTipText = "Reload the employee list";
        refreshButton.Click += refreshButton_Click;
        //
        // mainStatusStrip
        //
        mainStatusStrip.BackColor = Color.FromArgb(243, 244, 246);
        mainStatusStrip.Items.AddRange(new ToolStripItem[] { employeeCountLabel });
        mainStatusStrip.Location = new Point(0, 578);
        mainStatusStrip.Name = "mainStatusStrip";
        mainStatusStrip.Padding = new Padding(8, 0, 8, 0);
        mainStatusStrip.SizingGrip = false;
        mainStatusStrip.Size = new Size(1000, 22);
        mainStatusStrip.TabIndex = 2;
        //
        // employeeCountLabel
        //
        employeeCountLabel.ForeColor = Color.FromArgb(75, 85, 99);
        employeeCountLabel.Name = "employeeCountLabel";
        employeeCountLabel.Size = new Size(0, 17);
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1000, 600);
        Controls.Add(employeesGrid);
        Controls.Add(mainToolStrip);
        Controls.Add(mainStatusStrip);
        MinimumSize = new Size(720, 420);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Employee Management";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)employeesGrid).EndInit();
        mainToolStrip.ResumeLayout(false);
        mainToolStrip.PerformLayout();
        mainStatusStrip.ResumeLayout(false);
        mainStatusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView employeesGrid;
    private DataGridViewTextBoxColumn firstNameColumn;
    private DataGridViewTextBoxColumn lastNameColumn;
    private DataGridViewTextBoxColumn emailColumn;
    private DataGridViewTextBoxColumn departmentColumn;
    private DataGridViewTextBoxColumn entryDateColumn;
    private ToolStrip mainToolStrip;
    private ToolStripButton newButton;
    private ToolStripButton editButton;
    private ToolStripButton deleteButton;
    private ToolStripButton refreshButton;
    private StatusStrip mainStatusStrip;
    private ToolStripStatusLabel employeeCountLabel;
}
