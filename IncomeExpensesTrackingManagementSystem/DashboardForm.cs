using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace IncomeExpensesTrackingManagementSystem
{
    public partial class DashboardForm : UserControl
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;
        private static readonly CultureInfo UsCulture = CultureInfo.GetCultureInfo("en-US");
        private int _currentUserId;

        public DashboardForm()
        {
            InitializeComponent();
        }

        public void SetUserId(int userId)
        {
            _currentUserId = userId;
        }

        public void LoadDashboardData()
        {
            if (_currentUserId <= 0)
            {
                ResetDashboardDisplay();
                return;
            }

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                // --- Income cards (Row 1) ---
                // Today's Income
                label5.Text = GetAmount(connect, AppConstants.SelectTodayIncome)
                    .ToString(AppConstants.CurrencyFormat, UsCulture);

                // Yesterday's Income
                label6.Text = GetAmount(connect, AppConstants.SelectYesterdayIncome)
                    .ToString(AppConstants.CurrencyFormat, UsCulture);

                // This Month's Income
                decimal monthlyIncome = GetAmount(connect, AppConstants.SelectMonthlyIncome);
                label7.Text = monthlyIncome.ToString(AppConstants.CurrencyFormat, UsCulture);

                // This Year's Income
                label8.Text = GetAmount(connect, AppConstants.SelectYearlyIncome)
                    .ToString(AppConstants.CurrencyFormat, UsCulture);

                // --- Expense cards (Row 2) ---
                // Today's Expenses
                label9.Text = GetAmount(connect, AppConstants.SelectTodayExpense)
                    .ToString(AppConstants.CurrencyFormat, UsCulture);

                // Yesterday's Expenses
                label10.Text = GetAmount(connect, AppConstants.SelectYesterdayExpense)
                    .ToString(AppConstants.CurrencyFormat, UsCulture);

                // This Month's Expenses
                decimal monthlyExpenses = GetAmount(connect, AppConstants.SelectMonthlyExpense);
                label11.Text = monthlyExpenses.ToString(AppConstants.CurrencyFormat, UsCulture);

                // This Year's Expenses
                label12.Text = GetAmount(connect, AppConstants.SelectYearlyExpense)
                    .ToString(AppConstants.CurrencyFormat, UsCulture);

                // --- Totals (Row 3) ---
                decimal totalIncome = GetAmount(connect, AppConstants.SelectTotalIncome);
                label22.Text = totalIncome.ToString(AppConstants.CurrencyFormat, UsCulture);

                decimal totalExpenses = GetAmount(connect, AppConstants.SelectTotalExpense);
                label24.Text = totalExpenses.ToString(AppConstants.CurrencyFormat, UsCulture);

                // --- Total Balance ---
                decimal totalBalance = totalIncome - totalExpenses;
                label26.Text = totalBalance.ToString(AppConstants.CurrencyFormat, UsCulture);
                label26.ForeColor = totalBalance >= 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetAmount(SqlConnection connect, string query)
        {
            using var cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = _currentUserId;
            object result = cmd.ExecuteScalar() ?? 0m;
            return Convert.ToDecimal(result);
        }

        private void ResetDashboardDisplay()
        {
            string zero = 0m.ToString(AppConstants.CurrencyFormat, UsCulture);
            label5.Text = zero;
            label6.Text = zero;
            label7.Text = zero;
            label8.Text = zero;
            label9.Text = zero;
            label10.Text = zero;
            label11.Text = zero;
            label12.Text = zero;
            label22.Text = zero;
            label24.Text = zero;
            label26.Text = zero;
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}
