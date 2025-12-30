namespace FriendlyPasswordGenerator.Main;

partial class ListViewer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        MainDataGridView = new DataGridView();
        Password = new DataGridViewTextBoxColumn();
        bindingSource1 = new BindingSource(components);
        listView1 = new ListView();
        ((System.ComponentModel.ISupportInitialize)MainDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        SuspendLayout();
        // 
        // MainDataGridView
        // 
        MainDataGridView.AllowUserToAddRows = false;
        MainDataGridView.AllowUserToDeleteRows = false;
        MainDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        MainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        MainDataGridView.ColumnHeadersVisible = false;
        MainDataGridView.Columns.AddRange(new DataGridViewColumn[] { Password });
        MainDataGridView.Location = new Point(12, 284);
        MainDataGridView.Name = "MainDataGridView";
        MainDataGridView.ReadOnly = true;
        MainDataGridView.RowHeadersVisible = false;
        MainDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        MainDataGridView.Size = new Size(776, 163);
        MainDataGridView.TabIndex = 0;
        // 
        // Password
        // 
        Password.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        Password.HeaderText = "Senha";
        Password.Name = "Password";
        Password.ReadOnly = true;
        // 
        // listView1
        // 
        listView1.Location = new Point(12, 12);
        listView1.Name = "listView1";
        listView1.Size = new Size(776, 266);
        listView1.TabIndex = 1;
        listView1.UseCompatibleStateImageBehavior = false;
        // 
        // ListViewer
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(listView1);
        Controls.Add(MainDataGridView);
        Name = "ListViewer";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Password History";
        ((System.ComponentModel.ISupportInitialize)MainDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView MainDataGridView;
    private BindingSource bindingSource1;
    private DataGridViewTextBoxColumn Password;
    private ListView listView1;
}