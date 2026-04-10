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
                label2.Text = 0m.ToString("C2", UsCulture);
                label4.Text = 0m.ToString("C2", UsCulture);
                label6.Text = 0m.ToString("C2", UsCulture);
                return;
            }

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                // Total Income
                decimal totalIncome = GetAmount(connect, "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Income'");
                label2.Text = totalIncome.ToString("C2", UsCulture);

                // Total Expenses
                decimal totalExpenses = GetAmount(connect, "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense'");
                label4.Text = totalExpenses.ToString("C2", UsCulture);

                // Net Balance
                decimal netBalance = GetAmount(connect, "SELECT ISNULL(SUM(CASE WHEN trans_type = 'Income' THEN trans_amount ELSE -trans_amount END), 0) FROM transactions WHERE user_id = @user_id");
                label6.Text = netBalance.ToString("C2", UsCulture);
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

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            // Dashboard paint event
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            // Settings or profile click
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            // Refresh dashboard
            LoadDashboardData();
        }
    }
}
