namespace FriendlyPasswordGenerator.Main
{
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
            DataGridView_Main = new DataGridView();
            Button_GenerateNewPassword = new Button();
            Password = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DataGridView_Main).BeginInit();
            SuspendLayout();
            // 
            // DataGridView_Main
            // 
            DataGridView_Main.AllowUserToAddRows = false;
            DataGridView_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView_Main.Columns.AddRange(new DataGridViewColumn[] { Password });
            DataGridView_Main.Location = new Point(12, 212);
            DataGridView_Main.Name = "DataGridView_Main";
            DataGridView_Main.ReadOnly = true;
            DataGridView_Main.RowHeadersVisible = false;
            DataGridView_Main.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DataGridView_Main.Size = new Size(696, 226);
            DataGridView_Main.TabIndex = 0;
            // 
            // Button_GenerateNewPassword
            // 
            Button_GenerateNewPassword.Location = new Point(12, 12);
            Button_GenerateNewPassword.Name = "Button_GenerateNewPassword";
            Button_GenerateNewPassword.Size = new Size(179, 64);
            Button_GenerateNewPassword.TabIndex = 1;
            Button_GenerateNewPassword.Text = "Generate New Password";
            Button_GenerateNewPassword.UseVisualStyleBackColor = true;
            // 
            // Password
            // 
            Password.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Password.HeaderText = "Password";
            Password.Name = "Password";
            Password.ReadOnly = true;
            Password.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 450);
            Controls.Add(Button_GenerateNewPassword);
            Controls.Add(DataGridView_Main);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DataGridView_Main).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridView_Main;
        private Button Button_GenerateNewPassword;
        private DataGridViewTextBoxColumn Password;
    }
}
