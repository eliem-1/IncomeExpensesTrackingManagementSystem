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
            LoadDashboardData();
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
                label5.Text = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND CAST(trans_date AS DATE)=CAST(GETDATE() AS DATE)")
                    .ToString("C2", UsCulture);

                // Yesterday's Income
                label6.Text = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND CAST(trans_date AS DATE)=CAST(DATEADD(DAY,-1,GETDATE()) AS DATE)")
                    .ToString("C2", UsCulture);

                // This Month's Income
                decimal monthlyIncome = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND MONTH(trans_date)=MONTH(GETDATE()) AND YEAR(trans_date)=YEAR(GETDATE())");
                label7.Text = monthlyIncome.ToString("C2", UsCulture);

                // This Year's Income
                label8.Text = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND YEAR(trans_date)=YEAR(GETDATE())")
                    .ToString("C2", UsCulture);

                // --- Expense cards (Row 2) ---
                // Today's Expenses
                label9.Text = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND CAST(trans_date AS DATE)=CAST(GETDATE() AS DATE)")
                    .ToString("C2", UsCulture);

                // Yesterday's Expenses
                label10.Text = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND CAST(trans_date AS DATE)=CAST(DATEADD(DAY,-1,GETDATE()) AS DATE)")
                    .ToString("C2", UsCulture);

                // This Month's Expenses
                decimal monthlyExpenses = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND MONTH(trans_date)=MONTH(GETDATE()) AND YEAR(trans_date)=YEAR(GETDATE())");
                label11.Text = monthlyExpenses.ToString("C2", UsCulture);

                // This Year's Expenses
                label12.Text = GetAmount(connect,
                    "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND YEAR(trans_date)=YEAR(GETDATE())")
                    .ToString("C2", UsCulture);

                // --- Totals (Row 3) ---
                decimal totalIncome = GetAmount(connect, AppConstants.SelectTotalIncome);
                label22.Text = totalIncome.ToString("C2", UsCulture);

                decimal totalExpenses = GetAmount(connect, AppConstants.SelectTotalExpense);
                label24.Text = totalExpenses.ToString("C2", UsCulture);

                // --- Total Balance ---
                decimal totalBalance = totalIncome - totalExpenses;
                label26.Text = totalBalance.ToString("C2", UsCulture);
                label26.ForeColor = totalBalance >= 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string zero = 0m.ToString("C2", UsCulture);
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
