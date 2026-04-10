# Contributing to Income Expenses Tracking Management System

Thank you for your interest in contributing to this project! This document provides guidelines and instructions for contributing.

## Code of Conduct

Be respectful, inclusive, and professional in all interactions with the community.

## Getting Started

1. **Fork the repository** on GitHub
2. **Clone your fork** locally:
   ```bash
   git clone https://github.com/YOUR_USERNAME/IncomeExpensesTrackingManagementSystem.git
   cd IncomeExpensesTrackingManagementSystem
   ```

3. **Create a new branch** for your feature or bugfix:
   ```bash
   git checkout -b feature/your-feature-name
   # or for bugfixes:
   git checkout -b bugfix/your-bugfix-name
   ```

4. **Set up your development environment**:
   - Install .NET 10.0 SDK
   - Ensure SQL Server LocalDB is installed
   - Open the project in Visual Studio 2022 or later

## Development Guidelines

### Code Style

- Follow C# coding standards and conventions
- Use meaningful variable and method names
- Keep methods focused and concise
- Use XML documentation comments for public methods

### Example Method Documentation:
```csharp
/// <summary>
/// Brief description of what the method does.
/// </summary>
/// <param name="paramName">Description of the parameter.</param>
/// <returns>Description of the return value.</returns>
public string ExampleMethod(string paramName)
{
    // Implementation
}
```

### Naming Conventions

- **Classes**: PascalCase (e.g., `MainForm`, `PasswordHasher`)
- **Methods**: PascalCase (e.g., `LoadDashboard`, `VerifyPassword`)
- **Variables**: camelCase (e.g., `userId`, `connectionString`)
- **Constants**: UPPER_CASE (e.g., in `AppConstants` class)
- **Private fields**: _camelCase (e.g., `_currentUserId`)

### Best Practices

1. **Use the Constants Class**: Store repeated strings and queries in `AppConstants.cs`
   ```csharp
   // Good
   MessageBox.Show(AppConstants.FillAllFieldsError, AppConstants.ErrorTitle);
   
   // Avoid
   MessageBox.Show("Please fill all blank fields", "Error Message");
   ```

2. **Use Null-Conditional Operators**: Simplify null checks
   ```csharp
   // Good
   dashboardForm1?.SetUserId(_currentUserId);
   
   // Avoid
   if (dashboardForm1 != null)
       dashboardForm1.SetUserId(_currentUserId);
   ```

3. **Use Parameterized Queries**: Always prevent SQL injection
   ```csharp
   // Good
   cmd.Parameters.AddWithValue("@username", userInput);
   
   // Avoid - SQL Injection risk
   $"SELECT * FROM users WHERE username = '{userInput}'"
   ```

4. **Error Handling**: Always use try-catch with appropriate error messages
   ```csharp
   try
   {
       // Database operation
   }
   catch (Exception ex)
   {
       MessageBox.Show($"Error: {ex.Message}", AppConstants.ErrorTitle, 
           MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
   ```

5. **Resource Management**: Use `using` statements for database connections
   ```csharp
   using (SqlConnection connection = new(connectionString))
   {
       // Use connection
   } // Connection is automatically disposed
   ```

### Testing

- Test your changes thoroughly before submitting
- Verify that existing functionality still works
- Test edge cases and error scenarios
- Ensure the application builds without warnings

## Making Changes

1. **Make your changes** in your feature branch
2. **Run a clean build**:
   ```bash
   dotnet clean
   dotnet build
   ```

3. **Test thoroughly** in the application
4. **Commit your changes** with descriptive messages:
   ```bash
   git commit -m "Add feature: description of changes"
   # or
   git commit -m "Fix bug: description of the fix"
   ```

## Submitting Changes

1. **Push your changes** to your fork:
   ```bash
   git push origin feature/your-feature-name
   ```

2. **Create a Pull Request** on GitHub:
   - Provide a clear title and description
   - Reference any related issues
   - Include screenshots for UI changes
   - List any breaking changes

3. **Respond to feedback** and make requested changes

## Pull Request Template

```markdown
## Description
Brief description of the changes made.

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Related Issues
Fixes #(issue number)

## Testing
Describe how you tested the changes.

## Screenshots (if applicable)
Include any relevant screenshots.

## Checklist
- [ ] Code follows the style guidelines
- [ ] Documentation has been updated
- [ ] No new warnings are introduced
- [ ] Changes have been tested
```

## Reporting Bugs

When reporting bugs, please include:

- **Description**: Clear description of the bug
- **Steps to Reproduce**: Step-by-step instructions
- **Expected Behavior**: What should happen
- **Actual Behavior**: What actually happens
- **Environment**: 
  - .NET version
  - OS version
  - Visual Studio version
- **Screenshots**: If applicable

## Feature Requests

When requesting features, please include:

- **Use Case**: Why is this feature needed?
- **Description**: What should the feature do?
- **Proposed Behavior**: How should it work?
- **Alternatives**: Any alternative approaches considered

## Project Structure

```
IncomeExpensesTrackingManagementSystem/
├── Program.cs                  # Entry point
├── AppConstants.cs             # Shared constants
├── DatabaseSetup.cs            # Database initialization
├── PasswordHasher.cs           # Security utilities
├── Form1.cs                    # Login form
├── RegisterForm.cs             # Registration
├── MainForm.cs                 # Main window
├── DashboardForm.cs            # Dashboard
├── IncomeForm.cs               # Income management
├── ExpenseForm.cs              # Expense management
├── CategoryForm.cs             # Category management
└── CategoryItem.cs             # Data model
```

## Key Files for Common Changes

| Task | File |
|------|------|
| Add database queries | `AppConstants.cs` |
| Modify UI forms | `[FormName].cs` and `[FormName].Designer.cs` |
| Change security | `PasswordHasher.cs` |
| Database schema | `DatabaseSetup.cs` |
| Error messages | `AppConstants.cs` |

## Build Commands

```bash
# Clean build
dotnet clean && dotnet build

# Run the application
dotnet run

# Build for release
dotnet build --configuration Release
```

## Questions?

- Check existing issues and discussions
- Review the README.md for usage information
- Create a new issue with the "question" label

## License

By contributing to this project, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to make this project better! 🎉
