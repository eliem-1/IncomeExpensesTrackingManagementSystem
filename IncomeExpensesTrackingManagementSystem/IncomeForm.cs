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

        public IncomeForm()
        {
            InitializeComponent();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading income data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {

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
