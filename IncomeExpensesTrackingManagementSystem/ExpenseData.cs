using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Represents an expense transaction in the system.
    /// Handles database operations for expense management.
    /// </summary>
    internal class ExpenseData
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;

        /// <summary>
        /// Gets or sets the transaction ID.
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with this expense.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the category ID for this expense.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the expense amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the description of the expense.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the expense.
        /// </summary>
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// Retrieves all expenses for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of ExpenseData objects for the user.</returns>
        public List<ExpenseData> GetExpensesByUserId(int userId)
        {
            var expenseList = new List<ExpenseData>();

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(
                    "SELECT trans_id, user_id, cate_id, trans_amount, trans_description, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense' ORDER BY trans_date DESC",
                    connect);
                cmd.Parameters.AddWithValue("@user_id", userId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    expenseList.Add(MapReaderToExpense(reader));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving expense list: {ex.Message}", ex);
            }

            return expenseList;
        }

        /// <summary>
        /// Maps SqlDataReader data to an ExpenseData object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing expense data.</param>
        /// <returns>A populated ExpenseData object.</returns>
        private static ExpenseData MapReaderToExpense(SqlDataReader reader)
        {
            return new ExpenseData
            {
                TransactionId = (int)reader["trans_id"],
                UserId = (int)reader["user_id"],
                CategoryId = (int)reader["cate_id"],
                Amount = (decimal)reader["trans_amount"],
                Description = reader["trans_description"]?.ToString() ?? string.Empty,
                ExpenseDate = reader["trans_date"] is DBNull ? DateTime.Now : (DateTime)reader["trans_date"]
            };
        }

        /// <summary>
        /// Adds a new expense to the database.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="categoryId">The category ID.</param>
        /// <param name="amount">The expense amount.</param>
        /// <param name="description">The expense description.</param>
        /// <param name="expenseDate">The date of the expense.</param>
        /// <returns>True if the expense was successfully added; otherwise, false.</returns>
        public bool AddExpense(int userId, int categoryId, decimal amount, string description, DateTime expenseDate)
        {
            if (userId <= 0 || categoryId <= 0 || amount <= 0)
                throw new ArgumentException("Invalid user ID, category ID, or amount.");

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string insertQuery = "INSERT INTO transactions (user_id, cate_id, trans_type, trans_amount, trans_description, trans_date) VALUES (@user_id, @cate_id, @trans_type, @trans_amount, @trans_description, @trans_date)";

                using var cmd = new SqlCommand(insertQuery, connect);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@cate_id", categoryId);
                cmd.Parameters.AddWithValue("@trans_type", "Expense");
                cmd.Parameters.AddWithValue("@trans_amount", amount);
                cmd.Parameters.AddWithValue("@trans_description", description?.Trim() ?? string.Empty);
                cmd.Parameters.AddWithValue("@trans_date", expenseDate.Date);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding expense: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing expense in the database.
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to update.</param>
        /// <param name="categoryId">The new category ID.</param>
        /// <param name="amount">The new amount.</param>
        /// <param name="description">The new description.</param>
        /// <param name="expenseDate">The new date.</param>
        /// <returns>True if the expense was successfully updated; otherwise, false.</returns>
        public bool UpdateExpense(int transactionId, int categoryId, decimal amount, string description, DateTime expenseDate)
        {
            if (transactionId <= 0 || categoryId <= 0 || amount <= 0)
                throw new ArgumentException("Invalid transaction ID, category ID, or amount.");

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string updateQuery = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND trans_type = 'Expense'";

                using var cmd = new SqlCommand(updateQuery, connect);
                cmd.Parameters.AddWithValue("@trans_id", transactionId);
                cmd.Parameters.AddWithValue("@cate_id", categoryId);
                cmd.Parameters.AddWithValue("@trans_amount", amount);
                cmd.Parameters.AddWithValue("@trans_description", description?.Trim() ?? string.Empty);
                cmd.Parameters.AddWithValue("@trans_date", expenseDate.Date);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating expense: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes an expense from the database.
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to delete.</param>
        /// <returns>True if the expense was successfully deleted; otherwise, false.</returns>
        public bool DeleteExpense(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Transaction ID must be greater than 0.");

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string deleteQuery = "DELETE FROM transactions WHERE trans_id = @trans_id AND trans_type = 'Expense'";

                using var cmd = new SqlCommand(deleteQuery, connect);
                cmd.Parameters.AddWithValue("@trans_id", transactionId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting expense: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the total amount of expenses for a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>The total expense amount.</returns>
        public decimal GetTotalExpenses(int userId)
        {
            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(
                    "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense'",
                    connect);
                cmd.Parameters.AddWithValue("@user_id", userId);

                object result = cmd.ExecuteScalar() ?? 0m;
                return Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating total expenses: {ex.Message}", ex);
            }
        }
    }
}
