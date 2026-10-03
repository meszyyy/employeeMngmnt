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
        employeesGrid = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)employeesGrid).BeginInit();
        SuspendLayout();
        // 
        // employeesGrid
        // 
        employeesGrid.AllowUserToAddRows = false;
        employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        employeesGrid.Dock = DockStyle.Fill;
        employeesGrid.Location = new Point(0, 0);
        employeesGrid.Name = "employeesGrid";
        employeesGrid.ReadOnly = true;
        employeesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        employeesGrid.Size = new Size(800, 450);
        employeesGrid.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(employeesGrid);
        Name = "MainForm";
        Text = "Form1";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)employeesGrid).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView employeesGrid;
}
