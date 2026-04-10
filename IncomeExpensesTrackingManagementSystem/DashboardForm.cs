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

        /// <summary>
        /// Loads comprehensive dashboard data including totals, monthly stats, and metrics.
        /// </summary>
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

                // Total Income
                decimal totalIncome = GetAmount(connect, "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Income'");
                label2.Text = totalIncome.ToString("C2", UsCulture);

                // Total Expenses
                decimal totalExpenses = GetAmount(connect, "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense'");
                label4.Text = totalExpenses.ToString("C2", UsCulture);

                // Net Balance
                decimal netBalance = GetAmount(connect, "SELECT ISNULL(SUM(CASE WHEN trans_type = 'Income' THEN trans_amount ELSE -trans_amount END), 0) FROM transactions WHERE user_id = @user_id");
                label6.Text = netBalance.ToString("C2", UsCulture);

                // Monthly Income (Current Month)
                decimal monthlyIncome = GetAmount(connect, "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Income' AND MONTH(trans_date) = MONTH(GETDATE()) AND YEAR(trans_date) = YEAR(GETDATE())");

                // Monthly Expenses (Current Month)
                decimal monthlyExpenses = GetAmount(connect, "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense' AND MONTH(trans_date) = MONTH(GETDATE()) AND YEAR(trans_date) = YEAR(GETDATE())");

                // Savings Rate (This Month)
                decimal savingsRate = monthlyIncome > 0 ? ((monthlyIncome - monthlyExpenses) / monthlyIncome) * 100 : 0;

                // Update labels with monthly data if available in the form
                UpdateAdditionalMetrics(monthlyIncome, monthlyExpenses, savingsRate, connect);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets a single decimal amount from a SQL query.
        /// </summary>
        private decimal GetAmount(SqlConnection connect, string query)
        {
            using var cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = _currentUserId;

            object result = cmd.ExecuteScalar() ?? 0m;
            return Convert.ToDecimal(result);
        }

        /// <summary>
        /// Updates additional metrics if dashboard has extended labels.
        /// </summary>
        private void UpdateAdditionalMetrics(decimal monthlyIncome, decimal monthlyExpenses, decimal savingsRate, SqlConnection connect)
        {
            // These labels may exist in the extended dashboard design
            // Monthly Income - label8
            // Monthly Expenses - label7  
            // Savings Rate - label5
            if (Controls.Count > 5)
            {
                try
                {
                    if (Controls["label8"] is Label monthlyIncomeLabel)
                        monthlyIncomeLabel.Text = monthlyIncome.ToString("C2", UsCulture);

                    if (Controls["label7"] is Label monthlyExpensesLabel)
                        monthlyExpensesLabel.Text = monthlyExpenses.ToString("C2", UsCulture);

                    if (Controls["label5"] is Label savingsRateLabel)
                        savingsRateLabel.Text = savingsRate.ToString("F1", UsCulture) + "%";
                }
                catch
                {
                    // Labels may not exist in current design - that's okay
                }
            }
        }

        /// <summary>
        /// Resets all dashboard labels to zero.
        /// </summary>
        private void ResetDashboardDisplay()
        {
            label2.Text = 0m.ToString("C2", UsCulture);
            label4.Text = 0m.ToString("C2", UsCulture);
            label6.Text = 0m.ToString("C2", UsCulture);
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
