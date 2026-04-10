namespace IncomeExpensesTrackingManagementSystem
{
    partial class CategoryForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            category_deleteBtn = new Button();
            category_clearBtn = new Button();
            category_updateBtn = new Button();
            category_addBtn = new Button();
            category_status = new ComboBox();
            label3 = new Label();
            category_type = new ComboBox();
            label2 = new Label();
            category_category = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(category_deleteBtn);
            panel1.Controls.Add(category_clearBtn);
            panel1.Controls.Add(category_updateBtn);
            panel1.Controls.Add(category_addBtn);
            panel1.Controls.Add(category_status);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(category_type);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(category_category);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(19, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 552);
            panel1.TabIndex = 0;
            panel1.Paint += Panel1_Paint;
            // 
            // category_deleteBtn
            // 
            category_deleteBtn.BackColor = Color.Green;
            category_deleteBtn.FlatAppearance.BorderSize = 0;
            category_deleteBtn.FlatStyle = FlatStyle.Flat;
            category_deleteBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_deleteBtn.ForeColor = Color.White;
            category_deleteBtn.Location = new Point(232, 331);
            category_deleteBtn.Name = "category_deleteBtn";
            category_deleteBtn.Size = new Size(94, 47);
            category_deleteBtn.TabIndex = 9;
            category_deleteBtn.Text = "Delete";
            category_deleteBtn.UseVisualStyleBackColor = false;
            category_deleteBtn.Click += CategoryDeleteBtn_Click;
            // 
            // category_clearBtn
            // 
            category_clearBtn.BackColor = Color.Green;
            category_clearBtn.FlatAppearance.BorderSize = 0;
            category_clearBtn.FlatStyle = FlatStyle.Flat;
            category_clearBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_clearBtn.ForeColor = Color.White;
            category_clearBtn.Location = new Point(16, 331);
            category_clearBtn.Name = "category_clearBtn";
            category_clearBtn.Size = new Size(94, 47);
            category_clearBtn.TabIndex = 8;
            category_clearBtn.Text = "Clear";
            category_clearBtn.UseVisualStyleBackColor = false;
            category_clearBtn.Click += CategoryClearBtn_Click;
            // 
            // category_updateBtn
            // 
            category_updateBtn.BackColor = Color.Green;
            category_updateBtn.FlatAppearance.BorderSize = 0;
            category_updateBtn.FlatStyle = FlatStyle.Flat;
            category_updateBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_updateBtn.ForeColor = Color.White;
            category_updateBtn.Location = new Point(232, 261);
            category_updateBtn.Name = "category_updateBtn";
            category_updateBtn.Size = new Size(94, 47);
            category_updateBtn.TabIndex = 7;
            category_updateBtn.Text = "Update";
            category_updateBtn.UseVisualStyleBackColor = false;
            category_updateBtn.Click += CategoryUpdateBtn_Click;
            // 
            // category_addBtn
            // 
            category_addBtn.BackColor = Color.Green;
            category_addBtn.FlatAppearance.BorderSize = 0;
            category_addBtn.FlatStyle = FlatStyle.Flat;
            category_addBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_addBtn.ForeColor = Color.White;
            category_addBtn.Location = new Point(16, 261);
            category_addBtn.Name = "category_addBtn";
            category_addBtn.Size = new Size(94, 47);
            category_addBtn.TabIndex = 6;
            category_addBtn.Text = "Add";
            category_addBtn.UseVisualStyleBackColor = false;
            category_addBtn.Click += CategoryAddBtn_Click;
            // 
            // category_status
            // 
            category_status.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_status.FormattingEnabled = true;
            category_status.Items.AddRange(new object[] { "Active", "Inactive" });
            category_status.Location = new Point(16, 206);
            category_status.Name = "category_status";
            category_status.Size = new Size(335, 33);
            category_status.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 179);
            label3.Name = "label3";
            label3.Size = new Size(66, 24);
            label3.TabIndex = 4;
            label3.Text = "Status";
            // 
            // category_type
            // 
            category_type.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_type.FormattingEnabled = true;
            category_type.Items.AddRange(new object[] { "Income", "Expenses" });
            category_type.Location = new Point(16, 126);
            category_type.Name = "category_type";
            category_type.Size = new Size(335, 33);
            category_type.TabIndex = 3;
            category_type.SelectedIndexChanged += CategoryTypeSelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 99);
            label2.Name = "label2";
            label2.Size = new Size(54, 24);
            label2.TabIndex = 2;
            label2.Text = "Type";
            // 
            // category_category
            // 
            category_category.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            category_category.Location = new Point(16, 55);
            category_category.Name = "category_category";
            category_category.Size = new Size(335, 30);
            category_category.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(90, 24);
            label1.TabIndex = 0;
            label1.Text = "Category";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(422, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(987, 552);
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 18);
            label4.Name = "label4";
            label4.Size = new Size(127, 24);
            label4.TabIndex = 1;
            label4.Text = "Category List";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Green;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(3, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(947, 483);
            dataGridView1.TabIndex = 0;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CategoryForm";
            Size = new Size(1454, 620);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private TextBox category_category;
        private Label label1;
        private Panel panel2;
        private ComboBox category_type;
        private Button category_addBtn;
        private ComboBox category_status;
        private Label label3;
        private Button category_clearBtn;
        private Button category_deleteBtn;
        private Button category_updateBtn;
        private Label label4;
        private DataGridView dataGridView1;
    }
}
