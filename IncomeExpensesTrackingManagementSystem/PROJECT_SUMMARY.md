# Income & Expenses Tracking Management System - Project Summary

## 📊 Project Overview

A comprehensive C# .NET 10 Windows Forms application for tracking personal income and expenses. The application provides user authentication, category management, transaction tracking, and financial dashboard with balance calculations.

**Repository:** https://github.com/eliem-1/IncomeExpensesTrackingManagementSystem

---

## 🏗️ Architecture

### Layered Architecture
```
Presentation Layer (UI Forms)
    ├── MainForm (Main navigation hub)
    ├── DashboardForm (Financial overview)
    ├── IncomeForm (Income transactions)
    ├── CategoryForm (Category management)
    ├── Form1 (Login)
    └── RegisterForm (User registration)
         ↓
Business Logic Layer (Data Classes)
    ├── IncomeData (Income operations)
    ├── ExpenseData (Expense operations)
    ├── CategoryData (Category operations)
    └── PasswordHasher (Authentication)
         ↓
Data Access Layer (Database)
    └── SQL Server LocalDB
        ├── users table
        ├── category table
        └── transactions table
```

---

## 📁 Project Structure

### Core Forms
- **Form1.cs** - Login form with authentication
- **RegisterForm.cs** - User registration
- **MainForm.cs** - Main application hub with navigation
- **DashboardForm.cs** - Financial overview (Total Income, Expenses, Balance)
- **CategoryForm.cs** - Category CRUD operations
- **IncomeForm.cs** - Income transaction management

### Data Access Layer
- **CategoryData.cs** - Category database operations with helper methods
- **IncomeData.cs** - Income transaction operations
- **ExpenseData.cs** - Expense transaction operations

### Utilities
- **DatabaseSetup.cs** - Database initialization and schema creation
- **PasswordHasher.cs** - Secure password hashing
- **CategoryItem.cs** - Data model for categories in ComboBox
- **AppConstants.cs** - Application-wide constants
- **ExtensionMethods.cs** - Extension methods for common operations

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
    cate_date DATE NULL DEFAULT GETDATE(),
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
- ✅ User login with password hashing
- ✅ New user registration
- ✅ Secure session management

### Transaction Management
- ✅ Add income transactions
- ✅ Add expense transactions
- ✅ View all transactions with filtering
- ✅ Edit existing transactions
- ✅ Delete transactions
- ✅ Automatic date tracking

### Category Management
- ✅ Create categories (Income/Expense)
- ✅ Mark categories as Active/Inactive
- ✅ Automatic creation date tracking
- ✅ Category assignment to transactions
- ✅ User-specific categories (each user manages their own)

### Financial Dashboard
- ✅ Total income calculation
- ✅ Total expenses calculation
- ✅ Net balance (Income - Expenses)
- ✅ Real-time updates
- ✅ Currency formatting (USD)

### Data Formatting
- ✅ Currency format: **C2** (e.g., $1,234.56)
- ✅ Date format: **MM-dd-yyyy** (e.g., 01-15-2025)
- ✅ Culture: **US English** (en-US)

---

## 🔒 Security Features

### Implemented
- ✅ SQL parameterized queries (prevents SQL injection)
- ✅ Password hashing (PasswordHasher.cs)
- ✅ User-specific data isolation
- ✅ Input validation and sanitization

### Best Practices Applied
- ✅ Null coalescing operators (`??`)
- ✅ Null-conditional operators (`?.`)
- ✅ Type checking with `is` patterns
- ✅ Safe casting and conversion

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

### IncomeData.cs
```csharp
// Retrieves all income for a user
List<IncomeData> GetIncomeByUserId(int userId)

// Adds income transaction
bool AddIncome(int userId, int categoryId, decimal amount, string description, DateTime incomeDate)

// Updates income transaction
bool UpdateIncome(int transactionId, int categoryId, decimal amount, string description, DateTime incomeDate)

// Deletes income transaction
bool DeleteIncome(int transactionId)

// Gets total income for user
decimal GetTotalIncome(int userId)
```

