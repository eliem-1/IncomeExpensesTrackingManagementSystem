using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            income_dataGridView.CellClick += IncomeDataGridView_CellClick;
            income_category.SelectedIndexChanged += IncomeCategory_SelectedIndexChanged;
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

                using var cmd = new SqlCommand(AppConstants.SelectIncomeTransactions, connect);
                cmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);

                SqlDataAdapter adapter = new(cmd);
                DataTable dt = new();
                adapter.Fill(dt);

                income_dataGridView.DataSource = dt;

                // Format amount column as currency
                if (income_dataGridView.Columns["trans_amount"] is DataGridViewColumn amountColumn)
                {
                    amountColumn.DefaultCellStyle.Format = AppConstants.CurrencyFormat;
                    amountColumn.DefaultCellStyle.FormatProvider = UsCulture;
                }

                // Format date column
                if (income_dataGridView.Columns["trans_date"] is DataGridViewColumn dateColumn)
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
                income_category.Items.Clear();

                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(AppConstants.SelectIncomeCategories, connect);
                cmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string categoryName = Convert.ToString(reader["cate_name"]) ?? string.Empty;
                    int categoryId = Convert.ToInt32(reader["cate_id"]);
                    income_category.Items.Add(new CategoryItem(categoryName, categoryId));
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
        private void IncomeAddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(income_amount.Text) || income_category.SelectedIndex == -1)
            {
                MessageBox.Show(AppConstants.FillAllFieldsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!decimal.TryParse(income_amount.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, UsCulture, out decimal amount) || amount <= 0)
            {
                MessageBox.Show(AppConstants.InvalidAmountError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (income_category.SelectedItem is not CategoryItem selectedCategory)
                    {
                        MessageBox.Show(AppConstants.SelectValidCategoryError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using var connect = new SqlConnection(_connectionString);
                    connect.Open();

                    if (_selectedTransactionId.HasValue)
                    {
                        string updateQuery = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND user_id = @user_id AND trans_type = 'Income'";
                        using var updateCmd = new SqlCommand(updateQuery, connect);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamCategoryId, selectedCategory.Id);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamAmount, amount);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamDescription, income_description.Text.Trim());
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamTransDate, income_date.Value.Date);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamTransactionId, _selectedTransactionId.Value);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Income updated successfully!", AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        using var cmd = new SqlCommand(AppConstants.InsertTransaction, connect);
                        cmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);
                        cmd.Parameters.AddWithValue(AppConstants.ParamCategoryId, selectedCategory.Id);
                        cmd.Parameters.AddWithValue(AppConstants.ParamTransactionType, AppConstants.TransactionTypeIncome);
                        cmd.Parameters.AddWithValue(AppConstants.ParamAmount, amount);
                        cmd.Parameters.AddWithValue(AppConstants.ParamDescription, income_description.Text.Trim());
                        cmd.Parameters.AddWithValue(AppConstants.ParamTransDate, income_date.Value.Date);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Income added successfully!", AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ResetFormState();
                    LoadIncomeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Delete button click to remove an income transaction.
        /// </summary>
        private void IncomeDeleteBtn_Click(object sender, EventArgs e)
        {
            if (income_dataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    object? transIdValue = income_dataGridView.SelectedRows[0].Cells[0].Value;
                    if (transIdValue is null || transIdValue == DBNull.Value)
                    {
                        MessageBox.Show("Please select a valid income record", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int transId = Convert.ToInt32(transIdValue);

                    if (MessageBox.Show(AppConstants.ConfirmDeleteTransaction, AppConstants.ConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    using var connect = new SqlConnection(_connectionString);
                    connect.Open();

                    using var cmd = new SqlCommand("DELETE FROM transactions WHERE trans_id = @trans_id AND user_id = @user_id", connect);
                    cmd.Parameters.AddWithValue(AppConstants.ParamTransactionId, transId);
                    cmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(AppConstants.TransactionDeletedSuccessfully, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormState();
                    LoadIncomeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an income record to delete", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Clear button click to reset the form.
        /// </summary>
        private void IncomeClearBtn_Click(object sender, EventArgs e)
        {
            ResetFormState();
        }

        /// <summary>
        /// Handles the Update button click.
        /// </summary>
        private void IncomeUpdateBtn_Click(object sender, EventArgs e)
        {
            if (!_selectedTransactionId.HasValue)
            {
                MessageBox.Show("Please select an income record to update", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IncomeAddBtn_Click(sender, e);
        }

        /// <summary>
        /// Handles DataGridView cell click to populate form with transaction details.
        /// </summary>
        private void IncomeDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= income_dataGridView.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = income_dataGridView.Rows[e.RowIndex];
            object? transId = row.Cells[AppConstants.ColumnTransactionId].Value;
            if (transId is null || transId == DBNull.Value)
            {
                return;
            }

            _selectedTransactionId = Convert.ToInt32(transId);

            decimal amountValue = Convert.ToDecimal(row.Cells[AppConstants.ColumnAmount].Value ?? 0m);
            income_amount.Text = amountValue.ToString("N2", UsCulture);

            income_description.Text = Convert.ToString(row.Cells["trans_description"].Value) ?? string.Empty;

            if (DateTime.TryParse(Convert.ToString(row.Cells["trans_date"].Value), out DateTime selectedDate))
            {
                income_date.Value = selectedDate;
            }

            int selectedCateId = Convert.ToInt32(row.Cells[AppConstants.ColumnCategoryId].Value ?? 0);
            for (int i = 0; i < income_category.Items.Count; i++)
            {
                if (income_category.Items[i] is CategoryItem item && item.Id == selectedCateId)
                {
                    income_category.SelectedIndex = i;
                    income_item.Text = item.Name;
                    break;
                }
            }

            income_addBtn.Text = "Update";
        }

        /// <summary>
        /// Handles category selection change to update the item field.
        /// </summary>
        private void IncomeCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (income_category.SelectedItem is CategoryItem selectedCategory)
            {
                income_item.Text = selectedCategory.Name;
            }
            else
            {
                income_item.Clear();
            }
        }

        /// <summary>
        /// Resets the form to its initial state.
        /// </summary>
        private void ResetFormState()
        {
            _selectedTransactionId = null;
            income_item.Clear();
            income_amount.Clear();
            income_description.Clear();
            income_category.SelectedIndex = -1;
            income_date.Value = DateTime.Now;
            income_addBtn.Text = "Add";
        }

        /// <summary>
        /// Handles the form Load event to initialize income data.
        /// </summary>
        private void IncomeForm_Load(object sender, EventArgs e)
        {
            LoadIncomeData();
        }
    }
}
