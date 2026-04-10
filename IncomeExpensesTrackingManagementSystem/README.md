# Income Expenses Tracking Management System

A Windows Forms application built with C# and .NET 10 for tracking personal income and expenses.

## Features

- **User Authentication**: Secure login and registration with PBKDF2 password hashing
- **Income Tracking**: Record and manage income transactions
- **Expense Tracking**: Record and manage expense transactions
- **Category Management**: Create and manage transaction categories
- **Dashboard**: View financial summary including total income, expenses, and balance
- **Secure Database**: Uses SQL Server LocalDB for data persistence

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

## Project Structure

```
IncomeExpensesTrackingManagementSystem/
├── Program.cs                    # Application entry point
├── Form1.cs                      # Login form
├── RegisterForm.cs               # User registration
├── MainForm.cs                   # Main application window
├── DashboardForm.cs              # Financial dashboard
├── IncomeForm.cs                 # Income management
├── ExpenseForm.cs                # Expense management
├── CategoryForm.cs               # Category management
├── DatabaseSetup.cs              # Database initialization
├── PasswordHasher.cs             # Password hashing utility
└── CategoryItem.cs               # Data model for categories
```

## Technology Stack

- **Framework**: .NET 10.0 (Windows Forms)
- **Language**: C# 14.0
- **Database**: SQL Server LocalDB
- **Security**: PBKDF2 with SHA-256 password hashing

## Database Schema

### Users Table
```sql
- id (INT PRIMARY KEY IDENTITY)
- username (VARCHAR MAX)
- password (VARCHAR MAX) - PBKDF2 hashed
- date_create (DATE)
```

### Category Table
```sql
- cate_id (INT PRIMARY KEY IDENTITY)
- cate_name (VARCHAR MAX)
- cate_type (VARCHAR MAX) - Income or Expenses
- cate_status (VARCHAR MAX) - Active or Inactive
```

### Transactions Table
```sql
- trans_id (INT PRIMARY KEY IDENTITY)
- user_id (INT FOREIGN KEY)
- cate_id (INT FOREIGN KEY)
- trans_type (VARCHAR MAX) - Income or Expense
- trans_amount (DECIMAL)
- trans_description (VARCHAR MAX)
- trans_date (DATE)
```

## Security Features

- **Password Hashing**: PBKDF2 with SHA-256, 100,000 iterations
- **Automatic Password Upgrade**: Legacy plain-text passwords are automatically hashed on login
- **SQL Parameterization**: All database queries use parameterized commands to prevent SQL injection
- **Connection Security**: Integrated Windows authentication for database access

## Usage

### Creating an Account
1. Click "Sign Up" on the login screen
2. Enter a username and password (minimum 8 characters)
3. Confirm your password and click "Register"

### Adding Transactions
1. Select the appropriate form (Income or Expense)
2. Choose a category
3. Enter the amount and date
4. Add an optional description
5. Click "Add" to save

### Managing Categories
1. Go to "Add Category" section
2. Enter category name, type (Income/Expenses), and status
3. Use Update/Delete buttons to modify existing categories

### Viewing Dashboard
1. Click "Dashboard" to view your financial summary
2. See total income, expenses, and net balance
3. Click refresh to update with latest data

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available under the MIT License.

## Support

For issues or questions, please create an issue on the GitHub repository.

---

**Version**: 1.0.0  
**Last Updated**: 2024  
**Author**: Development Team
