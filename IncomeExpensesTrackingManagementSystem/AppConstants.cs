namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Contains all application constants for messages, database queries, and configuration values.
    /// </summary>
    internal static class AppConstants
    {
        // Error Messages
        public const string ErrorTitle = "Error Message";
        public const string InfoTitle = "Information Message";
        public const string ConfirmationTitle = "Confirmation Message";

        public const string FillAllFieldsError = "Please fill all blank fields";
        public const string InvalidAmountError = "Please enter a valid amount";
        public const string PasswordMismatchError = "Password does not match";
        public const string PasswordTooShortError = "Invalid password, at least 8 characters are needed";
        public const string UserExistsError = " is existing already";
        public const string SelectValidCategoryError = "Please select a valid category";
        public const string IncorrectCredentialsError = "Incorrect username/password.";
        public const string LoadingCategoriesError = "Error loading categories: ";
        public const string SelectCategoryError = "Please select a category to update";
        public const string SelectCategoryToDeleteError = "Please select a category to delete";
        public const string SelectValidIncomeRecordError = "Please select a valid income record";
        public const string SelectIncomeToDeleteError = "Please select an income record to delete";
        public const string SelectIncomeToUpdateError = "Please select an income record to update";
        public const string SelectValidExpenseRecordError = "Please select a valid expense record";
        public const string SelectExpenseToDeleteError = "Please select an expense record to delete";
        public const string SelectExpenseToUpdateError = "Please select an expense record to update";

        // Success Messages
        public const string RegisteredSuccessfully = "Registered successfully!";
        public const string LoginSuccessfully = "Login successfully!";
        public const string CategoryAddedSuccessfully = "Category added successfully!";
        public const string CategoryUpdatedSuccessfully = "Category updated successfully!";
        public const string CategoryDeletedSuccessfully = "Category deleted successfully!";
        public const string TransactionDeletedSuccessfully = "Transaction deleted successfully!";
        public const string IncomeAddedSuccessfully = "Income added successfully!";
        public const string IncomeUpdatedSuccessfully = "Income updated successfully!";
        public const string ExpenseAddedSuccessfully = "Expense added successfully!";
        public const string ExpenseUpdatedSuccessfully = "Expense updated successfully!";

        // Confirmation Messages
        public const string ConfirmCloseApplication = "Are you sure you want to close?";
        public const string ConfirmLogout = "Are you sure you want to logout?";
        public const string ConfirmDeleteTransaction = "Are you sure you want to delete this transaction?";
        public const string ConfirmDeleteCategory = "Are you sure you want to delete this category?";
        public const string ConfirmUpdateCategory = "Are you sure you want to update this category?";

        // Failure Messages
        public const string CategoryAddFailedError = "Failed to add category";
        public const string CategoryUpdateFailedError = "Failed to update category";
        public const string CategoryDeleteFailedError = "Failed to delete category";

        // Database Queries
        public const string SelectUserByUsername = "SELECT id, password FROM users WHERE username = @usern";
        public const string CheckUserExists = "SELECT * FROM users WHERE username = @usern";
        public const string InsertUser = "INSERT INTO users (username, password, date_create) VALUES(@usern, @pass, @date)";
        public const string UpdateUserPassword = "UPDATE users SET password = @new_pass WHERE id = @id";

        public const string SelectAllCategories = "SELECT * FROM category WHERE user_id = @user_id";
        public const string SelectIncomeCategories = "SELECT cate_id, cate_name FROM category WHERE user_id = @user_id AND cate_type IN ('Income', 'Incomes') AND cate_status = 'Active'";
        public const string SelectExpenseCategories = "SELECT cate_id, cate_name FROM category WHERE user_id = @user_id AND cate_type IN ('Expense', 'Expenses') AND cate_status = 'Active'";
        public const string InsertCategory = "INSERT INTO category (user_id, cate_name, cate_type, cate_status) VALUES (@user_id, @cate_name, @cate_type, @cate_status)";
        public const string UpdateCategory = "UPDATE category SET cate_name = @cate_name, cate_type = @cate_type, cate_status = @cate_status WHERE cate_id = @cate_id AND user_id = @user_id";
        public const string DeleteCategory = "DELETE FROM category WHERE cate_id = @cate_id AND user_id = @user_id";

        public const string SelectIncomeTransactions = "SELECT trans_id, cate_id, trans_description, trans_amount, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Income' ORDER BY trans_date DESC";
        public const string SelectExpenseTransactions = "SELECT trans_id, cate_id, trans_description, trans_amount, trans_date FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense' ORDER BY trans_date DESC";
        public const string InsertTransaction = "INSERT INTO transactions (user_id, cate_id, trans_type, trans_amount, trans_description, trans_date) VALUES (@user_id, @cate_id, @trans_type, @trans_amount, @trans_description, @trans_date)";
        public const string UpdateIncomeTransaction = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND user_id = @user_id AND trans_type = 'Income'";
        public const string UpdateExpenseTransaction = "UPDATE transactions SET cate_id = @cate_id, trans_amount = @trans_amount, trans_description = @trans_description, trans_date = @trans_date WHERE trans_id = @trans_id AND user_id = @user_id AND trans_type = 'Expense'";
        public const string DeleteTransaction = "DELETE FROM transactions WHERE trans_id = @trans_id AND user_id = @user_id";

        public const string SelectTotalIncome = "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Income'";
        public const string SelectTotalExpense = "SELECT ISNULL(SUM(trans_amount), 0) FROM transactions WHERE user_id = @user_id AND trans_type = 'Expense'";

        // Dashboard Period Queries
        public const string SelectTodayIncome = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND CAST(trans_date AS DATE)=CAST(GETDATE() AS DATE)";
        public const string SelectYesterdayIncome = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND CAST(trans_date AS DATE)=CAST(DATEADD(DAY,-1,GETDATE()) AS DATE)";
        public const string SelectMonthlyIncome = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND MONTH(trans_date)=MONTH(GETDATE()) AND YEAR(trans_date)=YEAR(GETDATE())";
        public const string SelectYearlyIncome = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Income' AND YEAR(trans_date)=YEAR(GETDATE())";
        public const string SelectTodayExpense = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND CAST(trans_date AS DATE)=CAST(GETDATE() AS DATE)";
        public const string SelectYesterdayExpense = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND CAST(trans_date AS DATE)=CAST(DATEADD(DAY,-1,GETDATE()) AS DATE)";
        public const string SelectMonthlyExpense = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND MONTH(trans_date)=MONTH(GETDATE()) AND YEAR(trans_date)=YEAR(GETDATE())";
        public const string SelectYearlyExpense = "SELECT ISNULL(SUM(trans_amount),0) FROM transactions WHERE user_id=@user_id AND trans_type='Expense' AND YEAR(trans_date)=YEAR(GETDATE())";

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

        // Date Format
        public const string DateFormat = "MM-dd-yyyy";

        // Password
        public const int MinimumPasswordLength = 8;

        }
}
