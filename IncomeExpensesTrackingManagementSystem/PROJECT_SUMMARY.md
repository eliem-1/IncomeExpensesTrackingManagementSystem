# Income & Expenses Tracking Management System - Project Summary

## 📊 Project Overview

A comprehensive C# .NET 10 Windows Forms application for tracking personal income and expenses. The application provides user authentication, category management, transaction tracking, and a detailed financial dashboard with period-based breakdowns and balance calculations.

**Repository:** https://github.com/eliem-1/IncomeExpensesTrackingManagementSystem
**Target Framework:** `net10.0-windows`

---

## 🏗️ Architecture

### Layered Architecture
```
Presentation Layer (UI Forms)
    ├── MainForm (Main navigation hub)
    ├── DashboardForm (Financial overview with period breakdowns)
    ├── IncomeForm (Income transaction CRUD)
    ├── ExpenseForm (Expense transaction CRUD)
    ├── CategoryForm (Category management)
    ├── Form1 (Login)
    └── RegisterForm (User registration)
         ↓
Business Logic / Data Layer
    ├── CategoryData (Category CRUD operations)
    ├── PasswordHasher (PBKDF2-SHA256 authentication)
    ├── AppConstants (Centralized SQL queries, parameters & messages)
    ├── DatabaseSetup (Database initialization & schema migration)
    └── CategoryItem (ComboBox data model)
         ↓
Data Access Layer (Database)
    └── SQL Server LocalDB
        ├── users table
        ├── category table
        └── transactions table
```

> **Note:** Income and expense transaction operations (CRUD) are performed
> directly within `IncomeForm.cs` and `ExpenseForm.cs` using parameterized
> SQL queries defined in `AppConstants.cs`. There are no separate
> `IncomeData` / `ExpenseData` data-layer classes.

---

## 📁 Project Structure

### Core Forms
- **Form1.cs** - Login form with PBKDF2 password verification
- **RegisterForm.cs** - User registration with password hashing
- **MainForm.cs** - Main application hub with navigation and welcome banner
- **DashboardForm.cs** - Financial overview (today/yesterday/monthly/yearly + totals)
- **CategoryForm.cs** - Category CRUD operations
- **IncomeForm.cs** - Income transaction management (add/update/delete)
- **ExpenseForm.cs** - Expense transaction management (add/update/delete)

### Data & Business Logic
- **CategoryData.cs** - Category database operations with `MapReaderToCategory` helper
- **AppConstants.cs** - All SQL queries, parameter names, column names, messages, and configuration constants

### Utilities
- **DatabaseSetup.cs** - LocalDB database initialization, schema creation, and migration
- **PasswordHasher.cs** - PBKDF2 with SHA-256 password hashing and verification
- **CategoryItem.cs** - Data model for category ComboBox items (Name + Id)
- **Program.cs** - Application entry point; initializes database and launches login form

---

## 🗄️ Database Schema

### Users Table
```sql
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(MAX) NULL,
    password VARCHAR(MAX) NULL,
    date_create DATE NULL
);
```

### Category Table
```sql
CREATE TABLE category (
    cate_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NULL,                   -- Owner of the category
    cate_name VARCHAR(MAX) NULL,
    cate_type VARCHAR(MAX) NULL,        -- 'Income' or 'Expense'
    cate_status VARCHAR(MAX) NULL,      -- 'Active' or 'Inactive'
    cate_date DATE NULL DEFAULT CAST(GETDATE() AS DATE),
    FOREIGN KEY (user_id) REFERENCES users(id)
);
```

### Transactions Table
```sql
CREATE TABLE transactions (
    trans_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    cate_id INT NOT NULL,
    trans_type VARCHAR(MAX) NULL,       -- 'Income' or 'Expense'
    trans_amount DECIMAL(18, 2) NULL,
    trans_description VARCHAR(MAX) NULL,
    trans_date DATE NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (cate_id) REFERENCES category(cate_id)
);
```

---

## 🎯 Key Features

### Authentication
- ✅ User login with PBKDF2-SHA256 password verification
- ✅ New user registration with hashed password storage
- ✅ Secure session management (userId + username passed to MainForm)

### Transaction Management
- ✅ Add income transactions
- ✅ Add expense transactions
- ✅ View all transactions in DataGridView with formatting
- ✅ Edit existing transactions (inline update via grid selection)
- ✅ Delete transactions with confirmation dialog
- ✅ Automatic date tracking

