# Development Guidelines & Best Practices

## 🎯 Code Style Guidelines

### Naming Conventions
```csharp
// Classes - PascalCase
public class CategoryData { }
public partial class IncomeForm : UserControl { }

// Methods - PascalCase
public void LoadIncomeData() { }
public bool AddCategory(string name) { }

// Properties - PascalCase
public int TransactionId { get; set; }
public string Description { get; set; }

// Private Fields - camelCase with underscore prefix
private int _currentUserId;
private readonly string _connectionString;

// Constants - UPPER_SNAKE_CASE (or PascalCase per C# convention)
private const string SELECT_QUERY = "SELECT * FROM...";

// Local Variables - camelCase
int categoryId = 5;
string categoryName = "Salary";
```

### Formatting Standards
```csharp
// Currency Formatting
amountColumn.DefaultCellStyle.Format = "C2";
amountColumn.DefaultCellStyle.FormatProvider = UsCulture;
// Result: $1,234.56

// Date Formatting  
dateColumn.DefaultCellStyle.Format = "MM-dd-yyyy";
// Result: 01-15-2025

// Culture
private static readonly CultureInfo UsCulture = CultureInfo.GetCultureInfo("en-US");
```

---

## 🔒 Security Best Practices

### ✅ DO - Use Parameterized Queries
```csharp
// CORRECT - Prevents SQL injection
using var cmd = new SqlCommand("SELECT * FROM users WHERE id = @id", connect);
cmd.Parameters.AddWithValue("@id", userId);
```

### ❌ DON'T - String Concatenation
```csharp
// WRONG - Vulnerable to SQL injection
string query = "SELECT * FROM users WHERE id = " + userId;
using var cmd = new SqlCommand(query, connect);
```

### ✅ DO - Validate Input
```csharp
if (userId <= 0 || categoryId <= 0 || amount <= 0)
    throw new ArgumentException("Invalid parameters");
```

### ✅ DO - Hash Passwords
```csharp
using PasswordHasher to store passwords securely
```

---

## 📝 XML Documentation Template

### For Methods
```csharp
/// <summary>
/// Brief description of what the method does.
/// </summary>
/// <param name="paramName">Description of parameter.</param>
/// <returns>Description of return value.</returns>
/// <exception cref="ArgumentException">Thrown when parameters are invalid.</exception>
public bool AddTransaction(int userId, decimal amount)
{
    // Implementation
}
```

### For Classes
```csharp
/// <summary>
/// Brief description of the class purpose and responsibility.
/// Optionally includes usage example.
/// </summary>
internal class TransactionData
{
    // Implementation
}
```

### For Properties
```csharp
/// <summary>
/// Gets or sets the transaction amount.
/// </summary>
public decimal Amount { get; set; }
```

---

## 🛡️ Error Handling Pattern

### Recommended Pattern
```csharp
try
{
    using var connect = new SqlConnection(_connectionString);
    connect.Open();
    
    using var cmd = new SqlCommand(query, connect);
    cmd.Parameters.AddWithValue("@id", id);
    
    return cmd.ExecuteNonQuery() > 0;
}
catch (Exception ex)
{
    throw new Exception($"Error performing operation: {ex.Message}", ex);
}
```

### UI Error Display
```csharp
catch (Exception ex)
{
    MessageBox.Show(
        $"Error: {ex.Message}",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
    );
}
```

---

## 📊 Data Access Pattern

### Standard CRUD Operations
```csharp
// CREATE
public bool AddItem(string name, string type, string status)
{
    try
    {
        using var connect = new SqlConnection(_connectionString);
        connect.Open();
        
        string query = "INSERT INTO table (col1, col2) VALUES (@val1, @val2)";
        using var cmd = new SqlCommand(query, connect);
        cmd.Parameters.AddWithValue("@val1", name);
        cmd.Parameters.AddWithValue("@val2", type);
        
        return cmd.ExecuteNonQuery() > 0;
    }
    catch (Exception ex)
    {
        throw new Exception($"Error adding item: {ex.Message}", ex);
    }
}

// READ
public List<ItemData> GetAllItems()
{
    var items = new List<ItemData>();
    
    try
    {
        using var connect = new SqlConnection(_connectionString);
        connect.Open();
        
        using var cmd = new SqlCommand("SELECT * FROM table", connect);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            items.Add(MapReaderToItem(reader));
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error retrieving items: {ex.Message}", ex);
    }
    
    return items;
}

// UPDATE
public bool UpdateItem(int id, string name)
{
    try
    {
        using var connect = new SqlConnection(_connectionString);
        connect.Open();
        
        string query = "UPDATE table SET col1 = @val1 WHERE id = @id";
        using var cmd = new SqlCommand(query, connect);
        cmd.Parameters.AddWithValue("@val1", name);
        cmd.Parameters.AddWithValue("@id", id);
        
        return cmd.ExecuteNonQuery() > 0;
    }
    catch (Exception ex)
    {
        throw new Exception($"Error updating item: {ex.Message}", ex);
    }
}

// DELETE
public bool DeleteItem(int id)
{
    try
    {
        using var connect = new SqlConnection(_connectionString);
        connect.Open();
        
        string query = "DELETE FROM table WHERE id = @id";
        using var cmd = new SqlCommand(query, connect);
        cmd.Parameters.AddWithValue("@id", id);
        
        return cmd.ExecuteNonQuery() > 0;
    }
    catch (Exception ex)
    {
        throw new Exception($"Error deleting item: {ex.Message}", ex);
    }
}
```

