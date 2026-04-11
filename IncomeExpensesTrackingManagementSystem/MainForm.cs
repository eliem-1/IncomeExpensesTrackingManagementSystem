using System;
using System.Windows.Forms;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Main application window that serves as the central hub for all user operations.
    /// Manages navigation between dashboard, income, expense, and category forms.
    /// </summary>
    public partial class MainForm : Form
    {
        private int _currentUserId;
        private string _currentUsername = string.Empty;

        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the current user ID and initializes all forms with user data.
        /// </summary>
        /// <param name="userId">The ID of the logged-in user.</param>
        public void SetUserId(int userId, string username)
        {
            _currentUserId = userId;
            _currentUsername = username;
            label2.Text = $"Welcome, {_currentUsername}";
            InitializeUserForms();
        }

        /// <summary>
        /// Initializes all user controls with the current user's data.
        /// </summary>
        private void InitializeUserForms()
        {
            try
            {
                // Initialize Dashboard Form
                dashboardForm1?.SetUserId(_currentUserId);
                dashboardForm1?.LoadDashboardData();

                // Initialize Income Form
                incomeForm1?.SetUserId(_currentUserId);
                incomeForm1?.LoadIncomeData();

                // Initialize Expense Form
                expenseForm1?.SetUserId(_currentUserId);
                expenseForm1?.LoadExpenseData();

                // Initialize Categories with user data
                categoryForm1?.SetUserId(_currentUserId);
                categoryForm1?.LoadCategories();

                // Display Dashboard as default
                dashboardForm1?.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing forms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the close button click event with confirmation dialog.
        /// </summary>
        private void CloseClick_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppConstants.ConfirmCloseApplication, AppConstants.ConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Displays the dashboard form and refreshes its data.
        /// </summary>
        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            dashboardForm1?.BringToFront();
            dashboardForm1?.LoadDashboardData();
        }

        /// <summary>
        /// Displays the income form and refreshes its data.
        /// </summary>
        private void IncomeBtn_Click(object sender, EventArgs e)
        {
            incomeForm1?.BringToFront();
            incomeForm1?.LoadIncomeData();
        }

        /// <summary>
        /// Displays the expense form and refreshes its data.
        /// </summary>
        private void ExpensesBtn_Click(object sender, EventArgs e)
        {
            expenseForm1?.BringToFront();
            expenseForm1?.LoadExpenseData();
        }

        /// <summary>
        /// Displays the category form and refreshes its data.
        /// </summary>
        private void AddCategoryBtn_Click(object sender, EventArgs e)
        {
            categoryForm1?.BringToFront();
            categoryForm1?.LoadCategories();
        }

        /// <summary>
        /// Handles the logout button click with confirmation dialog.
        /// </summary>
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppConstants.ConfirmLogout, AppConstants.ConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new();
                loginForm.Show();

                this.Hide();
            }
        }
    }
}
