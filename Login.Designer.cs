namespace VersionOfProject
{
    partial class Login
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
            lab_Name = new Label();
            lab_pass = new Label();
            txt_Email = new TextBox();
            txt_Password = new TextBox();
            btn_login = new Button();
            CheckShowPassword = new CheckBox();
            SuspendLayout();
            // 
            // lab_Name
            // 
            lab_Name.AutoSize = true;
            lab_Name.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lab_Name.ForeColor = Color.White;
            lab_Name.Location = new Point(94, 99);
            lab_Name.Margin = new Padding(5, 0, 5, 0);
            lab_Name.Name = "lab_Name";
            lab_Name.Size = new Size(84, 31);
            lab_Name.TabIndex = 0;
            lab_Name.Text = "Email";
            // 
            // lab_pass
            // 
            lab_pass.AutoSize = true;
            lab_pass.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lab_pass.ForeColor = Color.White;
            lab_pass.Location = new Point(94, 154);
            lab_pass.Margin = new Padding(5, 0, 5, 0);
            lab_pass.Name = "lab_pass";
            lab_pass.Size = new Size(127, 31);
            lab_pass.TabIndex = 1;
            lab_pass.Text = "Password";
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(248, 91);
            txt_Email.Margin = new Padding(5, 6, 5, 6);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(304, 42);
            txt_Email.TabIndex = 2;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(248, 154);
            txt_Password.Margin = new Padding(5, 6, 5, 6);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(304, 42);
            txt_Password.TabIndex = 3;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.Tan;
            btn_login.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_login.ForeColor = Color.White;
            btn_login.Location = new Point(319, 276);
            btn_login.Margin = new Padding(5, 6, 5, 6);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(129, 46);
            btn_login.TabIndex = 4;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // CheckShowPassword
            // 
            CheckShowPassword.AutoSize = true;
            CheckShowPassword.Location = new Point(248, 205);
            CheckShowPassword.Name = "CheckShowPassword";
            CheckShowPassword.Size = new Size(211, 41);
            CheckShowPassword.TabIndex = 5;
            CheckShowPassword.Text = "Show Pasword";
            CheckShowPassword.UseVisualStyleBackColor = true;
            CheckShowPassword.CheckedChanged += CheckShowPassword_CheckedChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(159, 111, 79);
            ClientSize = new Size(674, 409);
            Controls.Add(CheckShowPassword);
            Controls.Add(btn_login);
            Controls.Add(txt_Password);
            Controls.Add(txt_Email);
            Controls.Add(lab_pass);
            Controls.Add(lab_Name);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lab_Name;
        private Label lab_pass;
        private TextBox txt_Email;
        private TextBox txt_Password;
        private Button btn_login;
        private CheckBox CheckShowPassword;
    }
}