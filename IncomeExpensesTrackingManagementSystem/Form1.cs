namespace IncomeExpensesTrackingManagementSystem
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Added to match designer-generated event wiring that references a lowercase 'close' method
        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginSignUpBtn_Click(object sender, EventArgs e)
        {
            RegisterForm regform = new();
            regform.Show();

            this.Hide();
        }

        private void LoginPasswordTextChanged(object sender, EventArgs e)
        {

        }

        private void LoginShowPassCheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = (login_showPass.Checked) ? '\0' : '*';
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login_username.Text) || string.IsNullOrWhiteSpace(login_password.Text))
            {
                MessageBox.Show(AppConstants.FillAllFieldsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using SqlConnection connect = new(DatabaseSetup.ConnectionString);
                    connect.Open();

                    using SqlCommand cmd = new(AppConstants.SelectUserByUsername, connect);
                    cmd.Parameters.AddWithValue(AppConstants.ParamUsername, login_username.Text.Trim());

                    SqlDataAdapter adapter = new(cmd);
                    DataTable table = new();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        int userId = (int)table.Rows[0][AppConstants.ColumnId];
                        string storedPassword = Convert.ToString(table.Rows[0][AppConstants.ColumnPassword]) ?? string.Empty;
                        string enteredPassword = login_password.Text.Trim();

                        bool isValidPassword = PasswordHasher.IsHashedFormat(storedPassword)
                            ? PasswordHasher.Verify(enteredPassword, storedPassword)
                            : string.Equals(storedPassword, enteredPassword, StringComparison.Ordinal);

                        if (!isValidPassword)
                        {
                            MessageBox.Show(AppConstants.IncorrectCredentialsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!PasswordHasher.IsHashedFormat(storedPassword))
                        {
                            using SqlCommand upgradeCmd = new(AppConstants.UpdateUserPassword, connect);
                            upgradeCmd.Parameters.AddWithValue(AppConstants.ParamNewPassword, PasswordHasher.Hash(enteredPassword));
                            upgradeCmd.Parameters.AddWithValue(AppConstants.ParamId, userId);
                            upgradeCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show(AppConstants.LoginSuccessfully, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MainForm mform = new();
                        mform.SetUserId(userId, login_username.Text.Trim());
                        mform.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(AppConstants.IncorrectCredentialsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
