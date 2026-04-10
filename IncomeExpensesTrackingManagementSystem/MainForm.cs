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
        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
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
    }
}
