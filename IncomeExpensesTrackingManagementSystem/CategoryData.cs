using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Represents a category data model for managing income and expense categories.
    /// Handles database operations including retrieval, creation, update, and deletion of categories.
    /// </summary>
    internal class CategoryData
    {
        private readonly string _connectionString = DatabaseSetup.ConnectionString;

        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of category (e.g., "Income", "Expense", "Expenses").
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status of the category (e.g., "Active", "Inactive").
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date the category was created, formatted as "MM-dd-yyyy".
        /// </summary>
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// Retrieves a list of all categories from the database.
        /// </summary>
        /// <returns>A list of <see cref="CategoryData"/> objects representing all categories in the database.</returns>
        /// <exception cref="Exception">Thrown when a database error occurs during retrieval.</exception>
        public List<CategoryData> GetCategoryList(int userId)
        {
            var listData = new List<CategoryData>();

            try
            {
                using var connect = new SqlConnection(_connectionString);
                connect.Open();

                using var cmd = new SqlCommand("SELECT * FROM category WHERE user_id = @user_id", connect);
                cmd.Parameters.AddWithValue("@user_id", userId);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listData.Add(MapReaderToCategory(reader));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving category list: {ex.Message}", ex);
            }

            return listData;
        }

        /// <summary>
        /// Maps data from a <see cref="SqlDataReader"/> to a <see cref="CategoryData"/> object.
        /// </summary>
        /// <param name="reader">The <see cref="SqlDataReader"/> containing the category data.</param>
        /// <returns>A new <see cref="CategoryData"/> object populated with values from the reader.</returns>
        private static CategoryData MapReaderToCategory(SqlDataReader reader)
        {
            DateTime? dateValue = null;
            if (reader["cate_date"] != DBNull.Value && reader["cate_date"] is DateTime date)
            {
                dateValue = date;
            }

            return new CategoryData
            {
                ID = (int)reader["cate_id"],
                Category = reader["cate_name"]?.ToString() ?? string.Empty,
                Type = reader["cate_type"]?.ToString() ?? string.Empty,
                Status = reader["cate_status"]?.ToString() ?? string.Empty,
                Date = dateValue?.ToString("MM-dd-yyyy") ?? string.Empty
            };
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="name">The name of the category to add.</param>
        /// <param name="type">The type of category (e.g., "Income", "Expense").</param>
        /// <param name="status">The status of the category (e.g., "Active", "Inactive").</param>
        /// <returns>True if the category was successfully added; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown when any parameter is null, empty, or whitespace.</exception>
        /// <exception cref="Exception">Thrown when a database error occurs during insertion.</exception>
        public bool AddCategory(int userId, string name, string type, string status)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.");
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Name, type, and status cannot be null or empty.");

            try
            {
                string insertQuery = "INSERT INTO category (user_id, cate_name, cate_type, cate_status) VALUES (@user_id, @cate_name, @cate_type, @cate_status)";

                var parameters = new Dictionary<string, object>
                {
                    { "@user_id", userId },
                    { "@cate_name", name.Trim() },
                    { "@cate_type", type.Trim() },
                    { "@cate_status", status.Trim() }
                };

                return ExecuteCommand(insertQuery, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the category to update.</param>
        /// <param name="name">The new name for the category.</param>
        /// <param name="type">The new type for the category.</param>
        /// <param name="status">The new status for the category.</param>
        /// <returns>True if the category was successfully updated; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown when ID is not positive or any other parameter is null, empty, or whitespace.</exception>
        /// <exception cref="Exception">Thrown when a database error occurs during update.</exception>
        public bool UpdateCategory(int userId, int id, string name, string type, string status)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.");
            if (id <= 0)
                throw new ArgumentException("Category ID must be greater than 0.");
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Name, type, and status cannot be null or empty.");

            try
            {
                string updateQuery = "UPDATE category SET cate_name = @cate_name, cate_type = @cate_type, cate_status = @cate_status WHERE cate_id = @cate_id AND user_id = @user_id";

                var parameters = new Dictionary<string, object>
                {
                    { "@user_id", userId },
                    { "@cate_id", id },
                    { "@cate_name", name.Trim() },
                    { "@cate_type", type.Trim() },
                    { "@cate_status", status.Trim() }
                };

                return ExecuteCommand(updateQuery, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        /// <returns>True if the category was successfully deleted; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown when ID is not positive.</exception>
        /// <exception cref="Exception">Thrown when a database error occurs during deletion.</exception>
        public bool DeleteCategory(int userId, int id)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.");
            if (id <= 0)
                throw new ArgumentException("Category ID must be greater than 0.");

            try
            {
                string deleteQuery = "DELETE FROM category WHERE cate_id = @cate_id AND user_id = @user_id";

                var parameters = new Dictionary<string, object>
                {
                    { "@user_id", userId },
                    { "@cate_id", id }
                };

                return ExecuteCommand(deleteQuery, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Executes a non-query SQL command (INSERT, UPDATE, or DELETE).
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">A dictionary of parameter names and values for the query.</param>
        /// <returns>The number of rows affected by the command.</returns>
        private int ExecuteCommand(string query, Dictionary<string, object> parameters)
        {
            using var connect = new SqlConnection(_connectionString);
            connect.Open();

            using var cmd = new SqlCommand(query, connect);
            foreach (var param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }

            return cmd.ExecuteNonQuery();
        }
    }
}
