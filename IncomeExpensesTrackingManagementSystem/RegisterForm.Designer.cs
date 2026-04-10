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
            register_loginBtn = new Button();
            label6 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            register_showPass = new CheckBox();
            register_btn = new Button();
            register_password = new TextBox();
            label5 = new Label();
            register_username = new TextBox();
            label4 = new Label();
            label3 = new Label();
            close_click = new Label();
            register_cPassword = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(register_loginBtn);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 450);
            panel1.TabIndex = 0;
            // 
            // register_loginBtn
            // 
            register_loginBtn.BackColor = Color.Green;
            register_loginBtn.FlatAppearance.MouseDownBackColor = Color.Green;
            register_loginBtn.FlatAppearance.MouseOverBackColor = Color.Green;
            register_loginBtn.FlatStyle = FlatStyle.Flat;
            register_loginBtn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            register_loginBtn.ForeColor = Color.White;
            register_loginBtn.Location = new Point(12, 382);
            register_loginBtn.Name = "register_loginBtn";
            register_loginBtn.Size = new Size(290, 45);
            register_loginBtn.TabIndex = 11;
            register_loginBtn.Text = "Sign In";
            register_loginBtn.UseVisualStyleBackColor = false;
            register_loginBtn.Click += RegisterLoginBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(113, 342);
            label6.Name = "label6";
            label6.Size = new Size(101, 24);
            label6.TabIndex = 10;
            label6.Text = "Login Here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 182);
            label2.Name = "label2";
            label2.Size = new Size(277, 24);
            label2.TabIndex = 3;
            label2.Text = "Income and Expenses Tracker";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_income_50;
            pictureBox1.Location = new Point(135, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // register_showPass
            // 
            register_showPass.AutoSize = true;
            register_showPass.Location = new Point(643, 345);
            register_showPass.Name = "register_showPass";
            register_showPass.Size = new Size(132, 24);
            register_showPass.TabIndex = 9;
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
            register_btn.Location = new Point(359, 382);
            register_btn.Name = "register_btn";
            register_btn.Size = new Size(101, 40);
            register_btn.TabIndex = 10;
            register_btn.Text = "Register";
            register_btn.UseVisualStyleBackColor = false;
            register_btn.Click += RegisterBtn_Click;
            // 
            // register_password
            // 
            register_password.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            register_password.Location = new Point(359, 222);
            register_password.Name = "register_password";
            register_password.PasswordChar = '*';
            register_password.Size = new Size(416, 33);
            register_password.TabIndex = 5;
            register_password.TextChanged += RegisterPasswordTextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(359, 199);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 6;
            label5.Text = "Password";
            label5.Click += Label5_Click;
            // 
            // register_username
            // 
            register_username.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            register_username.Location = new Point(359, 166);
            register_username.Name = "register_username";
            register_username.Size = new Size(416, 33);
            register_username.TabIndex = 4;
            register_username.TextChanged += RegisterUsernameTextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(359, 143);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 4;
            label4.Text = "Username";
            label4.Click += Label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(359, 98);
            label3.Name = "label3";
            label3.Size = new Size(84, 24);
            label3.TabIndex = 2;
            label3.Text = "Register";
            // 
            // close_click
            // 
            close_click.AutoSize = true;
            close_click.Cursor = Cursors.Hand;
            close_click.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close_click.Location = new Point(767, 9);
            close_click.Name = "close_click";
            close_click.Size = new Size(21, 21);
            close_click.TabIndex = 1;
            close_click.Text = "X";
            close_click.Click += CloseClick_Click;
            // 
            // register_cPassword
            // 
            register_cPassword.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            register_cPassword.Location = new Point(359, 306);
            register_cPassword.Name = "register_cPassword";
            register_cPassword.PasswordChar = '*';
            register_cPassword.Size = new Size(416, 33);
            register_cPassword.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(359, 283);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 8;
            label1.Text = "Confirm Password";
            label1.Click += Label1_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(register_cPassword);
            Controls.Add(register_showPass);
            Controls.Add(register_btn);
            Controls.Add(register_password);
            Controls.Add(label5);
            Controls.Add(register_username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(close_click);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
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