### Category Management
- ✅ Create categories (Income/Expense types)
- ✅ Mark categories as Active/Inactive
- ✅ Automatic creation date tracking (`cate_date`)
- ✅ Category assignment to transactions via ComboBox
- ✅ User-specific categories (each user manages their own)

### Financial Dashboard
- ✅ **Today's** income and expenses
- ✅ **Yesterday's** income and expenses
- ✅ **This month's** income and expenses
- ✅ **This year's** income and expenses
- ✅ **Total** income, expenses, and net balance
- ✅ Color-coded balance (green for positive, red for negative)
- ✅ Real-time updates on navigation
- ✅ Currency formatting (USD)

### Data Formatting
- ✅ Currency format: **C2** (e.g., $1,234.56)
- ✅ Amount input format: **N2** (e.g., 1,234.56)
- ✅ Date format: **MM-dd-yyyy** (e.g., 01-15-2025)
- ✅ Culture: **US English** (en-US)

---

## 🔒 Security Features

### Implemented
- ✅ SQL parameterized queries (prevents SQL injection)
- ✅ PBKDF2-SHA256 password hashing with random salt (100,000 iterations)
- ✅ User-specific data isolation (all queries scoped by `user_id`)
- ✅ Input validation and sanitization
- ✅ User-scoped category and transaction delete/update operations

### Best Practices Applied
- ✅ Null coalescing operators (`??`)
- ✅ Null-conditional operators (`?.`)
- ✅ Type checking with `is` patterns
- ✅ Safe casting and conversion
- ✅ Centralized constants via `AppConstants.cs`

---

## 📝 Data Layer Methods

### CategoryData.cs
```csharp
// Retrieves all categories for a user
List<CategoryData> GetCategoryList(int userId)

// Adds a new category for a user
bool AddCategory(int userId, string name, string type, string status)

// Updates an existing category (user-scoped)
bool UpdateCategory(int userId, int id, string name, string type, string status)

// Deletes a category (user-scoped)
bool DeleteCategory(int userId, int id)
```

### IncomeForm.cs (inline SQL via AppConstants)
```csharp
// Loads income transactions into DataGridView
void LoadIncomeData()

// Loads income categories into ComboBox
void LoadIncomeCategories()

// Adds or updates an income transaction
void IncomeAddBtn_Click(...)

// Deletes selected income transaction
void IncomeDeleteBtn_Click(...)
```

### ExpenseForm.cs (inline SQL via AppConstants)
```csharp
// Loads expense transactions into DataGridView
void LoadExpenseData()

// Loads expense categories into ComboBox
void LoadExpenseCategories()

// Adds or updates an expense transaction
void ExpenseAddBtn_Click(...)

// Deletes selected expense transaction
void ExpenseDeleteBtn_Click(...)
```

### DashboardForm.cs
```csharp
// Loads all dashboard metrics (today/yesterday/monthly/yearly/totals)
void LoadDashboardData()

// Helper: executes a SUM query and returns decimal result
decimal GetAmount(SqlConnection connect, string query)
```

---

## 🔧 Form Usage

### MainForm - Initialize with User Data
```csharp
// After user login
MainForm mainForm = new();
mainForm.SetUserId(userId, username);  // Load user-specific data + welcome message
mainForm.Show();
```

### IncomeForm - Load User Income
```csharp
incomeForm.SetUserId(userId);
incomeForm.LoadIncomeData();  // Displays income list in DataGridView
```

### ExpenseForm - Load User Expenses
```csharp
expenseForm.SetUserId(userId);
expenseForm.LoadExpenseData();  // Displays expense list in DataGridView
```

### DashboardForm - Display Totals
```csharp
dashboardForm.SetUserId(userId);       // Sets user context
dashboardForm.LoadDashboardData();     // Refreshes all period-based metrics
```

### CategoryForm - Browse Categories
```csharp
categoryForm.SetUserId(userId);   // Set user context
categoryForm.LoadCategories();    // Displays user's categories
```

---

## 📊 Recent Improvements

