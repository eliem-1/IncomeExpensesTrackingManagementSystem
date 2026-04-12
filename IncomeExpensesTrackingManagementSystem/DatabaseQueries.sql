-- =============================================
-- Income Expenses Tracking Management System
-- Reference SQL Queries for manual inspection
-- =============================================

-- Create users table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'users')
BEGIN
    CREATE TABLE users (
        id INT PRIMARY KEY IDENTITY(1,1),
        username VARCHAR(MAX) NULL,
        password VARCHAR(MAX) NULL,
        date_create DATE NULL
    );
END;

-- Create category table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'category')
BEGIN
    CREATE TABLE category (
        cate_id INT PRIMARY KEY IDENTITY(1,1),
        user_id INT NULL,
        cate_name VARCHAR(MAX) NULL,
        cate_type VARCHAR(MAX) NULL,
        cate_status VARCHAR(MAX) NULL,
        cate_date DATE NULL DEFAULT CAST(GETDATE() AS DATE),
        FOREIGN KEY (user_id) REFERENCES users(id)
    );
END;

-- Create transactions table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'transactions')
BEGIN
    CREATE TABLE transactions (
        trans_id INT PRIMARY KEY IDENTITY(1,1),
        user_id INT NOT NULL,
        cate_id INT NOT NULL,
        trans_type VARCHAR(MAX) NULL,
        trans_amount DECIMAL(18, 2) NULL,
        trans_description VARCHAR(MAX) NULL,
        trans_date DATE NULL,
        FOREIGN KEY (user_id) REFERENCES users(id),
        FOREIGN KEY (cate_id) REFERENCES category(cate_id)
    );
END;

-- View all data
SELECT * FROM users;
SELECT * FROM category;
SELECT * FROM transactions;