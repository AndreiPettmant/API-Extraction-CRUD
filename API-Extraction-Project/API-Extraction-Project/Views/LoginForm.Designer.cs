
namespace API_Extraction_Project
{
    partial class LoginForm
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
            lblUser = new Label();
            txtUserInput = new TextBox();
            lblPassword = new Label();
            txtPasswordInput = new TextBox();
            btnLogin = new Button();
            cbServers = new ComboBox();
            txtServers = new Label();
            chkBoxServerName = new CheckBox();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.BackColor = SystemColors.Control;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(12, 15);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(45, 21);
            lblUser.TabIndex = 0;
            lblUser.Text = "User:";
            // 
            // txtUserInput
            // 
            txtUserInput.Location = new Point(12, 39);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(200, 23);
            txtUserInput.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(12, 65);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtPasswordInput
            // 
            txtPasswordInput.Location = new Point(12, 89);
            txtPasswordInput.Name = "txtPasswordInput";
            txtPasswordInput.Size = new Size(200, 23);
            txtPasswordInput.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(129, 193);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(83, 42);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // cbServers
            // 
            cbServers.FormattingEnabled = true;
            cbServers.Location = new Point(12, 141);
            cbServers.Name = "cbServers";
            cbServers.Size = new Size(200, 23);
            cbServers.TabIndex = 5;
            // 
            // txtServers
            // 
            txtServers.AutoSize = true;
            txtServers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtServers.Location = new Point(12, 117);
            txtServers.Name = "txtServers";
            txtServers.Size = new Size(58, 21);
            txtServers.TabIndex = 6;
            txtServers.Text = "Server:";
            // 
            // chkBoxServerName
            // 
            chkBoxServerName.AutoSize = true;
            chkBoxServerName.Checked = true;
            chkBoxServerName.CheckState = CheckState.Checked;
            chkBoxServerName.Location = new Point(90, 170);
            chkBoxServerName.Name = "chkBoxServerName";
            chkBoxServerName.Size = new Size(122, 19);
            chkBoxServerName.TabIndex = 7;
            chkBoxServerName.Text = "Show server name";
            chkBoxServerName.UseVisualStyleBackColor = true;
            chkBoxServerName.CheckedChanged += chkBoxServerName_CheckedChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 247);
            Controls.Add(chkBoxServerName);
            Controls.Add(txtServers);
            Controls.Add(cbServers);
            Controls.Add(btnLogin);
            Controls.Add(txtPasswordInput);
            Controls.Add(lblPassword);
            Controls.Add(txtUserInput);
            Controls.Add(lblUser);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private TextBox txtUserInput;
        private Label lblPassword;
        private TextBox txtPasswordInput;
        private Button btnLogin;
        private ComboBox cbServers;
        private Label txtServers;
        private CheckBox chkBoxServerName;
    }
}