---

## 🎨 UI/Form Pattern

### UserControl Template
```csharp
public partial class MyForm : UserControl
{
    private readonly string _connectionString = DatabaseSetup.ConnectionString;
    private static readonly CultureInfo UsCulture = CultureInfo.GetCultureInfo("en-US");
    private int _currentUserId;
    
    public MyForm()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Sets the current user ID for loading user-specific data.
    /// </summary>
    public void SetUserId(int userId)
    {
        _currentUserId = userId;
    }
    
    /// <summary>
    /// Loads data from database and displays in UI.
    /// </summary>
    public void LoadData()
    {
        try
        {
            // Implementation
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void MyForm_Load(object sender, EventArgs e)
    {
        // Initialization if needed
    }
}
```

### Navigation Pattern (MainForm)
```csharp
private void InvoiceBtn_Click(object sender, EventArgs e)
{
    invoiceForm?.BringToFront();
    invoiceForm?.LoadData();
}

private void CategoryBtn_Click(object sender, EventArgs e)
{
    categoryForm?.BringToFront();
    categoryForm?.LoadCategories();
}
```

---

## 🧪 Testing Recommendations

### Unit Test Template
```csharp
[TestClass]
public class CategoryDataTests
{
    private CategoryData _categoryData;
    
    [TestInitialize]
    public void Setup()
    {
        _categoryData = new CategoryData();
    }
    
    [TestMethod]
    public void AddCategory_WithValidData_ReturnsTrue()
    {
        // Arrange
        string name = "Test Category";
        string type = "Income";
        string status = "Active";
        
        // Act
        bool result = _categoryData.AddCategory(name, type, status);
        
        // Assert
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddCategory_WithEmptyName_ThrowsException()
    {
        // Act
        _categoryData.AddCategory("", "Income", "Active");
    }
}
```

---

## 🔄 Code Review Checklist

### Before Committing
- [ ] Code compiles without errors
- [ ] No compiler warnings
- [ ] All SQL queries use parameterized parameters
- [ ] Input validation is present
- [ ] Error handling is implemented
- [ ] XML documentation is complete
- [ ] No hardcoded values (use constants/AppConstants)
- [ ] No SQL injection vulnerabilities
- [ ] Consistent naming conventions followed
- [ ] Proper use of null-coalescing (`??`) and null-conditional (`?.`)

### Before Merging
- [ ] Code follows project style guide
- [ ] No code duplication
- [ ] All tests pass
- [ ] Performance is acceptable
- [ ] Security best practices followed
- [ ] Database changes are versioned
- [ ] Documentation is updated

---

## 📚 Common Patterns

### Safe Null Handling
```csharp
// Property assignment with null coalescing
string categoryName = reader["cate_name"]?.ToString() ?? string.Empty;

// Null-conditional with null coalescing
decimal amount = Convert.ToDecimal(row.Cells["amount"].Value ?? 0m);

// Pattern matching
if (selectedItem is CategoryItem category)
{
    // Use category safely
}
```

### DataGridView Formatting
```csharp
// Format specific column
DataGridViewColumn? column = dataGridView.Columns["columnName"];
if (column != null)
{
    column.DefaultCellStyle.Format = "C2";  // Currency
    // OR
    column.DefaultCellStyle.Format = "MM-dd-yyyy";  // Date
}
```

### Transaction Pattern
```csharp
using var connect = new SqlConnection(_connectionString);
connect.Open();

using var cmd = new SqlCommand(query, connect);
// Add parameters
// Execute command
// Process results
```

---

## 🚀 Performance Tips

1. **Use Connection Pooling** - Automatically handled by SqlConnection
2. **Avoid N+1 Queries** - Load related data in single query when possible
3. **Index Frequently Queried Columns** - trans_date, user_id, cate_id
4. **Limit Data Loading** - Use pagination for large datasets
5. **Cache Static Data** - Categories rarely change
6. **Use Stored Procedures** - For complex queries

---

## 📋 Commit Message Format

```
<type>: <subject>

<body>

<footer>
```

### Examples
```
feat: Add IncomeData class with CRUD operations

- Implemented GetIncomeByUserId() for retrieving user transactions
- Added AddIncome(), UpdateIncome(), DeleteIncome() methods
- Included GetTotalIncome() for dashboard calculations
- All methods use parameterized queries for security

Resolves: #123
```

```
fix: Fix null reference in DataGridView formatting

- Added null checks before accessing column styles
- Verify column exists before applying formatting
- Prevents crashes when columns are missing

Fixes: #456
```

---

## 🔗 Useful Links

- [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [SQL Injection Prevention](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/protecting-connection-information)
- [Windows Forms Best Practices](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/overview)
- [XML Documentation Comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags)

---

**Last Updated:** January 2025
**Status:** Active ✅
