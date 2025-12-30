namespace FriendlyPasswordGenerator.Main;

partial class FormPasswordGenerator
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPasswordGenerator));
        MainTabControl = new TabControl();
        PasswordGeneratorTabPage = new TabPage();
        Label_CurrentPassword = new Label();
        groupBox1 = new GroupBox();
        CheckBox_AllowNonAsciiCaracters = new CheckBox();
        label2 = new Label();
        NumericPicker_MinimumLenght = new NumericUpDown();
        Button_GenerateNewPassword = new Button();
        PasswordHistoryTabPage = new TabPage();
        ListView_PasswordHistory = new ListView();
        MainTabControl.SuspendLayout();
        PasswordGeneratorTabPage.SuspendLayout();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NumericPicker_MinimumLenght).BeginInit();
        PasswordHistoryTabPage.SuspendLayout();
        SuspendLayout();
        // 
        // MainTabControl
        // 
        MainTabControl.Controls.Add(PasswordGeneratorTabPage);
        MainTabControl.Controls.Add(PasswordHistoryTabPage);
        MainTabControl.Dock = DockStyle.Fill;
        MainTabControl.Location = new Point(0, 0);
        MainTabControl.Name = "MainTabControl";
        MainTabControl.SelectedIndex = 0;
        MainTabControl.Size = new Size(684, 361);
        MainTabControl.TabIndex = 13;
        // 
        // PasswordGeneratorTabPage
        // 
        PasswordGeneratorTabPage.Controls.Add(Label_CurrentPassword);
        PasswordGeneratorTabPage.Controls.Add(groupBox1);
        PasswordGeneratorTabPage.Controls.Add(Button_GenerateNewPassword);
        PasswordGeneratorTabPage.Location = new Point(4, 24);
        PasswordGeneratorTabPage.Name = "PasswordGeneratorTabPage";
        PasswordGeneratorTabPage.Padding = new Padding(3);
        PasswordGeneratorTabPage.Size = new Size(676, 333);
        PasswordGeneratorTabPage.TabIndex = 0;
        PasswordGeneratorTabPage.Text = "Gerador";
        PasswordGeneratorTabPage.UseVisualStyleBackColor = true;
        // 
        // Label_CurrentPassword
        // 
        Label_CurrentPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        Label_CurrentPassword.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Label_CurrentPassword.Location = new Point(5, 6);
        Label_CurrentPassword.Name = "Label_CurrentPassword";
        Label_CurrentPassword.Size = new Size(665, 200);
        Label_CurrentPassword.TabIndex = 15;
        Label_CurrentPassword.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        groupBox1.Controls.Add(CheckBox_AllowNonAsciiCaracters);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(NumericPicker_MinimumLenght);
        groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        groupBox1.Location = new Point(380, 208);
        groupBox1.Margin = new Padding(2);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(2);
        groupBox1.Size = new Size(289, 120);
        groupBox1.TabIndex = 14;
        groupBox1.TabStop = false;
        groupBox1.Text = "Configurações da Senha";
        // 
        // CheckBox_AllowNonAsciiCaracters
        // 
        CheckBox_AllowNonAsciiCaracters.AutoSize = true;
        CheckBox_AllowNonAsciiCaracters.Checked = true;
        CheckBox_AllowNonAsciiCaracters.CheckState = CheckState.Checked;
        CheckBox_AllowNonAsciiCaracters.Location = new Point(12, 84);
        CheckBox_AllowNonAsciiCaracters.Margin = new Padding(2);
        CheckBox_AllowNonAsciiCaracters.Name = "CheckBox_AllowNonAsciiCaracters";
        CheckBox_AllowNonAsciiCaracters.Size = new Size(248, 29);
        CheckBox_AllowNonAsciiCaracters.TabIndex = 8;
        CheckBox_AllowNonAsciiCaracters.Text = "Somente Caractéres ASCII";
        CheckBox_AllowNonAsciiCaracters.UseVisualStyleBackColor = true;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.Location = new Point(12, 42);
        label2.Margin = new Padding(2, 0, 2, 0);
        label2.Name = "label2";
        label2.Size = new Size(159, 25);
        label2.TabIndex = 7;
        label2.Text = "Tamanho Mínimo";
        // 
        // NumericPicker_MinimumLenght
        // 
        NumericPicker_MinimumLenght.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        NumericPicker_MinimumLenght.Location = new Point(176, 39);
        NumericPicker_MinimumLenght.Margin = new Padding(2);
        NumericPicker_MinimumLenght.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        NumericPicker_MinimumLenght.Name = "NumericPicker_MinimumLenght";
        NumericPicker_MinimumLenght.Size = new Size(93, 33);
        NumericPicker_MinimumLenght.TabIndex = 6;
        NumericPicker_MinimumLenght.Value = new decimal(new int[] { 40, 0, 0, 0 });
        // 
        // Button_GenerateNewPassword
        // 
        Button_GenerateNewPassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        Button_GenerateNewPassword.BackColor = Color.PaleGreen;
        Button_GenerateNewPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Button_GenerateNewPassword.Location = new Point(5, 276);
        Button_GenerateNewPassword.Margin = new Padding(2);
        Button_GenerateNewPassword.Name = "Button_GenerateNewPassword";
        Button_GenerateNewPassword.Size = new Size(144, 50);
        Button_GenerateNewPassword.TabIndex = 13;
        Button_GenerateNewPassword.Text = "Gerar";
        Button_GenerateNewPassword.UseVisualStyleBackColor = false;
        // 
        // PasswordHistoryTabPage
        // 
        PasswordHistoryTabPage.Controls.Add(ListView_PasswordHistory);
        PasswordHistoryTabPage.Location = new Point(4, 24);
        PasswordHistoryTabPage.Name = "PasswordHistoryTabPage";
        PasswordHistoryTabPage.Padding = new Padding(3);
        PasswordHistoryTabPage.Size = new Size(626, 383);
        PasswordHistoryTabPage.TabIndex = 1;
        PasswordHistoryTabPage.Text = "Histórico";
        PasswordHistoryTabPage.UseVisualStyleBackColor = true;
        // 
        // ListView_PasswordHistory
        // 
        ListView_PasswordHistory.Dock = DockStyle.Fill;
        ListView_PasswordHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ListView_PasswordHistory.Location = new Point(3, 3);
        ListView_PasswordHistory.Name = "ListView_PasswordHistory";
        ListView_PasswordHistory.Size = new Size(620, 377);
        ListView_PasswordHistory.TabIndex = 0;
        ListView_PasswordHistory.UseCompatibleStateImageBehavior = false;
        ListView_PasswordHistory.View = System.Windows.Forms.View.List;
        // 
        // FormPasswordGenerator
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(684, 361);
        Controls.Add(MainTabControl);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(2);
        MinimumSize = new Size(700, 400);
        Name = "FormPasswordGenerator";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gerador de Senha Amigável";
        MainTabControl.ResumeLayout(false);
        PasswordGeneratorTabPage.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NumericPicker_MinimumLenght).EndInit();
        PasswordHistoryTabPage.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TabControl MainTabControl;
    private TabPage PasswordGeneratorTabPage;
    private GroupBox groupBox1;
    private CheckBox CheckBox_AllowNonAsciiCaracters;
    private Label label2;
    private NumericUpDown NumericPicker_MinimumLenght;
    private Button Button_GenerateNewPassword;
    private TabPage PasswordHistoryTabPage;
    private Label Label_CurrentPassword;
    private ListView ListView_PasswordHistory;
}