-- Create users table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' AND xtype='U')
BEGIN
    CREATE TABLE users(
        id INT PRIMARY KEY IDENTITY(1,1),
        username VARCHAR(MAX) NULL,
        password VARCHAR(MAX) NULL,
        date_create DATE NULL
    );
END;

SELECT * FROM users;

-- Create categories table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='categories' AND xtype='U')
BEGIN
    CREATE TABLE categories(
        id INT PRIMARY KEY IDENTITY(1,1),
        category VARCHAR(MAX) NULL,
        type VARCHAR(MAX) NULL,
        status VARCHAR(MAX) NULL,
        date_insert DATE NULL
    );
END;

SELECT * FROM categories;

DELETE FROM categories WHERE id = 2;