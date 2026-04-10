using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Represents an income transaction in the system.
    /// Handles database operations for income management.
    /// </summary>
    internal class IncomeData
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;

        /// <summary>
        /// Gets or sets the transaction ID.
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with this income.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the category ID for this income.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the income amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the description of the income.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the income.
        /// </summary>
        public DateTime IncomeDate { get; set; }

        /// <summary>
        /// Retrieves all income entries for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of IncomeData objects for the user.</returns>
        public List<IncomeData> GetIncomeByUserId(int userId)
        {
            var incomeList = new List<IncomeData>();

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(
                    "SELECT trans_id, user_id, cate_id, trans_amount, trans_description, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Income' ORDER BY trans_date DESC",
                    connect);
                cmd.Parameters.AddWithValue("@user_id", userId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    incomeList.Add(MapReaderToIncome(reader));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving income list: {ex.Message}", ex);
            }

            return incomeList;
        }

        /// <summary>
        /// Maps SqlDataReader data to an IncomeData object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing income data.</param>
        /// <returns>A populated IncomeData object.</returns>
        private static IncomeData MapReaderToIncome(SqlDataReader reader)
        {
            return new IncomeData
            {
                TransactionId = (int)reader["trans_id"],
                UserId = (int)reader["user_id"],
                CategoryId = (int)reader["cate_id"],
                Amount = (decimal)reader["trans_amount"],
                Description = reader["trans_description"]?.ToString() ?? string.Empty,
                IncomeDate = reader["trans_date"] is DBNull ? DateTime.Now : (DateTime)reader["trans_date"]
            };
        }

        /// <summary>
        /// Adds a new income entry to the database.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="categoryId">The category ID.</param>
        /// <param name="amount">The income amount.</param>
        /// <param name="description">The income description.</param>
        /// <param name="incomeDate">The date of the income.</param>
        /// <returns>True if the income was successfully added; otherwise, false.</returns>
        public bool AddIncome(int userId, int categoryId, decimal amount, string description, DateTime incomeDate)
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
                cmd.Parameters.AddWithValue("@trans_type", "Income");
                cmd.Parameters.AddWithValue("@trans_amount", amount);
                cmd.Parameters.AddWithValue("@trans_description", description?.Trim() ?? string.Empty);
                cmd.Parameters.AddWithValue("@trans_date", incomeDate.Date);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding income: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing income entry in the database.
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to update.</param>
        /// <param name="categoryId">The new category ID.</param>
        /// <param name="amount">The new amount.</param>
        /// <param name="description">The new description.</param>
        /// <param name="incomeDate">The new date.</param>
        /// <returns>True if the income was successfully updated; otherwise, false.</returns>
        public bool UpdateIncome(int transactionId, int categoryId, decimal amount, string description, DateTime incomeDate)
        {
            if (transactionId <= 0 || categoryId <= 0 || amount <= 0)
                throw new ArgumentException("Invalid transaction ID, category ID, or amount.");

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string updateQuery = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND trans_type = 'Income'";

                using var cmd = new SqlCommand(updateQuery, connect);
                cmd.Parameters.AddWithValue("@trans_id", transactionId);
                cmd.Parameters.AddWithValue("@cate_id", categoryId);
                cmd.Parameters.AddWithValue("@trans_amount", amount);
                cmd.Parameters.AddWithValue("@trans_description", description?.Trim() ?? string.Empty);
                cmd.Parameters.AddWithValue("@trans_date", incomeDate.Date);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating income: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes an income entry from the database.
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to delete.</param>
        /// <returns>True if the income was successfully deleted; otherwise, false.</returns>
        public bool DeleteIncome(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Transaction ID must be greater than 0.");

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string deleteQuery = "DELETE FROM transactions WHERE trans_id = @trans_id AND trans_type = 'Income'";

                using var cmd = new SqlCommand(deleteQuery, connect);
                cmd.Parameters.AddWithValue("@trans_id", transactionId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting income: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the total amount of income for a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>The total income amount.</returns>
        public decimal GetTotalIncome(int userId)
        {
            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand(
                    "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Income'",
                    connect);
                cmd.Parameters.AddWithValue("@user_id", userId);

                object result = cmd.ExecuteScalar() ?? 0m;
                return Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating total income: {ex.Message}", ex);
            }
        }
    }
}
