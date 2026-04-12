namespace IncomeExpensesTrackingManagementSystem
{
    partial class Form1
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
            login_username = new TextBox();
            label5 = new Label();
            login_password = new TextBox();
            login_btn = new Button();
            login_showPass = new CheckBox();
            login_SignUpBtn = new Button();
            label6 = new Label();
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
            close_click.Click += Label1_Click;
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
            label3.Location = new Point(350, 80);
            label3.Name = "label3";
            label3.Size = new Size(200, 30);
            label3.TabIndex = 1;
            label3.Text = "Login";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 140);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 2;
            label4.Text = "Username:";
            // 
            // login_username
            // 
            login_username.Location = new Point(300, 165);
            login_username.Name = "login_username";
            login_username.Size = new Size(300, 27);
            login_username.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(300, 210);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 4;
            label5.Text = "Password:";
            // 
            // login_password
            // 
            login_password.Location = new Point(300, 235);
            login_password.Name = "login_password";
            login_password.PasswordChar = '*';
            login_password.Size = new Size(300, 27);
            login_password.TabIndex = 5;
            login_password.TextChanged += LoginPasswordTextChanged;
            // 
            // login_showPass
            // 
            login_showPass.AutoSize = true;
            login_showPass.Location = new Point(300, 270);
            login_showPass.Name = "login_showPass";
            login_showPass.Size = new Size(120, 24);
            login_showPass.TabIndex = 6;
            login_showPass.Text = "Show Password";
            login_showPass.UseVisualStyleBackColor = true;
            login_showPass.CheckedChanged += LoginShowPassCheckedChanged;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.Green;
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatAppearance.MouseDownBackColor = Color.Green;
            login_btn.FlatAppearance.MouseOverBackColor = Color.Green;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(300, 310);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(300, 40);
            login_btn.TabIndex = 7;
            login_btn.Text = "Login";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += LoginBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(330, 365);
            label6.Name = "label6";
            label6.Size = new Size(150, 20);
            label6.TabIndex = 8;
            label6.Text = "Don't have an account?";
            // 
            // login_SignUpBtn
            // 
            login_SignUpBtn.BackColor = Color.Green;
            login_SignUpBtn.FlatAppearance.BorderSize = 0;
            login_SignUpBtn.FlatAppearance.MouseDownBackColor = Color.Green;
            login_SignUpBtn.FlatAppearance.MouseOverBackColor = Color.Green;
            login_SignUpBtn.FlatStyle = FlatStyle.Flat;
            login_SignUpBtn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_SignUpBtn.ForeColor = Color.White;
            login_SignUpBtn.Location = new Point(370, 390);
            login_SignUpBtn.Name = "login_SignUpBtn";
            login_SignUpBtn.Size = new Size(150, 35);
            login_SignUpBtn.TabIndex = 9;
            login_SignUpBtn.Text = "Sign Up";
            login_SignUpBtn.UseVisualStyleBackColor = false;
            login_SignUpBtn.Click += LoginSignUpBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 500);
            Controls.Add(login_SignUpBtn);
            Controls.Add(label6);
            Controls.Add(login_btn);
            Controls.Add(login_showPass);
            Controls.Add(login_password);
            Controls.Add(label5);
            Controls.Add(login_username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Income & Expenses Tracker - Login";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label close_click;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox login_username;
        private Label label5;
        private TextBox login_password;
        private Button login_btn;
        private CheckBox login_showPass;
        private Button login_SignUpBtn;
        private Label label6;
    }
}