### Latest Updates (v1.6.0)
✅ **Consistent Green Theme** - Applied green top bar (`panel1.BackColor = Color.Green`) to both `Form1` (Login) and `MainForm` with white text labels and close button
✅ **Login Page Restyled** - Green flat buttons, app icon loaded (`icons8_income_50`), Tahoma fonts, consistent color scheme matching `RegisterForm`
✅ **CategoryData Uses AppConstants** - All inline SQL queries, parameter names, and date format in `CategoryData.cs` replaced with `AppConstants` references
✅ **Dashboard Queries Centralized** - All 8 inline period-based SQL queries and currency format strings in `DashboardForm.cs` moved to `AppConstants` constants
✅ **Dead Constants Removed** - Removed unused `WarningTitle`, `TransactionAddedSuccessfully`, `SelectNetBalance`, `SelectCategoryById`, `ConnectionTimeout` from `AppConstants.cs`
✅ **New Dashboard Constants** - Added `SelectTodayIncome`, `SelectYesterdayIncome`, `SelectMonthlyIncome`, `SelectYearlyIncome`, `SelectTodayExpense`, `SelectYesterdayExpense`, `SelectMonthlyExpense`, `SelectYearlyExpense`
✅ **Title Text Unified** - All forms now use "Income and Expenses Tracker" consistently
✅ **README.md Version Synced** - Bumped to v1.5.0 to match PROJECT_SUMMARY.md

### Previous Updates (v1.5.0)
✅ **Input Validation Hardened** - `Form1.cs` and `RegisterForm.cs` now use `string.IsNullOrWhiteSpace()` instead of `== ""` to reject whitespace-only input
✅ **DatabaseQueries.sql Rebuilt** - Updated to match actual schema (`category` table with `cate_id`/`user_id`/`cate_name`/`cate_type`/`cate_status`/`cate_date` columns, `transactions` table)
✅ **Full AppConstants Coverage** - All remaining inline strings in `IncomeForm.cs`, `MainForm.cs`, and `CategoryForm.cs` now use `AppConstants` constants
✅ **DateFormat Constant** - Added `AppConstants.DateFormat` (`"MM-dd-yyyy"`) replacing repeated inline date format strings
✅ **Dead Code Removed** - Removed unused duplicate `InvalidCategoryError` constant from `AppConstants.cs`
✅ **New Constants** - Added `CategoryAddFailedError`, `CategoryUpdateFailedError`, `CategoryDeleteFailedError`, `ConfirmUpdateCategory`

### Previous Updates (v1.4.0)
✅ **Load Event Guards** - `IncomeForm_Load` and `ExpenseForm_Load` skip loading when `userId` is not yet set, preventing failed DB queries on startup
✅ **Dashboard Double-Load Fix** - `DashboardForm.SetUserId` no longer calls `LoadDashboardData()` (handled by `MainForm.InitializeUserForms`)
✅ **Secure Delete** - `AppConstants.DeleteTransaction` now includes `user_id` scoping to prevent cross-user deletion
✅ **Inline SQL Centralized** - Update and delete transaction queries in `IncomeForm` and `ExpenseForm` now use `AppConstants` constants (`UpdateIncomeTransaction`, `UpdateExpenseTransaction`, `DeleteTransaction`)
✅ **Inline Messages Centralized** - All success/error messages in `IncomeForm` and `ExpenseForm` now use `AppConstants` constants
✅ **Updated README.md** - Architecture section, editing/deleting usage instructions, version 1.4.0

### Previous Updates (v1.3.0)
✅ **Expense Form** - Full CRUD implementation (add/update/delete) with grid selection
✅ **Enhanced Dashboard** - Period-based breakdowns (today, yesterday, monthly, yearly)
✅ **Color-coded Balance** - Green for positive, red for negative net balance
✅ **Welcome Banner** - MainForm displays `Welcome, {username}` after login
✅ **AppConstants.cs** - Centralized all SQL queries, parameter names, column names, messages
✅ **User Data Isolation** - Categories and transactions scoped per user (`user_id`)
✅ **PBKDF2-SHA256 Hashing** - Secure password hashing with 100K iterations
✅ **DatabaseSetup.cs** - Migration support for `user_id` and `cate_date` columns

