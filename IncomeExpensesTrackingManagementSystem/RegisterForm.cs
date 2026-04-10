using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new(DatabaseSetup.ConnectionString);
        public RegisterForm()
        {
            InitializeComponent();
        }

        public bool CheckConnection()
        {
            return (connect.State == ConnectionState.Closed) ? true : false;
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

            this.Hide();
        }

        private void RegisterShowPassCheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPass.Checked ? '\0' : '*';
            register_cPassword.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (register_username.Text == "" || register_password.Text == "" || register_cPassword.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (register_password.Text.Length < 8)
            {
                MessageBox.Show("Invalid password, at least 8 characters are needed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (register_password.Text != register_cPassword.Text)
            {
                MessageBox.Show("Password does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CheckConnection())
                {
                    try
                    {
                        // CHECK IF THE USERNAME YOU WANT TO REGISTER IS ALREADY EXIST
                        string selectUsername = "SELECT * FROM users WHERE username = @usern";

                        using var checkUser = new SqlCommand(selectUsername, connect);
                        checkUser.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                        using var adapter = new SqlDataAdapter();
                        DataTable table = new();

                        adapter.SelectCommand = checkUser;
                        adapter.Fill(table);

                        if (table.Rows.Count != 0)
                        {
                            // TO PUT THE FIRST LETTER TO BIG LETTER
                            string tempUsern = register_username.Text.Substring(0, 1).ToUpper() + register_username.Text.Substring(1);
                            MessageBox.Show(tempUsern + " is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            connect.Open();

                            string insertData = "INSERT INTO users (username, password, date_create) VALUES(@usern, @pass, @date)";

                            using var insertUser = new SqlCommand(insertData, connect);
                            insertUser.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                            insertUser.Parameters.AddWithValue("@pass", PasswordHasher.Hash(register_password.Text.Trim()));

                            DateTime today = DateTime.Today; // DATE NOW
                            insertUser.Parameters.AddWithValue("@date", today);

                            insertUser.ExecuteNonQuery();

                            MessageBox.Show("Registered successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1 loginForm = new();
                            loginForm.Show();

                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }
    }
}
