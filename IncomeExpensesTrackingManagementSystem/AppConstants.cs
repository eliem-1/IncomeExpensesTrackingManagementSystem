namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Contains all application constants for messages, database queries, and configuration values.
    /// </summary>
    internal static class AppConstants
    {
        // Error Messages
        public const string ErrorTitle = "Error Message";
        public const string WarningTitle = "Warning Message";
        public const string InfoTitle = "Information Message";
        public const string ConfirmationTitle = "Confirmation Message";

        public const string FillAllFieldsError = "Please fill all blank fields";
        public const string InvalidAmountError = "Please enter a valid amount";
        public const string PasswordMismatchError = "Password does not match";
        public const string PasswordTooShortError = "Invalid password, at least 8 characters are needed";
        public const string UserExistsError = " is existing already";
        public const string InvalidCategoryError = "Please select a valid category";
        public const string SelectValidCategoryError = "Please select a valid category";
        public const string LoadingCategoriesError = "Error loading categories: ";
        public const string SelectCategoryError = "Please select a category to update";

        // Success Messages
        public const string RegisteredSuccessfully = "Registered successfully!";
        public const string LoginSuccessfully = "Login successfully!";
        public const string CategoryAddedSuccessfully = "Category added successfully!";
        public const string CategoryUpdatedSuccessfully = "Category updated successfully!";
        public const string CategoryDeletedSuccessfully = "Category deleted successfully!";
        public const string TransactionAddedSuccessfully = "Transaction added successfully!";
        public const string TransactionDeletedSuccessfully = "Transaction deleted successfully!";

        // Confirmation Messages
        public const string ConfirmCloseApplication = "Are you sure you want to close?";
        public const string ConfirmLogout = "Are you sure you want to logout?";
        public const string ConfirmDeleteTransaction = "Are you sure you want to delete this transaction?";
        public const string ConfirmDeleteCategory = "Are you sure you want to delete this category?";

        // Database Queries
        public const string SelectUserByUsername = "SELECT id, password FROM users WHERE username = @usern";
        public const string CheckUserExists = "SELECT * FROM users WHERE username = @usern";
        public const string InsertUser = "INSERT INTO users (username, password, date_create) VALUES(@usern, @pass, @date)";
        public const string UpdateUserPassword = "UPDATE users SET password = @new_pass WHERE id = @id";

        public const string SelectAllCategories = "SELECT * FROM category WHERE user_id = @user_id";
        public const string SelectIncomeCategories = "SELECT cate_id, cate_name FROM category WHERE user_id = @user_id AND cate_type = 'Income' AND cate_status = 'Active'";
        public const string SelectExpenseCategories = "SELECT cate_id, cate_name FROM category WHERE user_id = @user_id AND cate_type IN ('Expense', 'Expenses') AND cate_status = 'Active'";
        public const string InsertCategory = "INSERT INTO category (user_id, cate_name, cate_type, cate_status) VALUES (@user_id, @cate_name, @cate_type, @cate_status)";
        public const string UpdateCategory = "UPDATE category SET cate_name = @cate_name, cate_type = @cate_type, cate_status = @cate_status WHERE cate_id = @cate_id AND user_id = @user_id";
        public const string DeleteCategory = "DELETE FROM category WHERE cate_id = @cate_id AND user_id = @user_id";
        public const string SelectCategoryById = "SELECT * FROM category WHERE cate_id = @cate_id AND user_id = @user_id";

        public const string SelectIncomeTransactions = "SELECT trans_id, cate_id, trans_description, trans_amount, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Income' ORDER BY trans_date DESC";
        public const string SelectExpenseTransactions = "SELECT trans_id, cate_id, trans_description, trans_amount, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense' ORDER BY trans_date DESC";
        public const string InsertTransaction = "INSERT INTO transactions (user_id, cate_id, trans_type, trans_amount, trans_description, trans_date) VALUES (@user_id, @cate_id, @trans_type, @trans_amount, @trans_description, @trans_date)";
        public const string DeleteTransaction = "DELETE FROM transactions WHERE trans_id = @trans_id";

        public const string SelectTotalIncome = "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Income'";
        public const string SelectTotalExpense = "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense'";
        public const string SelectNetBalance = "SELECT ISNULL(SUM(CASE WHEN trans_type = 'Income' THEN trans_amount ELSE -trans_amount END), 0) FROM transactions WHERE user_id = @user_id";

        // Parameter Names
        public const string ParamUsername = "@usern";
        public const string ParamPassword = "@pass";
        public const string ParamNewPassword = "@new_pass";
        public const string ParamId = "@id";
        public const string ParamUserId = "@user_id";
        public const string ParamCategoryId = "@cate_id";
        public const string ParamCategoryName = "@cate_name";
        public const string ParamCategoryType = "@cate_type";
        public const string ParamCategoryStatus = "@cate_status";
        public const string ParamDate = "@date";
        public const string ParamTransactionId = "@trans_id";
        public const string ParamTransactionType = "@trans_type";
        public const string ParamAmount = "@trans_amount";
        public const string ParamDescription = "@trans_description";
        public const string ParamTransDate = "@trans_date";

        // Column Names
        public const string ColumnId = "id";
        public const string ColumnPassword = "password";
        public const string ColumnCategoryId = "cate_id";
        public const string ColumnCategoryName = "cate_name";
        public const string ColumnAmount = "trans_amount";
        public const string ColumnTransactionId = "trans_id";

        // Category Types
        public const string CategoryTypeIncome = "Income";
        public const string CategoryTypeExpenses = "Expenses";
        public const string CategoryTypeExpense = "Expense";

        // Transaction Types
        public const string TransactionTypeIncome = "Income";
        public const string TransactionTypeExpense = "Expense";

        // Status
        public const string StatusActive = "Active";
        public const string StatusInactive = "Inactive";

        // Currency Format
        public const string CurrencyFormat = "C2";

        // Password
        public const int MinimumPasswordLength = 8;

        // Timeout
        public const int ConnectionTimeout = 30;
    }
}
