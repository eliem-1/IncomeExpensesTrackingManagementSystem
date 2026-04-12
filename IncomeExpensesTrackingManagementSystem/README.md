# Income Expenses Tracking Management System

A Windows Forms application built with C# and .NET 10 for tracking personal income and expenses.

## Features

- **User Authentication**: Secure login and registration with PBKDF2 password hashing and automatic legacy password upgrade
- **Income Tracking**: Full CRUD operations for income transactions with category selection and date tracking
- **Expense Tracking**: Full CRUD operations for expense transactions with category selection and date tracking
- **Category Management**: Create, update, and delete transaction categories with type (Income/Expenses) and status (Active/Inactive) controls
- **User Data Isolation**: All categories, income, and expenses are scoped per user — users can only access their own data
- **Dashboard**: Financial summary with period-based breakdowns (today, yesterday, this month, this year) and color-coded net balance (green for positive, red for negative)
- **Automatic Database Setup**: Database and tables are created automatically on first run with schema migration support
- **Centralized Constants**: All SQL queries, messages, and configuration values are managed through `AppConstants`

## System Requirements

- Windows 10 or later
- .NET 10.0 Runtime
- SQL Server LocalDB (installed with Visual Studio)

## Installation

1. Clone the repository:
```bash
git clone https://github.com/eliem-1/IncomeExpensesTrackingManagementSystem.git
cd IncomeExpensesTrackingManagementSystem
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run
```

> **Note**: The database is created automatically in `%LocalAppData%\IncomeExpensesTrackingManagementSystem\Database\` on first run. No manual database setup is required.

## Project Structure

```
IncomeExpensesTrackingManagementSystem/
├── Program.cs                    # Application entry point
├── Form1.cs                      # Login form with password verification
├── RegisterForm.cs               # User registration with validation
├── MainForm.cs                   # Main navigation hub hosting all UserControls
├── DashboardForm.cs              # Financial dashboard with period breakdowns
├── IncomeForm.cs                 # Income transaction CRUD operations
├── ExpenseForm.cs                # Expense transaction CRUD operations
├── CategoryForm.cs               # Category CRUD operations
├── DatabaseSetup.cs              # Database initialization and schema migrations
├── PasswordHasher.cs             # PBKDF2-SHA256 password hashing utility
├── CategoryData.cs               # Category data access layer
├── AppConstants.cs               # Centralized SQL queries, messages, and constants
├── CategoryItem.cs               # Data model for category ComboBox items
└── DatabaseQueries.sql           # Reference SQL queries for manual database inspection
```

## Technology Stack

- **Framework**: .NET 10.0 (Windows Forms)
- **Language**: C# 14.0
- **Database**: SQL Server LocalDB
- **Security**: PBKDF2 with SHA-256 password hashing
- **Data Access**: System.Data.SqlClient with parameterized queries

## Database Schema

### Users Table
```sql
- id (INT PRIMARY KEY IDENTITY)
- username (VARCHAR MAX)
- password (VARCHAR MAX) — PBKDF2 hashed
- date_create (DATE)
```

### Category Table
```sql
- cate_id (INT PRIMARY KEY IDENTITY)
- user_id (INT FOREIGN KEY → users.id) — Owner of the category
- cate_name (VARCHAR MAX)
- cate_type (VARCHAR MAX) — 'Income' or 'Expenses'
- cate_status (VARCHAR MAX) — 'Active' or 'Inactive'
- cate_date (DATE) — Creation date (auto-set)
```

### Transactions Table
```sql
- trans_id (INT PRIMARY KEY IDENTITY)
- user_id (INT FOREIGN KEY → users.id)
- cate_id (INT FOREIGN KEY → category.cate_id)
- trans_type (VARCHAR MAX) — 'Income' or 'Expense'
- trans_amount (DECIMAL 18,2)
- trans_description (VARCHAR MAX)
- trans_date (DATE)
```

## Security Features

- **Password Hashing**: PBKDF2 with SHA-256, 100,000 iterations, 16-byte salt, 32-byte derived key
- **Constant-Time Comparison**: Uses `CryptographicOperations.FixedTimeEquals` to prevent timing attacks
- **Automatic Password Upgrade**: Legacy plain-text passwords are automatically hashed on login
- **User Data Isolation**: All queries (select, insert, update, delete) for categories and transactions are scoped by `user_id`
- **SQL Parameterization**: All database queries use parameterized commands to prevent SQL injection
- **Connection Security**: Integrated Windows authentication for database access

## Usage

### Creating an Account
1. Click "Sign Up" on the login screen
2. Enter a username and password (minimum 8 characters)
3. Confirm your password and click "Register"

### Adding Transactions
1. Navigate to the Income or Expense form using the sidebar
2. Choose a category from the dropdown (only active categories are shown)
3. Enter the amount and select a date
4. Add an optional description
5. Click "Add" to save the transaction

### Editing Transactions
1. Click on a row in the transaction grid to select it
2. The form fields populate with the selected transaction's data
3. Modify the desired fields
4. Click "Update" to save changes, or "Clear" to cancel

### Deleting Transactions
1. Select a row in the transaction grid
2. Click "Delete" and confirm the deletion

### Managing Categories
1. Navigate to "Add Category" using the sidebar
2. Enter a category name, select the type (Income/Expenses), and set the status (Active/Inactive)
3. Click "Add" to create the category
4. Click a row in the grid to select it, then use "Update" or "Delete" to modify existing categories

### Viewing Dashboard
1. Click "Dashboard" to view your financial summary
2. See today's, yesterday's, monthly, and yearly income and expenses
3. View total income, total expenses, and color-coded net balance
4. Data refreshes automatically when navigating to the dashboard

## Architecture

The application uses a **UserControl-based architecture** where `MainForm` hosts four embedded UserControls (`DashboardForm`, `IncomeForm`, `ExpenseForm`, `CategoryForm`) and manages navigation between them. Each form receives the current user ID via `SetUserId()` and loads its data independently.

Key design patterns:
- **Centralized constants**: All SQL queries, parameter names, messages, and configuration values live in `AppConstants.cs`
- **Data access layer**: `CategoryData.cs` provides a dedicated CRUD layer for categories with an `ExecuteCommand` helper
- **Automatic schema migration**: `DatabaseSetup.cs` handles database creation and adds missing columns (`user_id`, `cate_date`) to existing tables

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available under the MIT License.

## Support

For issues or questions, please create an issue on the GitHub repository.

---

**Version**: 1.6.0  
**Last Updated**: July 2025  
**Author**: Development Team
