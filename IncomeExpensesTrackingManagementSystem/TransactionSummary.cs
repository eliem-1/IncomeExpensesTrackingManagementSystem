using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Provides transaction summary and reporting functionality.
    /// Aggregates financial data for analysis and reporting.
    /// </summary>
    internal class TransactionSummary
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;

        /// <summary>
        /// Represents a monthly summary of income and expenses.
        /// </summary>
        public class MonthlySummary
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public decimal TotalIncome { get; set; }
            public decimal TotalExpenses { get; set; }
            public decimal NetAmount => TotalIncome - TotalExpenses;
            public decimal SavingsRate => TotalIncome > 0 ? (NetAmount / TotalIncome) * 100 : 0;
        }

        /// <summary>
        /// Represents a category expense summary.
        /// </summary>
        public class CategoryExpenseSum
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; } = string.Empty;
            public decimal TotalAmount { get; set; }
            public int TransactionCount { get; set; }
            public decimal AverageAmount => TransactionCount > 0 ? TotalAmount / TransactionCount : 0;
        }

        /// <summary>
        /// Gets monthly income and expense summary for a user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="monthsBack">Number of months to look back (default: 12).</param>
        /// <returns>List of monthly summaries.</returns>
        public List<MonthlySummary> GetMonthlySummary(int userId, int monthsBack = 12)
        {
            var monthlySummaries = new List<MonthlySummary>();

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string query = @"
                    SELECT 
                        YEAR(trans_date) AS Year,
                        MONTH(trans_date) AS Month,
                        SUM(CASE WHEN trans_type = 'Income' THEN trans_amount ELSE 0 END) AS TotalIncome,
                        SUM(CASE WHEN trans_type = 'Expense' THEN trans_amount ELSE 0 END) AS TotalExpenses
                    FROM transactions
                    WHERE user_id = @user_id 
                        AND trans_date >= DATEADD(MONTH, -@months_back, GETDATE())
                    GROUP BY YEAR(trans_date), MONTH(trans_date)
                    ORDER BY Year DESC, Month DESC";

                using var cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@months_back", monthsBack);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    monthlySummaries.Add(new MonthlySummary
                    {
                        Year = (int)reader["Year"],
                        Month = (int)reader["Month"],
                        TotalIncome = Convert.ToDecimal(reader["TotalIncome"] ?? 0m),
                        TotalExpenses = Convert.ToDecimal(reader["TotalExpenses"] ?? 0m)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving monthly summary: {ex.Message}", ex);
            }

            return monthlySummaries;
        }

        /// <summary>
        /// Gets top spending categories for a user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="topCount">Number of top categories to return (default: 5).</param>
        /// <returns>List of category expense summaries.</returns>
        public List<CategoryExpenseSum> GetTopExpenseCategories(int userId, int topCount = 5)
        {
            var categories = new List<CategoryExpenseSum>();

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string query = @"
                    SELECT TOP(@top_count)
                        c.cate_id AS CategoryId,
                        c.cate_name AS CategoryName,
                        SUM(t.trans_amount) AS TotalAmount,
                        COUNT(t.trans_id) AS TransactionCount
                    FROM transactions t
                    INNER JOIN category c ON t.cate_id = c.cate_id
                    WHERE t.user_id = @user_id AND t.trans_type = 'Expense'
                    GROUP BY c.cate_id, c.cate_name
                    ORDER BY TotalAmount DESC";

                using var cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@top_count", topCount);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new CategoryExpenseSum
                    {
                        CategoryId = (int)reader["CategoryId"],
                        CategoryName = reader["CategoryName"]?.ToString() ?? string.Empty,
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"] ?? 0m),
                        TransactionCount = (int)reader["TransactionCount"]
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving top expense categories: {ex.Message}", ex);
            }

            return categories;
        }

        /// <summary>
        /// Gets the number of transactions for a specific period.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="transactionType">Type of transaction ('Income', 'Expense', or null for both).</param>
        /// <param name="daysBack">Number of days to look back.</param>
        /// <returns>Transaction count.</returns>
        public int GetTransactionCount(int userId, string? transactionType = null, int daysBack = 30)
        {
            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string query = "SELECT COUNT(*) FROM transactions WHERE user_id = @user_id AND trans_date >= DATEADD(DAY, -@days_back, GETDATE())";
                
                if (!string.IsNullOrEmpty(transactionType))
                    query += " AND trans_type = @trans_type";

                using var cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@days_back", daysBack);
                
                if (!string.IsNullOrEmpty(transactionType))
                    cmd.Parameters.AddWithValue("@trans_type", transactionType);

                object result = cmd.ExecuteScalar() ?? 0;
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving transaction count: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets average transaction amount for a specific period.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="transactionType">Type of transaction ('Income' or 'Expense').</param>
        /// <param name="daysBack">Number of days to look back.</param>
        /// <returns>Average transaction amount.</returns>
        public decimal GetAverageTransactionAmount(int userId, string transactionType, int daysBack = 30)
        {
            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                string query = "SELECT ISNULL(AVG(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = @trans_type AND trans_date >= DATEADD(DAY, -@days_back, GETDATE())";

                using var cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@trans_type", transactionType);
                cmd.Parameters.AddWithValue("@days_back", daysBack);

                object result = cmd.ExecuteScalar() ?? 0m;
                return Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating average transaction amount: {ex.Message}", ex);
            }
        }
    }
}
