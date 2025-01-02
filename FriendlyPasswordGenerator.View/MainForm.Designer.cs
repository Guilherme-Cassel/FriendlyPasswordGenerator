namespace FriendlyPasswordGenerator.View;

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
        Button_GenerateNewPassword = new Button();
        NumericPicker_AmountOfWords = new NumericUpDown();
        label1 = new Label();
        groupBox1 = new GroupBox();
        CheckBox_AllowNonAsciiCaracters = new CheckBox();
        label2 = new Label();
        NumericPicker_MinimumLenght = new NumericUpDown();
        Button_PasswordHistory = new Button();
        Label_CurrentPassword = new Label();
        ((System.ComponentModel.ISupportInitialize)NumericPicker_AmountOfWords).BeginInit();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NumericPicker_MinimumLenght).BeginInit();
        SuspendLayout();
        // 
        // Button_GenerateNewPassword
        // 
        Button_GenerateNewPassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        Button_GenerateNewPassword.BackColor = Color.PaleGreen;
        Button_GenerateNewPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Button_GenerateNewPassword.Location = new Point(33, 207);
        Button_GenerateNewPassword.Name = "Button_GenerateNewPassword";
        Button_GenerateNewPassword.Size = new Size(180, 60);
        Button_GenerateNewPassword.TabIndex = 1;
        Button_GenerateNewPassword.Text = "Generate New Password";
        Button_GenerateNewPassword.UseVisualStyleBackColor = false;
        // 
        // NumericPicker_AmountOfWords
        // 
        NumericPicker_AmountOfWords.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        NumericPicker_AmountOfWords.Location = new Point(17, 62);
        NumericPicker_AmountOfWords.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        NumericPicker_AmountOfWords.Name = "NumericPicker_AmountOfWords";
        NumericPicker_AmountOfWords.Size = new Size(120, 33);
        NumericPicker_AmountOfWords.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(17, 34);
        label1.Name = "label1";
        label1.Size = new Size(163, 25);
        label1.TabIndex = 5;
        label1.Text = "Amount Of Words";
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        groupBox1.Controls.Add(CheckBox_AllowNonAsciiCaracters);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(NumericPicker_MinimumLenght);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(NumericPicker_AmountOfWords);
        groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        groupBox1.Location = new Point(243, 191);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(465, 152);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        groupBox1.Text = "Settings";
        // 
        // CheckBox_AllowNonAsciiCaracters
        // 
        CheckBox_AllowNonAsciiCaracters.AutoSize = true;
        CheckBox_AllowNonAsciiCaracters.Checked = true;
        CheckBox_AllowNonAsciiCaracters.CheckState = CheckState.Checked;
        CheckBox_AllowNonAsciiCaracters.Location = new Point(17, 108);
        CheckBox_AllowNonAsciiCaracters.Name = "CheckBox_AllowNonAsciiCaracters";
        CheckBox_AllowNonAsciiCaracters.Size = new Size(255, 29);
        CheckBox_AllowNonAsciiCaracters.TabIndex = 8;
        CheckBox_AllowNonAsciiCaracters.Text = "Allow Non-ASCII Caracters";
        CheckBox_AllowNonAsciiCaracters.UseVisualStyleBackColor = true;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.Location = new Point(240, 34);
        label2.Name = "label2";
        label2.Size = new Size(156, 25);
        label2.TabIndex = 7;
        label2.Text = "Minimum Lenght";
        // 
        // NumericPicker_MinimumLenght
        // 
        NumericPicker_MinimumLenght.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        NumericPicker_MinimumLenght.Location = new Point(240, 62);
        NumericPicker_MinimumLenght.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        NumericPicker_MinimumLenght.Name = "NumericPicker_MinimumLenght";
        NumericPicker_MinimumLenght.Size = new Size(120, 33);
        NumericPicker_MinimumLenght.TabIndex = 6;
        // 
        // Button_PasswordHistory
        // 
        Button_PasswordHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        Button_PasswordHistory.BackColor = Color.Khaki;
        Button_PasswordHistory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Button_PasswordHistory.Location = new Point(33, 284);
        Button_PasswordHistory.Name = "Button_PasswordHistory";
        Button_PasswordHistory.Size = new Size(180, 60);
        Button_PasswordHistory.TabIndex = 7;
        Button_PasswordHistory.Text = "Password History";
        Button_PasswordHistory.UseVisualStyleBackColor = false;
        // 
        // Label_CurrentPassword
        // 
        Label_CurrentPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        Label_CurrentPassword.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Label_CurrentPassword.Location = new Point(12, 9);
        Label_CurrentPassword.Name = "Label_CurrentPassword";
        Label_CurrentPassword.Size = new Size(696, 179);
        Label_CurrentPassword.TabIndex = 8;
        Label_CurrentPassword.Text = "Waiting for Generation...";
        Label_CurrentPassword.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.AliceBlue;
        ClientSize = new Size(720, 356);
        Controls.Add(Label_CurrentPassword);
        Controls.Add(Button_PasswordHistory);
        Controls.Add(groupBox1);
        Controls.Add(Button_GenerateNewPassword);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)NumericPicker_AmountOfWords).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NumericPicker_MinimumLenght).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private Button Button_GenerateNewPassword;
    private NumericUpDown NumericPicker_AmountOfWords;
    private Label label1;
    private GroupBox groupBox1;
    private CheckBox CheckBox_AllowNonAsciiCaracters;
    private Label label2;
    private NumericUpDown NumericPicker_MinimumLenght;
    private Button Button_PasswordHistory;
    private Label Label_CurrentPassword;
}
