using System;
using System.IO;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Handles database initialization and configuration for LocalDB.
    /// Creates the database and required tables if they don't exist.
    /// </summary>
    public static class DatabaseSetup
    {
        private const string DatabaseName = "expenses";
        private static readonly string DatabaseDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "IncomeExpensesTrackingManagementSystem",
            "Database");
        private static readonly string DatabaseFilePath = Path.Combine(DatabaseDirectory, "expenses.mdf");
        private static readonly string DatabaseLogFilePath = Path.Combine(DatabaseDirectory, "expenses_log.ldf");

        /// <summary>
        /// Gets the connection string for the expenses database.
        /// </summary>
        public static string ConnectionString => @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        /// <summary>
        /// Initializes the database by creating it and all required tables if they don't exist.
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                Directory.CreateDirectory(DatabaseDirectory);

                // Create connection to LocalDB
                string masterConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                using (SqlConnection connection = new(masterConnection))
                {
                    connection.Open();

                    // Create the database if it doesn't exist
                    string createDbQuery = $@"
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{DatabaseName}')
                        BEGIN
                            CREATE DATABASE [{DatabaseName}]
                            ON PRIMARY (
                                NAME = expenses_data,
                                FILENAME = '{DatabaseFilePath}'
                            )
                            LOG ON (
                                NAME = expenses_log,
                                FILENAME = '{DatabaseLogFilePath}'
                            );
                        END";

                    using (SqlCommand cmd = new(createDbQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // Connect to the newly created database and create tables
                string dbConnection = ConnectionString;

                using (SqlConnection connection = new(dbConnection))
                {
                    connection.Open();

                    // Create users table
                    string createUsersTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'users')
                        BEGIN
                            CREATE TABLE users (
                                id INT PRIMARY KEY IDENTITY(1,1),
                                username VARCHAR(MAX) NULL,
                                password VARCHAR(MAX) NULL,
                                date_create DATE NULL
                            );
                        END";

                    using (SqlCommand cmd = new SqlCommand(createUsersTableQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create category table
                    string createCategoryTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'category')
                        BEGIN
                            CREATE TABLE category (
                                cate_id INT PRIMARY KEY IDENTITY(1,1),
                                user_id INT NULL,
                                cate_name VARCHAR(MAX) NULL,
                                cate_type VARCHAR(MAX) NULL,
                                cate_status VARCHAR(MAX) NULL,
                                cate_date DATE NULL DEFAULT CAST(GETDATE() AS DATE),
                                FOREIGN KEY (user_id) REFERENCES users(id)
                            );
                        END
                        ELSE IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'category' AND COLUMN_NAME = 'cate_date')
                        BEGIN
                            ALTER TABLE category ADD cate_date DATE NULL DEFAULT CAST(GETDATE() AS DATE);
                        END";

                    using (SqlCommand cmd = new SqlCommand(createCategoryTableQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Add user_id column to category table if it doesn't exist
                    string addUserIdToCategoryQuery = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'category' AND COLUMN_NAME = 'user_id')
                        BEGIN
                            ALTER TABLE category ADD user_id INT NULL;
                        END";

                    using (SqlCommand cmd = new SqlCommand(addUserIdToCategoryQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create transactions table
                    string createTransactionsTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'transactions')
                        BEGIN
                            CREATE TABLE transactions (
                                trans_id INT PRIMARY KEY IDENTITY(1,1),
                                user_id INT NOT NULL,
                                cate_id INT NOT NULL,
                                trans_type VARCHAR(MAX) NULL,
                                trans_amount DECIMAL(18, 2) NULL,
                                trans_description VARCHAR(MAX) NULL,
                                trans_date DATE NULL,
                                FOREIGN KEY (user_id) REFERENCES users(id),
                                FOREIGN KEY (cate_id) REFERENCES category(cate_id)
                            );
                        END";

                    using (SqlCommand cmd = new SqlCommand(createTransactionsTableQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }
    }
}
