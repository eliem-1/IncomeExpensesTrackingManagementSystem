namespace IncomeExpensesTrackingManagementSystem
{
    partial class ExpenseForm
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
            expense_dataGridView = new DataGridView();
            label1 = new Label();
            panel2 = new Panel();
            expense_deleteBtn = new Button();
            expense_clearBtn = new Button();
            expense_updateBtn = new Button();
            expense_addBtn = new Button();
            expense_date = new DateTimePicker();
            label6 = new Label();
            expense_description = new TextBox();
            label5 = new Label();
            expense_amount = new TextBox();
            label4 = new Label();
            expense_category = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)expense_dataGridView).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(expense_dataGridView);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1448, 282);
            panel1.TabIndex = 0;
            // 
            // expense_dataGridView
            // 
            expense_dataGridView.AllowUserToAddRows = false;
            expense_dataGridView.AllowUserToDeleteRows = false;
            expense_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            expense_dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Green;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            expense_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            expense_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            expense_dataGridView.EnableHeadersVisualStyles = false;
            expense_dataGridView.Location = new Point(19, 43);
            expense_dataGridView.Name = "expense_dataGridView";
            expense_dataGridView.ReadOnly = true;
            expense_dataGridView.RowHeadersVisible = false;
            expense_dataGridView.RowHeadersWidth = 51;
            expense_dataGridView.Size = new Size(1404, 215);
            expense_dataGridView.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 14);
            label1.Name = "label1";
            label1.Size = new Size(136, 28);
            label1.TabIndex = 1;
            label1.Text = "Expense List";
            // 
            // panel2
            // 
            panel2.Controls.Add(expense_deleteBtn);
            panel2.Controls.Add(expense_clearBtn);
            panel2.Controls.Add(expense_updateBtn);
            panel2.Controls.Add(expense_addBtn);
            panel2.Controls.Add(expense_date);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(expense_description);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(expense_amount);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(expense_category);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 302);
            panel2.Name = "panel2";
            panel2.Size = new Size(1448, 282);
            panel2.TabIndex = 1;
            // 
            // expense_deleteBtn
            // 
            expense_deleteBtn.BackColor = Color.Green;
            expense_deleteBtn.FlatAppearance.BorderSize = 0;
            expense_deleteBtn.FlatStyle = FlatStyle.Flat;
            expense_deleteBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_deleteBtn.ForeColor = Color.White;
            expense_deleteBtn.Location = new Point(838, 188);
            expense_deleteBtn.Name = "expense_deleteBtn";
            expense_deleteBtn.Size = new Size(94, 47);
            expense_deleteBtn.TabIndex = 14;
            expense_deleteBtn.Text = "Delete";
            expense_deleteBtn.UseVisualStyleBackColor = false;
            // 
            // expense_clearBtn
            // 
            expense_clearBtn.BackColor = Color.Green;
            expense_clearBtn.FlatAppearance.BorderSize = 0;
            expense_clearBtn.FlatStyle = FlatStyle.Flat;
            expense_clearBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_clearBtn.ForeColor = Color.White;
            expense_clearBtn.Location = new Point(686, 188);
            expense_clearBtn.Name = "expense_clearBtn";
            expense_clearBtn.Size = new Size(94, 47);
            expense_clearBtn.TabIndex = 13;
            expense_clearBtn.Text = "Clear";
            expense_clearBtn.UseVisualStyleBackColor = false;
            // 
            // expense_updateBtn
            // 
            expense_updateBtn.BackColor = Color.Green;
            expense_updateBtn.FlatAppearance.BorderSize = 0;
            expense_updateBtn.FlatStyle = FlatStyle.Flat;
            expense_updateBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_updateBtn.ForeColor = Color.White;
            expense_updateBtn.Location = new Point(267, 188);
            expense_updateBtn.Name = "expense_updateBtn";
            expense_updateBtn.Size = new Size(94, 47);
            expense_updateBtn.TabIndex = 12;
            expense_updateBtn.Text = "Update";
            expense_updateBtn.UseVisualStyleBackColor = false;
            // 
            // expense_addBtn
            // 
            expense_addBtn.BackColor = Color.Green;
            expense_addBtn.FlatAppearance.BorderSize = 0;
            expense_addBtn.FlatStyle = FlatStyle.Flat;
            expense_addBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_addBtn.ForeColor = Color.White;
            expense_addBtn.Location = new Point(115, 188);
            expense_addBtn.Name = "expense_addBtn";
            expense_addBtn.Size = new Size(94, 47);
            expense_addBtn.TabIndex = 11;
            expense_addBtn.Text = "Add";
            expense_addBtn.UseVisualStyleBackColor = false;
            // 
            // expense_date
            // 
            expense_date.Location = new Point(686, 144);
            expense_date.Name = "expense_date";
            expense_date.Size = new Size(250, 27);
            expense_date.TabIndex = 10;
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
            // expense_description
            // 
            expense_description.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_description.Location = new Point(686, 30);
            expense_description.Multiline = true;
            expense_description.Name = "expense_description";
            expense_description.Size = new Size(487, 97);
            expense_description.TabIndex = 8;
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
            // expense_amount
            // 
            expense_amount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_amount.Location = new Point(115, 138);
            expense_amount.Name = "expense_amount";
            expense_amount.Size = new Size(246, 30);
            expense_amount.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 141);
            label4.Name = "label4";
            label4.Size = new Size(78, 24);
            label4.TabIndex = 5;
            label4.Text = "Amount:";
            // 
            // expense_category
            // 
            expense_category.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expense_category.FormattingEnabled = true;
            expense_category.Location = new Point(115, 33);
            expense_category.Name = "expense_category";
            expense_category.Size = new Size(246, 33);
            expense_category.TabIndex = 2;
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
            // ExpenseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ExpenseForm";
            Size = new Size(1454, 620);
            Load += ExpenseForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)expense_dataGridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private ComboBox expense_category;
        private Label label4;
        private TextBox expense_amount;
        private TextBox expense_description;
        private Label label5;
        private DateTimePicker expense_date;
        private Label label6;
        private Button expense_deleteBtn;
        private Button expense_clearBtn;
        private Button expense_updateBtn;
        private Button expense_addBtn;
        private DataGridView expense_dataGridView;
    }
}
