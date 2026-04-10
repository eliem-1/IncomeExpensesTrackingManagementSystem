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
        public void SetUserId(int userId)
        {
            _currentUserId = userId;
            InitializeUserForms();
        }

        /// <summary>
        /// Initializes all user controls with the current user's data.
        /// </summary>
        private void InitializeUserForms()
        {
            try
            {
                // Initialize Income Form
                if (incomeForm1 != null)
                {
                    incomeForm1.SetUserId(_currentUserId);
                    incomeForm1.LoadIncomeData();
                }

                // Initialize Categories (already loads all categories)
                if (categoryForm1 != null)
                {
                    categoryForm1.LoadCategories();
                }
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
        /// Displays the income form and refreshes its data.
        /// </summary>
        private void IncomeBtn_Click(object sender, EventArgs e)
        {
            incomeForm1?.BringToFront();
            incomeForm1?.LoadIncomeData();
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void CategoryForm1_Load(object sender, EventArgs e)
        {

        }

        private void incomeForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