### Earlier Updates (v1.0–v1.2)
✅ Enhanced **IncomeForm.cs** - Added SetUserId() and LoadIncomeData() methods
✅ Improved **MainForm.cs** - Added SetUserId() and InitializeUserForms() methods
✅ Added category date tracking (`cate_date` column)
✅ Refactored **CategoryData.cs** with `MapReaderToCategory` helper
✅ Applied DRY principles to eliminate code duplication
✅ Added comprehensive XML documentation
✅ Fixed database schema column name mappings
✅ Implemented date formatting (MM-dd-yyyy)
✅ Implemented currency formatting (C2)

---

## 🚀 Getting Started

### Prerequisites
- .NET 10 Runtime
- SQL Server LocalDB
- Visual Studio 2026 Community Edition

### Installation
1. Clone the repository
2. Open in Visual Studio 2026
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

### First Time Use
1. Click "Register" to create a new account
2. Log in with your credentials
3. Use "Add Category" to create income/expense categories
4. Start tracking your income and expenses

---

## 🔄 Application Flow

```
1. User starts application
   ↓
2. DatabaseSetup.InitializeDatabase() creates/initializes database
   ↓
3. Form1 (Login) displayed
   ↓
4. User enters credentials → PasswordHasher.Verify()
   ↓
5. MainForm opens with SetUserId(userId, username)
   ↓
6. MainForm.InitializeUserForms() loads all user data
   ↓
7. User navigates between:
   - Dashboard (view period-based totals & balance)
   - Income (view/manage income transactions)
   - Expenses (view/manage expense transactions)
   - Categories (manage income/expense categories)
   ↓
8. Logout returns to login screen
```

---

## 📈 Extensibility

### To Add New Features
1. Create new UserControl form
2. Add SQL queries to `AppConstants.cs`
3. Optionally create a data class for complex operations
4. Use parameterized queries for security
5. Implement proper error handling
6. Add XML documentation
7. Wire the form into `MainForm` navigation and `InitializeUserForms()`

### Example: Adding Savings Goals
```csharp
// 1. Add queries to AppConstants.cs
public const string SelectSavingsGoals = "SELECT * FROM savings_goals WHERE user_id = @user_id";
public const string InsertSavingsGoal = "INSERT INTO savings_goals ...";

// 2. Create SavingsGoalForm.cs UserControl
public partial class SavingsGoalForm : UserControl
{
    public void SetUserId(int userId) { /* ... */ }
    public void LoadGoals() { /* ... */ }
}

// 3. Add to MainForm navigation
private void GoalsBtn_Click(object sender, EventArgs e)
{
    savingsGoalForm?.BringToFront();
    savingsGoalForm?.LoadGoals();
}
```

---

## 🐛 Known Limitations

- Dashboard calculations performed via individual SQL queries (could be optimized with stored procedures)
- No data export functionality (CSV, PDF)
- No recurring transaction automation
- No budget alerts/notifications
- No async database operations (all queries run on UI thread)

---

## 📞 Support & Contribution

For issues, suggestions, or contributions, please visit:
**https://github.com/eliem-1/IncomeExpensesTrackingManagementSystem**

---

## 📅 Version History

- **v1.0.0** - Core functionality (Auth, Categories, Transactions, Dashboard)
- **v1.1.0** - Added category date tracking, improved data layers
- **v1.2.0** - Enhanced form initialization, user-specific data isolation
- **v1.3.0** - Full Expense form, enhanced dashboard with period breakdowns, AppConstants centralization
- **v1.4.0** - Load event guards, secure user-scoped deletes, full AppConstants coverage for transaction queries and messages
- **v1.5.0** - Input validation hardened, DatabaseQueries.sql rebuilt, full AppConstants coverage, DateFormat constant, dead code cleanup
- **v1.6.0** - Consistent green UI theme, CategoryData uses AppConstants, dashboard queries centralized, dead constants removed, title text unified

---

## 📝 Notes

- All dates are stored in **DATE** format (no time component)
- All amounts use **DECIMAL(18, 2)** for financial accuracy
- Passwords are hashed using **PBKDF2-SHA256** with 100,000 iterations and random salt
- All UI updates happen on the UI thread (no async operations currently)
- Database connection pooling handled by SQL Server LocalDB
- All SQL queries are centralized in **AppConstants.cs** for maintainability
- `System.Data.SqlClient` v4.8.6 NuGet package is used for database access

---

**Last Updated:** July 2025
**Project Status:** Complete ✅