### ExpenseData.cs
```csharp
// Retrieves all expenses for a user
List<ExpenseData> GetExpensesByUserId(int userId)

// Adds expense transaction
bool AddExpense(int userId, int categoryId, decimal amount, string description, DateTime expenseDate)

// Updates expense transaction
bool UpdateExpense(int transactionId, int categoryId, decimal amount, string description, DateTime expenseDate)

// Deletes expense transaction
bool DeleteExpense(int transactionId)

// Gets total expenses for user
decimal GetTotalExpenses(int userId)
```

---

## 🔧 Form Usage

### MainForm - Initialize with User Data
```csharp
// After user login
MainForm mainForm = new();
mainForm.SetUserId(userId);  // Load user-specific data
mainForm.Show();
```

### IncomeForm - Load User Income
```csharp
incomeForm.SetUserId(userId);
incomeForm.LoadIncomeData();  // Displays income list in DataGridView
```

### DashboardForm - Display Totals
```csharp
dashboardForm.SetUserId(userId);
dashboardForm.LoadDashboardData();  // Calculates and displays totals
```

### CategoryForm - Browse Categories
```csharp
categoryForm.SetUserId(userId);   // Set user context
categoryForm.LoadCategories();    // Displays user's categories
```

---

## 📊 Recent Improvements

### Latest Session (Current)
✅ **User Data Isolation** - Categories now scoped per user (user_id added to category table)
✅ Updated **CategoryData.cs** - All methods accept userId for user-specific queries
✅ Updated **CategoryForm.cs** - Added SetUserId() method for user context
✅ Updated **IncomeForm.cs** & **ExpenseForm.cs** - Category loading filtered by user
✅ Updated **DatabaseSetup.cs** - Migration to add user_id column to existing databases
✅ Added **Dashboard Total Balance** - Net balance with color-coded display
✅ Fixed date formatting on DateTimePicker controls

### Previous Improvements
✅ Created **IncomeData.cs** - Comprehensive data layer for income transactions
✅ Created **ExpenseData.cs** - Comprehensive data layer for expense transactions
✅ Enhanced **IncomeForm.cs** - Added SetUserId() and LoadIncomeData() methods
✅ Improved **MainForm.cs** - Added SetUserId() and InitializeUserForms() methods
✅ Added category date tracking (cate_date column)
✅ Refactored CategoryData.cs with helper methods
✅ Applied DRY principles to eliminate code duplication
✅ Removed duplicate methods (GetCategoryList vs categoryListData)
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
4. User enters credentials
   ↓
5. MainForm opens with SetUserId(userId)
   ↓
6. MainForm.InitializeUserForms() loads all user data
   ↓
7. User navigates between:
   - Dashboard (view totals)
   - Income (view/manage income)
   - Categories (manage categories)
   ↓
8. Logout returns to login screen
```

---

## 📈 Extensibility

### To Add New Features
1. Create new UserControl in Forms
2. Create corresponding Data class for database operations
3. Add methods to Data class for CRUD operations
4. Use parameterized queries for security
5. Implement proper error handling
6. Add XML documentation

### Example: Adding Savings Goals
```csharp
// 1. Create SavingsGoalData.cs
internal class SavingsGoalData
{
    public bool AddGoal(int userId, string goalName, decimal targetAmount)
    { /* Implementation */ }
}

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

- No expense form in current build (ExpenseData.cs ready for implementation)
- Dashboard calculations performed in memory (could be optimized with stored procedures)
- No data export functionality (CSV, PDF)
- No recurring transaction automation
- No budget alerts/notifications

---

## 📞 Support & Contribution

For issues, suggestions, or contributions, please visit:
**https://github.com/eliem-1/IncomeExpensesTrackingManagementSystem**

---

## 📅 Version History

- **v1.0.0** - Core functionality (Auth, Categories, Transactions, Dashboard)
- **v1.1.0** - Added category date tracking, improved data layers
- **v1.2.0** - Added IncomeData, ExpenseData, enhanced form initialization
- **Latest** - Full documentation and architecture improvements

---

## 📝 Notes

- All dates are stored in **DATE** format (no time component)
- All amounts use **DECIMAL(18, 2)** for financial accuracy
- Passwords are hashed using custom PasswordHasher
- All UI updates happen on the UI thread (no async operations currently)
- Database connection pooling handled by SQL Server LocalDB

---

**Last Updated:** January 2025
**Project Status:** Active Development ✅
