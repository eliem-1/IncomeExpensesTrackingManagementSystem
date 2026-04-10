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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            login_SignUpBtn = new Button();
            label6 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            close_click = new Label();
            label3 = new Label();
            label4 = new Label();
            login_username = new TextBox();
            label5 = new Label();
            login_password = new TextBox();
            login_btn = new Button();
            login_showPass = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(login_SignUpBtn);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 450);
            panel1.TabIndex = 0;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(Panel1_Paint);
            // 
            // login_SignUpBtn
            // 
            login_SignUpBtn.BackColor = Color.Green;
            login_SignUpBtn.FlatAppearance.MouseDownBackColor = Color.Green;
            login_SignUpBtn.FlatAppearance.MouseOverBackColor = Color.Green;
            login_SignUpBtn.FlatStyle = FlatStyle.Flat;
            login_SignUpBtn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_SignUpBtn.ForeColor = Color.White;
            login_SignUpBtn.Location = new Point(12, 382);
            login_SignUpBtn.Name = "login_SignUpBtn";
            login_SignUpBtn.Size = new Size(290, 45);
            login_SignUpBtn.TabIndex = 9;
            login_SignUpBtn.Text = "Sign Up";
            login_SignUpBtn.UseVisualStyleBackColor = false;
            login_SignUpBtn.Click += new System.EventHandler(LoginSignUpBtn_Click);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(97, 342);
            label6.Name = "label6";
            label6.Size = new Size(132, 24);
            label6.TabIndex = 9;
            label6.Text = "Register Here";
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
            close_click.Click += new System.EventHandler(Label1_Click);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(359, 98);
            label3.Name = "label3";
            label3.Size = new Size(72, 24);
            label3.TabIndex = 2;
            label3.Text = "Sign In";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(359, 171);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // login_username
            // 
            login_username.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_username.Location = new Point(359, 194);
            login_username.Name = "login_username";
            login_username.Size = new Size(416, 33);
            login_username.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(359, 262);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 5;
            label5.Text = "Password";
            // 
            // login_password
            // 
            login_password.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_password.Location = new Point(359, 306);
            login_password.Name = "login_password";
            login_password.PasswordChar = '*';
            login_password.Size = new Size(416, 33);
            login_password.TabIndex = 6;
            login_password.TextChanged += new System.EventHandler(LoginPasswordTextChanged);
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
            login_btn.Location = new Point(359, 373);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(101, 40);
            login_btn.TabIndex = 7;
            login_btn.Text = "Login";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += new System.EventHandler(LoginBtn_Click);
            // 
            // login_showPass
            // 
            login_showPass.AutoSize = true;
            login_showPass.Location = new Point(643, 345);
            login_showPass.Name = "login_showPass";
            login_showPass.Size = new Size(132, 24);
            login_showPass.TabIndex = 8;
            login_showPass.Text = "Show Password";
            login_showPass.UseVisualStyleBackColor = true;
            login_showPass.CheckedChanged += new System.EventHandler(LoginShowPassCheckedChanged);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(login_showPass);
            Controls.Add(login_btn);
            Controls.Add(login_password);
            Controls.Add(label5);
            Controls.Add(login_username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(close_click);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += new System.EventHandler(Form1_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
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
