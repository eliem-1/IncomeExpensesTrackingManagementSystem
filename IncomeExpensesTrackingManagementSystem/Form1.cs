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
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using SqlConnection connect = new(DatabaseSetup.ConnectionString);
                    connect.Open();

                    string selectData = "SELECT id, password FROM users WHERE username = @usern";

                    using SqlCommand cmd = new(selectData, connect);
                    cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());

                    SqlDataAdapter adapter = new(cmd);
                    DataTable table = new();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        int userId = (int)table.Rows[0]["id"];
                        string storedPassword = Convert.ToString(table.Rows[0]["password"]) ?? string.Empty;
                        string enteredPassword = login_password.Text.Trim();

                        bool isValidPassword = PasswordHasher.IsHashedFormat(storedPassword)
                            ? PasswordHasher.Verify(enteredPassword, storedPassword)
                            : string.Equals(storedPassword, enteredPassword, StringComparison.Ordinal);

                        if (!isValidPassword)
                        {
                            MessageBox.Show("Incorrect username/password.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!PasswordHasher.IsHashedFormat(storedPassword))
                        {
                            string upgradePassword = "UPDATE users SET password = @new_pass WHERE id = @id";
                            using SqlCommand upgradeCmd = new(upgradePassword, connect);
                            upgradeCmd.Parameters.AddWithValue("@new_pass", PasswordHasher.Hash(enteredPassword));
                            upgradeCmd.Parameters.AddWithValue("@id", userId);
                            upgradeCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Login successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MainForm mform = new();
                        mform.SetUserId(userId, login_username.Text.Trim());
                        mform.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username/password.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
