namespace IncomeExpensesTrackingManagementSystem
{
    partial class RegisterForm
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
            panel1 = new Panel();
            close_click = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            register_username = new TextBox();
            label5 = new Label();
            register_password = new TextBox();
            label1 = new Label();
            register_cPassword = new TextBox();
            register_showPass = new CheckBox();
            register_btn = new Button();
            label6 = new Label();
            register_loginBtn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(close_click);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 60);
            panel1.TabIndex = 0;
            // 
            // close_click
            // 
            close_click.AutoSize = true;
            close_click.Cursor = Cursors.Hand;
            close_click.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close_click.ForeColor = Color.White;
            close_click.Location = new Point(870, 16);
            close_click.Name = "close_click";
            close_click.Size = new Size(21, 21);
            close_click.TabIndex = 0;
            close_click.Text = "X";
            close_click.Click += CloseClick_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_income_50;
            pictureBox1.Location = new Point(10, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(65, 16);
            label2.Name = "label2";
            label2.Size = new Size(269, 21);
            label2.TabIndex = 2;
            label2.Text = "Income and Expenses Tracker";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(350, 75);
            label3.Name = "label3";
            label3.Size = new Size(200, 33);
            label3.TabIndex = 1;
            label3.Text = "Register";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 125);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 2;
            label4.Text = "Username:";
            label4.Click += Label4_Click;
            // 
            // register_username
            // 
            register_username.Location = new Point(300, 150);
            register_username.Name = "register_username";
            register_username.Size = new Size(300, 27);
            register_username.TabIndex = 3;
            register_username.TextChanged += RegisterUsernameTextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(300, 190);
            label5.Name = "label5";
            label5.Size = new Size(80, 21);
            label5.TabIndex = 4;
            label5.Text = "Password:";
            label5.Click += Label5_Click;
            // 
            // register_password
            // 
            register_password.Location = new Point(300, 215);
            register_password.Name = "register_password";
            register_password.PasswordChar = '*';
            register_password.Size = new Size(300, 27);
            register_password.TabIndex = 5;
            register_password.TextChanged += RegisterPasswordTextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 255);
            label1.Name = "label1";
            label1.Size = new Size(142, 21);
            label1.TabIndex = 6;
            label1.Text = "Confirm Password:";
            label1.Click += Label1_Click;
            // 
            // register_cPassword
            // 
            register_cPassword.Location = new Point(300, 280);
            register_cPassword.Name = "register_cPassword";
            register_cPassword.PasswordChar = '*';
            register_cPassword.Size = new Size(300, 27);
            register_cPassword.TabIndex = 7;
            // 
            // register_showPass
            // 
            register_showPass.AutoSize = true;
            register_showPass.Location = new Point(300, 315);
            register_showPass.Name = "register_showPass";
            register_showPass.Size = new Size(132, 24);
            register_showPass.TabIndex = 8;
            register_showPass.Text = "Show Password";
            register_showPass.UseVisualStyleBackColor = true;
            register_showPass.CheckedChanged += RegisterShowPassCheckedChanged;
            // 
            // register_btn
            // 
            register_btn.BackColor = Color.Green;
            register_btn.FlatAppearance.BorderSize = 0;
            register_btn.FlatAppearance.MouseDownBackColor = Color.Green;
            register_btn.FlatAppearance.MouseOverBackColor = Color.Green;
            register_btn.FlatStyle = FlatStyle.Flat;
            register_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            register_btn.ForeColor = Color.White;
            register_btn.Location = new Point(300, 350);
            register_btn.Name = "register_btn";
            register_btn.Size = new Size(300, 40);
            register_btn.TabIndex = 9;
            register_btn.Text = "Register";
            register_btn.UseVisualStyleBackColor = false;
            register_btn.Click += RegisterBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(325, 405);
            label6.Name = "label6";
            label6.Size = new Size(170, 20);
            label6.TabIndex = 10;
            label6.Text = "Already have an account?";
            // 
            // register_loginBtn
            // 
            register_loginBtn.BackColor = Color.Green;
            register_loginBtn.FlatAppearance.BorderSize = 0;
            register_loginBtn.FlatAppearance.MouseDownBackColor = Color.Green;
            register_loginBtn.FlatAppearance.MouseOverBackColor = Color.Green;
            register_loginBtn.FlatStyle = FlatStyle.Flat;
            register_loginBtn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            register_loginBtn.ForeColor = Color.White;
            register_loginBtn.Location = new Point(370, 430);
            register_loginBtn.Name = "register_loginBtn";
            register_loginBtn.Size = new Size(150, 35);
            register_loginBtn.TabIndex = 11;
            register_loginBtn.Text = "Sign In";
            register_loginBtn.UseVisualStyleBackColor = false;
            register_loginBtn.Click += RegisterLoginBtn_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 500);
            Controls.Add(register_loginBtn);
            Controls.Add(label6);
            Controls.Add(register_btn);
            Controls.Add(register_showPass);
            Controls.Add(register_cPassword);
            Controls.Add(label1);
            Controls.Add(register_password);
            Controls.Add(label5);
            Controls.Add(register_username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Income & Expenses Tracker - Register";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button register_loginBtn;
        private Label label6;
        private Label label2;
        private PictureBox pictureBox1;
        private CheckBox register_showPass;
        private Button register_btn;
        private TextBox register_password;
        private Label label5;
        private TextBox register_username;
        private Label label4;
        private Label label3;
        private Label close_click;
        private TextBox register_cPassword;
        private Label label1;
    }
}