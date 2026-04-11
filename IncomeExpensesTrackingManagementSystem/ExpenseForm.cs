using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace IncomeExpensesTrackingManagementSystem
{
    public partial class ExpenseForm : UserControl
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;
        private static readonly CultureInfo UsCulture = CultureInfo.GetCultureInfo("en-US");
        private int? _selectedTransactionId;
        private int _currentUserId;

        public ExpenseForm()
        {
            InitializeComponent();
            expense_dataGridView.CellClick += ExpenseDataGridView_CellClick;
        }

        public void SetUserId(int userId)
        {
            _currentUserId = userId;
        }

        public void LoadExpenseCategories()
        {
            try
            {
                expense_category.Items.Clear();

                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(AppConstants.SelectExpenseCategories, connect);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string categoryName = Convert.ToString(reader["cate_name"]) ?? string.Empty;
                    int categoryId = Convert.ToInt32(reader["cate_id"]);
                    expense_category.Items.Add(new CategoryItem(categoryName, categoryId));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(AppConstants.LoadingCategoriesError + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadExpenseData()
        {
            try
            {
                LoadExpenseCategories();

                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(AppConstants.SelectExpenseTransactions, connect);
                cmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);

                SqlDataAdapter adapter = new(cmd);
                DataTable dt = new();
                adapter.Fill(dt);

                expense_dataGridView.DataSource = dt;

                DataGridViewColumn? amountColumn = expense_dataGridView.Columns[AppConstants.ColumnAmount];
                if (amountColumn != null)
                {
                    amountColumn.DefaultCellStyle.Format = AppConstants.CurrencyFormat;
                    amountColumn.DefaultCellStyle.FormatProvider = UsCulture;
                }

                DataGridViewColumn? dateColumn = expense_dataGridView.Columns["trans_date"];
                if (dateColumn != null)
                {
                    dateColumn.DefaultCellStyle.Format = "MM-dd-yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExpenseAddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(expense_amount.Text) || expense_category.SelectedIndex == -1)
            {
                MessageBox.Show(AppConstants.FillAllFieldsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!decimal.TryParse(expense_amount.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, UsCulture, out decimal amount) || amount <= 0)
            {
                MessageBox.Show(AppConstants.InvalidAmountError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (expense_category.SelectedItem is not CategoryItem selectedCategory)
                    {
                        MessageBox.Show(AppConstants.SelectValidCategoryError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using var connect = new SqlConnection(_connectionString);
                    connect.Open();

                    if (_selectedTransactionId.HasValue)
                    {
                        string updateQuery = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND user_id = @user_id AND trans_type = 'Expense'";
                        using var updateCmd = new SqlCommand(updateQuery, connect);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamCategoryId, selectedCategory.Id);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamAmount, amount);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamDescription, expense_description.Text.Trim());
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamTransDate, expense_date.Value.Date);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamTransactionId, _selectedTransactionId.Value);
                        updateCmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Expense updated successfully!", AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        using var cmd = new SqlCommand(AppConstants.InsertTransaction, connect);
                        cmd.Parameters.AddWithValue(AppConstants.ParamUserId, _currentUserId);
                        cmd.Parameters.AddWithValue(AppConstants.ParamCategoryId, selectedCategory.Id);
                        cmd.Parameters.AddWithValue(AppConstants.ParamTransactionType, AppConstants.TransactionTypeExpense);
                        cmd.Parameters.AddWithValue(AppConstants.ParamAmount, amount);
                        cmd.Parameters.AddWithValue(AppConstants.ParamDescription, expense_description.Text.Trim());
                        cmd.Parameters.AddWithValue(AppConstants.ParamTransDate, expense_date.Value.Date);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Expense added successfully!", AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ResetFormState();

                    LoadExpenseData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExpenseDeleteBtn_Click(object sender, EventArgs e)
        {
            if (expense_dataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    object? transIdValue = expense_dataGridView.SelectedRows[0].Cells[0].Value;
                    if (transIdValue is null || transIdValue == DBNull.Value)
                    {
                        MessageBox.Show("Please select a valid expense record", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LoadExpenseData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an expense record to delete", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExpenseClearBtn_Click(object sender, EventArgs e)
        {
            ResetFormState();
        }

        private void ExpenseUpdateBtn_Click(object sender, EventArgs e)
        {
            if (!_selectedTransactionId.HasValue)
            {
                MessageBox.Show("Please select an expense record to update", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExpenseAddBtn_Click(sender, e);
        }

        private void ExpenseDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= expense_dataGridView.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = expense_dataGridView.Rows[e.RowIndex];
            object? transId = row.Cells[AppConstants.ColumnTransactionId].Value;
            if (transId is null || transId == DBNull.Value)
            {
                return;
            }

            _selectedTransactionId = Convert.ToInt32(transId);

            decimal amountValue = Convert.ToDecimal(row.Cells[AppConstants.ColumnAmount].Value ?? 0m);
            expense_amount.Text = amountValue.ToString("N2", UsCulture);
            expense_description.Text = Convert.ToString(row.Cells["trans_description"].Value) ?? string.Empty;

            if (DateTime.TryParse(Convert.ToString(row.Cells["trans_date"].Value), out DateTime selectedDate))
            {
                expense_date.Value = selectedDate;
            }

            int selectedCateId = Convert.ToInt32(row.Cells[AppConstants.ColumnCategoryId].Value ?? 0);
            for (int i = 0; i < expense_category.Items.Count; i++)
            {
                if (expense_category.Items[i] is CategoryItem item && item.Id == selectedCateId)
                {
                    expense_category.SelectedIndex = i;
                    break;
                }
            }

            expense_addBtn.Text = "Update";
        }

        private void ResetFormState()
        {
            _selectedTransactionId = null;
            expense_amount.Clear();
            expense_description.Clear();
            expense_category.SelectedIndex = -1;
            expense_date.Value = DateTime.Now;
            expense_addBtn.Text = "Add";
        }

        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            LoadExpenseData();
        }
    }
}
