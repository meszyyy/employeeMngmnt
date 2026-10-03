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
        ((System.ComponentModel.ISupportInitialize)employeesGrid).BeginInit();
        mainToolStrip.SuspendLayout();
        SuspendLayout();
        // 
        // employeesGrid
        // 
        employeesGrid.AllowUserToAddRows = false;
        dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
        employeesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        employeesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        employeesGrid.Columns.AddRange(new DataGridViewColumn[] { firstNameColumn, lastNameColumn, emailColumn, departmentColumn, entryDateColumn });
        employeesGrid.Dock = DockStyle.Fill;
        employeesGrid.Location = new Point(0, 25);
        employeesGrid.Name = "employeesGrid";
        employeesGrid.ReadOnly = true;
        employeesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        employeesGrid.Size = new Size(800, 425);
        employeesGrid.TabIndex = 0;
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
        dataGridViewCellStyle2.Format = "d";
        dataGridViewCellStyle2.NullValue = null;
        entryDateColumn.DefaultCellStyle = dataGridViewCellStyle2;
        entryDateColumn.HeaderText = "Date of entry";
        entryDateColumn.Name = "entryDateColumn";
        entryDateColumn.ReadOnly = true;
        // 
        // mainToolStrip
        // 
        mainToolStrip.Items.AddRange(new ToolStripItem[] { newButton, editButton, deleteButton, refreshButton });
        mainToolStrip.Location = new Point(0, 0);
        mainToolStrip.Name = "mainToolStrip";
        mainToolStrip.Size = new Size(800, 25);
        mainToolStrip.TabIndex = 1;
        mainToolStrip.Text = "toolStrip1";
        // 
        // newButton
        // 
        newButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        newButton.Image = (Image)resources.GetObject("newButton.Image");
        newButton.ImageTransparentColor = Color.Magenta;
        newButton.Name = "newButton";
        newButton.Size = new Size(35, 22);
        newButton.Text = "New";
        // 
        // editButton
        // 
        editButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        editButton.Image = (Image)resources.GetObject("editButton.Image");
        editButton.ImageTransparentColor = Color.Magenta;
        editButton.Name = "editButton";
        editButton.Size = new Size(31, 22);
        editButton.Text = "Edit";
        // 
        // deleteButton
        // 
        deleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
        deleteButton.ImageTransparentColor = Color.Magenta;
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new Size(44, 22);
        deleteButton.Text = "Delete";
        // 
        // refreshButton
        // 
        refreshButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        refreshButton.Image = (Image)resources.GetObject("refreshButton.Image");
        refreshButton.ImageTransparentColor = Color.Magenta;
        refreshButton.Name = "refreshButton";
        refreshButton.Size = new Size(50, 22);
        refreshButton.Text = "Refresh";
        refreshButton.Click += refreshButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(employeesGrid);
        Controls.Add(mainToolStrip);
        Name = "MainForm";
        Text = "Employee Management";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)employeesGrid).EndInit();
        mainToolStrip.ResumeLayout(false);
        mainToolStrip.PerformLayout();
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
}
