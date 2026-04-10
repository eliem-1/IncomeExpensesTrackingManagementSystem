using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace IncomeExpensesTrackingManagementSystem
{
    public partial class IncomeForm : UserControl
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;
        private static readonly CultureInfo UsCulture = CultureInfo.GetCultureInfo("en-US");
        private int _currentUserId;
        private int? _selectedTransactionId;

        public IncomeForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        /// <summary>
        /// Sets the current user ID for loading user-specific income data.
        /// </summary>
        public void SetUserId(int userId)
        {
            _currentUserId = userId;
        }

        /// <summary>
        /// Loads income data from the database and displays it in the DataGridView.
        /// </summary>
        public void LoadIncomeData()
        {
            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(
                    "SELECT trans_id, cate_id, trans_description, trans_amount, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Income' ORDER BY trans_date DESC",
                    connect);
                cmd.Parameters.AddWithValue("@user_id", _currentUserId);

                SqlDataAdapter adapter = new(cmd);
                DataTable dt = new();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                // Format amount column as currency
                DataGridViewColumn? amountColumn = dataGridView1.Columns["trans_amount"];
                if (amountColumn != null)
                {
                    amountColumn.DefaultCellStyle.Format = "C2";
                    amountColumn.DefaultCellStyle.FormatProvider = UsCulture;
                }

                // Format date column
                DataGridViewColumn? dateColumn = dataGridView1.Columns["trans_date"];
                if (dateColumn != null)
                {
                    dateColumn.DefaultCellStyle.Format = "MM-dd-yyyy";
                }

                LoadIncomeCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading income data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads income categories from the database into the category combo box.
        /// </summary>
        private void LoadIncomeCategories()
        {
            try
            {
                comboBox1.Items.Clear();

                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand("SELECT cate_id, cate_name FROM category WHERE cate_type IN ('Income', 'Incomes') AND cate_status = 'Active'", connect);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string categoryName = Convert.ToString(reader["cate_name"]) ?? string.Empty;
                    int categoryId = Convert.ToInt32(reader["cate_id"]);
                    comboBox1.Items.Add(new CategoryItem(categoryName, categoryId));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Add button click to add or update an income transaction.
        /// </summary>
        private void Category_AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!decimal.TryParse(textBox2.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, UsCulture, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (comboBox1.SelectedItem is not CategoryItem selectedCategory)
                    {
                        MessageBox.Show("Please select a valid category", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using var connect = new SqlConnection(_connectionString);
                    connect.Open();

                    if (_selectedTransactionId.HasValue)
                    {
                        string updateQuery = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND user_id = @user_id AND trans_type = 'Income'";
                        using var updateCmd = new SqlCommand(updateQuery, connect);
                        updateCmd.Parameters.AddWithValue("@cate_id", selectedCategory.Id);
                        updateCmd.Parameters.AddWithValue("@trans_amount", amount);
                        updateCmd.Parameters.AddWithValue("@trans_description", textBox3.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@trans_date", dateTimePicker1.Value.Date);
                        updateCmd.Parameters.AddWithValue("@trans_id", _selectedTransactionId.Value);
                        updateCmd.Parameters.AddWithValue("@user_id", _currentUserId);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Income updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO transactions (user_id, cate_id, trans_type, trans_amount, trans_description, trans_date) VALUES (@user_id, @cate_id, @trans_type, @trans_amount, @trans_description, @trans_date)";

                        using var cmd = new SqlCommand(insertQuery, connect);
                        cmd.Parameters.AddWithValue("@user_id", _currentUserId);
                        cmd.Parameters.AddWithValue("@cate_id", selectedCategory.Id);
                        cmd.Parameters.AddWithValue("@trans_type", "Income");
                        cmd.Parameters.AddWithValue("@trans_amount", amount);
                        cmd.Parameters.AddWithValue("@trans_description", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@trans_date", dateTimePicker1.Value.Date);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Income added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ResetFormState();
                    LoadIncomeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Delete button click to remove an income transaction.
        /// </summary>
        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    object? transIdValue = dataGridView1.SelectedRows[0].Cells[0].Value;
                    if (transIdValue is null || transIdValue == DBNull.Value)
                    {
                        MessageBox.Show("Please select a valid income record", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int transId = Convert.ToInt32(transIdValue);

                    using var connect = new SqlConnection(_connectionString);
                    connect.Open();

                    using var cmd = new SqlCommand("DELETE FROM transactions WHERE trans_id = @trans_id", connect);
                    cmd.Parameters.AddWithValue("@trans_id", transId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Income deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormState();
                    LoadIncomeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an income record to delete", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Clear button click to reset the form.
        /// </summary>
        private void Button3_Click(object sender, EventArgs e)
        {
            ResetFormState();
        }

        /// <summary>
        /// Handles the Update button click.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            // Update is handled via the Add button when a record is selected
            Category_AddBtn_Click(sender, e);
        }

        /// <summary>
        /// Handles DataGridView cell click to populate form with transaction details.
        /// </summary>
        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            object? transId = row.Cells["trans_id"].Value;
            if (transId is null || transId == DBNull.Value)
            {
                return;
            }

            _selectedTransactionId = Convert.ToInt32(transId);

            decimal amountValue = Convert.ToDecimal(row.Cells["trans_amount"].Value ?? 0m);
            textBox2.Text = amountValue.ToString("N2", UsCulture);
            textBox3.Text = Convert.ToString(row.Cells["trans_description"].Value) ?? string.Empty;

            if (DateTime.TryParse(Convert.ToString(row.Cells["trans_date"].Value), out DateTime selectedDate))
            {
                dateTimePicker1.Value = selectedDate;
            }

            int selectedCateId = Convert.ToInt32(row.Cells["cate_id"].Value ?? 0);
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i] is CategoryItem item && item.Id == selectedCateId)
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }

            category_addBtn.Text = "Update";
        }

        /// <summary>
        /// Resets the form to its initial state.
        /// </summary>
        private void ResetFormState()
        {
            _selectedTransactionId = null;
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            category_addBtn.Text = "Add";
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            LoadIncomeData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
