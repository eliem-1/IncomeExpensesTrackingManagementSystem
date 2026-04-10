namespace IncomeExpensesTrackingManagementSystem
{
    partial class MainForm
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            close_click = new Label();
            panel2 = new Panel();
            logout_btn = new Button();
            expenses_btn = new Button();
            dashboard_btn = new Button();
            addCategory_btn = new Button();
            income_btn = new Button();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            incomeForm1 = new IncomeForm();
            categoryForm1 = new CategoryForm();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(close_click);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1684, 60);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_income_50;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 70);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 16);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(269, 21);
            label1.TabIndex = 3;
            label1.Text = "Income and Expense Tracker";
            // 
            // close_click
            // 
            close_click.AutoSize = true;
            close_click.Cursor = Cursors.Hand;
            close_click.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close_click.Location = new Point(1651, 11);
            close_click.Margin = new Padding(4, 0, 4, 0);
            close_click.Name = "close_click";
            close_click.Size = new Size(21, 21);
            close_click.TabIndex = 2;
            close_click.Text = "X";
            close_click.Click += CloseClick_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Green;
            panel2.Controls.Add(logout_btn);
            panel2.Controls.Add(expenses_btn);
            panel2.Controls.Add(dashboard_btn);
            panel2.Controls.Add(addCategory_btn);
            panel2.Controls.Add(income_btn);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 60);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 620);
            panel2.TabIndex = 1;
            // 
            // logout_btn
            // 
            logout_btn.BackColor = Color.Green;
            logout_btn.FlatAppearance.BorderSize = 0;
            logout_btn.FlatStyle = FlatStyle.Flat;
            logout_btn.ForeColor = Color.White;
            logout_btn.Location = new Point(12, 568);
            logout_btn.Name = "logout_btn";
            logout_btn.Size = new Size(201, 40);
            logout_btn.TabIndex = 9;
            logout_btn.Text = "Logout";
            logout_btn.UseVisualStyleBackColor = false;
            logout_btn.Click += LogoutBtn_Click;
            // 
            // expenses_btn
            // 
            expenses_btn.BackColor = Color.Green;
            expenses_btn.FlatAppearance.BorderSize = 0;
            expenses_btn.FlatStyle = FlatStyle.Flat;
            expenses_btn.ForeColor = Color.White;
            expenses_btn.Location = new Point(16, 322);
            expenses_btn.Name = "expenses_btn";
            expenses_btn.Size = new Size(201, 40);
            expenses_btn.TabIndex = 6;
            expenses_btn.Text = "Expenses";
            expenses_btn.UseVisualStyleBackColor = false;
            // 
            // dashboard_btn
            // 
            dashboard_btn.BackColor = Color.Green;
            dashboard_btn.FlatAppearance.BorderSize = 0;
            dashboard_btn.FlatStyle = FlatStyle.Flat;
            dashboard_btn.ForeColor = Color.White;
            dashboard_btn.Location = new Point(16, 184);
            dashboard_btn.Name = "dashboard_btn";
            dashboard_btn.Size = new Size(201, 40);
            dashboard_btn.TabIndex = 4;
            dashboard_btn.Text = "Dashboard";
            dashboard_btn.UseVisualStyleBackColor = false;
            // 
            // addCategory_btn
            // 
            addCategory_btn.BackColor = Color.Green;
            addCategory_btn.FlatAppearance.BorderSize = 0;
            addCategory_btn.FlatStyle = FlatStyle.Flat;
            addCategory_btn.ForeColor = Color.White;
            addCategory_btn.Location = new Point(16, 230);
            addCategory_btn.Name = "addCategory_btn";
            addCategory_btn.Size = new Size(201, 40);
            addCategory_btn.TabIndex = 8;
            addCategory_btn.Text = "Add Category";
            addCategory_btn.UseVisualStyleBackColor = false;
            addCategory_btn.Click += AddCategoryBtn_Click;
            // 
            // income_btn
            // 
            income_btn.BackColor = Color.Green;
            income_btn.FlatAppearance.BorderSize = 0;
            income_btn.FlatStyle = FlatStyle.Flat;
            income_btn.ForeColor = Color.White;
            income_btn.Location = new Point(16, 276);
            income_btn.Name = "income_btn";
            income_btn.Size = new Size(201, 40);
            income_btn.TabIndex = 7;
            income_btn.Text = "Income";
            income_btn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 121);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(98, 24);
            label2.TabIndex = 3;
            label2.Text = "Welcome,";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_income_50;
            pictureBox2.Location = new Point(55, 31);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 76);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // incomeForm1
            // 
            incomeForm1.Location = new Point(317, 208);
            incomeForm1.Margin = new Padding(4);
            incomeForm1.Name = "incomeForm1";
            incomeForm1.Size = new Size(2500, 930);
            incomeForm1.TabIndex = 5;
            incomeForm1.Load += incomeForm1_Load;
            // 
            // categoryForm1
            // 
            categoryForm1.Location = new Point(238, 208);
            categoryForm1.Margin = new Padding(4);
            categoryForm1.Name = "categoryForm1";
            categoryForm1.Size = new Size(2500, 930);
            categoryForm1.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 680);
            Controls.Add(categoryForm1);
            Controls.Add(incomeForm1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label close_click;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label2;
        private Button logout_btn;
        private Button expenses_btn;
        private Button dashboard_btn;
        private Button addCategory_btn;
        private Button income_btn;
        private IncomeForm incomeForm1;
        private CategoryForm categoryForm1;
    }
}