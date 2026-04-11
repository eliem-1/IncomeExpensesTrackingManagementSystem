namespace IncomeExpensesTrackingManagementSystem
{
    partial class IncomeForm
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
            income_dataGridView = new DataGridView();
            label1 = new Label();
            panel2 = new Panel();
            income_deleteBtn = new Button();
            income_clearBtn = new Button();
            income_updateBtn = new Button();
            income_addBtn = new Button();
            income_date = new DateTimePicker();
            label6 = new Label();
            income_description = new TextBox();
            label5 = new Label();
            income_amount = new TextBox();
            label4 = new Label();
            income_item = new TextBox();
            label3 = new Label();
            income_category = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)income_dataGridView).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(income_dataGridView);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1448, 282);
            panel1.TabIndex = 0;
            // 
            // income_dataGridView
            // 
            income_dataGridView.AllowUserToAddRows = false;
            income_dataGridView.AllowUserToDeleteRows = false;
            income_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            income_dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Green;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            income_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            income_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            income_dataGridView.EnableHeadersVisualStyles = false;
            income_dataGridView.Location = new Point(19, 43);
            income_dataGridView.Name = "income_dataGridView";
            income_dataGridView.ReadOnly = true;
            income_dataGridView.RowHeadersVisible = false;
            income_dataGridView.RowHeadersWidth = 51;
            income_dataGridView.Size = new Size(1404, 215);
            income_dataGridView.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 14);
            label1.Name = "label1";
            label1.Size = new Size(129, 28);
            label1.TabIndex = 1;
            label1.Text = "Income List";
            // 
            // panel2
            // 
            panel2.Controls.Add(income_deleteBtn);
            panel2.Controls.Add(income_clearBtn);
            panel2.Controls.Add(income_updateBtn);
            panel2.Controls.Add(income_addBtn);
            panel2.Controls.Add(income_date);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(income_description);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(income_amount);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(income_item);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(income_category);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 302);
            panel2.Name = "panel2";
            panel2.Size = new Size(1448, 282);
            panel2.TabIndex = 1;
            // 
            // income_deleteBtn
            // 
            income_deleteBtn.BackColor = Color.Green;
            income_deleteBtn.FlatAppearance.BorderSize = 0;
            income_deleteBtn.FlatStyle = FlatStyle.Flat;
            income_deleteBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_deleteBtn.ForeColor = Color.White;
            income_deleteBtn.Location = new Point(838, 188);
            income_deleteBtn.Name = "income_deleteBtn";
            income_deleteBtn.Size = new Size(94, 47);
            income_deleteBtn.TabIndex = 14;
            income_deleteBtn.Text = "Delete";
            income_deleteBtn.UseVisualStyleBackColor = false;
            income_deleteBtn.Click += IncomeDeleteBtn_Click;
            // 
            // income_clearBtn
            // 
            income_clearBtn.BackColor = Color.Green;
            income_clearBtn.FlatAppearance.BorderSize = 0;
            income_clearBtn.FlatStyle = FlatStyle.Flat;
            income_clearBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_clearBtn.ForeColor = Color.White;
            income_clearBtn.Location = new Point(686, 188);
            income_clearBtn.Name = "income_clearBtn";
            income_clearBtn.Size = new Size(94, 47);
            income_clearBtn.TabIndex = 13;
            income_clearBtn.Text = "Clear";
            income_clearBtn.UseVisualStyleBackColor = false;
            income_clearBtn.Click += IncomeClearBtn_Click;
            // 
            // income_updateBtn
            // 
            income_updateBtn.BackColor = Color.Green;
            income_updateBtn.FlatAppearance.BorderSize = 0;
            income_updateBtn.FlatStyle = FlatStyle.Flat;
            income_updateBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_updateBtn.ForeColor = Color.White;
            income_updateBtn.Location = new Point(267, 188);
            income_updateBtn.Name = "income_updateBtn";
            income_updateBtn.Size = new Size(94, 47);
            income_updateBtn.TabIndex = 12;
            income_updateBtn.Text = "Update";
            income_updateBtn.UseVisualStyleBackColor = false;
            income_updateBtn.Click += IncomeUpdateBtn_Click;
            // 
            // income_addBtn
            // 
            income_addBtn.BackColor = Color.Green;
            income_addBtn.FlatAppearance.BorderSize = 0;
            income_addBtn.FlatStyle = FlatStyle.Flat;
            income_addBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_addBtn.ForeColor = Color.White;
            income_addBtn.Location = new Point(115, 188);
            income_addBtn.Name = "income_addBtn";
            income_addBtn.Size = new Size(94, 47);
            income_addBtn.TabIndex = 11;
            income_addBtn.Text = "Add";
            income_addBtn.UseVisualStyleBackColor = false;
            income_addBtn.Click += IncomeAddBtn_Click;
            // 
            // income_date
            // 
            income_date.CustomFormat = "MM-dd-yyyy";
            income_date.Format = DateTimePickerFormat.Custom;
            income_date.Location = new Point(682, 133);
            income_date.Name = "income_date";
            income_date.Size = new Size(250, 27);
            income_date.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(597, 144);
            label6.Name = "label6";
            label6.Size = new Size(60, 24);
            label6.TabIndex = 9;
            label6.Text = "Date:";
            // 
            // income_description
            // 
            income_description.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_description.Location = new Point(686, 30);
            income_description.Multiline = true;
            income_description.Name = "income_description";
            income_description.Size = new Size(487, 97);
            income_description.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(572, 36);
            label5.Name = "label5";
            label5.Size = new Size(108, 24);
            label5.TabIndex = 7;
            label5.Text = "Description:";
            // 
            // income_amount
            // 
            income_amount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_amount.Location = new Point(115, 138);
            income_amount.Name = "income_amount";
            income_amount.Size = new Size(246, 30);
            income_amount.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 141);
            label4.Name = "label4";
            label4.Size = new Size(83, 24);
            label4.TabIndex = 5;
            label4.Text = "Income:";
            // 
            // income_item
            // 
            income_item.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_item.Location = new Point(115, 87);
            income_item.Name = "income_item";
            income_item.ReadOnly = true;
            income_item.Size = new Size(246, 30);
            income_item.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(57, 90);
            label3.Name = "label3";
            label3.Size = new Size(59, 24);
            label3.TabIndex = 3;
            label3.Text = "Item:";
            // 
            // income_category
            // 
            income_category.DropDownStyle = ComboBoxStyle.DropDownList;
            income_category.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_category.FormattingEnabled = true;
            income_category.Location = new Point(115, 27);
            income_category.Name = "income_category";
            income_category.Size = new Size(246, 33);
            income_category.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 36);
            label2.Name = "label2";
            label2.Size = new Size(97, 24);
            label2.TabIndex = 1;
            label2.Text = "Category:";
            // 
            // IncomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "IncomeForm";
            Size = new Size(1454, 620);
            Load += IncomeForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)income_dataGridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private ComboBox income_category;
        private Label label3;
        private TextBox income_amount;
        private Label label4;
        private TextBox income_item;
        private TextBox income_description;
        private Label label5;
        private DateTimePicker income_date;
        private Label label6;
        private Button income_deleteBtn;
        private Button income_clearBtn;
        private Button income_updateBtn;
        private Button income_addBtn;
        private DataGridView income_dataGridView;
    }
}
