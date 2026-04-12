using System;
using System.Data;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }



        private void RegisterPasswordTextChanged(object sender, EventArgs e)
        {
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void RegisterUsernameTextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseClick_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterLoginBtn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new();
            loginForm.Show();

            this.Close();
        }

        private void RegisterShowPassCheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPass.Checked ? '\0' : '*';
            register_cPassword.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(register_username.Text) || string.IsNullOrWhiteSpace(register_password.Text) || string.IsNullOrWhiteSpace(register_cPassword.Text))
            {
                MessageBox.Show(AppConstants.FillAllFieldsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (register_password.Text.Length < AppConstants.MinimumPasswordLength)
            {
                MessageBox.Show(AppConstants.PasswordTooShortError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (register_password.Text != register_cPassword.Text)
            {
                MessageBox.Show(AppConstants.PasswordMismatchError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using var connect = new SqlConnection(DatabaseSetup.ConnectionString);
                    connect.Open();

                    using var checkUser = new SqlCommand(AppConstants.CheckUserExists, connect);
                    checkUser.Parameters.AddWithValue(AppConstants.ParamUsername, register_username.Text.Trim());
                    using var adapter = new SqlDataAdapter();
                    DataTable table = new();

                    adapter.SelectCommand = checkUser;
                    adapter.Fill(table);

                    if (table.Rows.Count != 0)
                    {
                        string tempUsern = string.Concat(register_username.Text[..1].ToUpper(), register_username.Text[1..]);
                        MessageBox.Show(tempUsern + AppConstants.UserExistsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        using var insertUser = new SqlCommand(AppConstants.InsertUser, connect);
                        insertUser.Parameters.AddWithValue(AppConstants.ParamUsername, register_username.Text.Trim());
                        insertUser.Parameters.AddWithValue(AppConstants.ParamPassword, PasswordHasher.Hash(register_password.Text.Trim()));
                        insertUser.Parameters.AddWithValue(AppConstants.ParamDate, DateTime.Today);

                        insertUser.ExecuteNonQuery();

                        MessageBox.Show(AppConstants.RegisteredSuccessfully, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 loginForm = new();
                        loginForm.Show();

                        this.Close();
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
