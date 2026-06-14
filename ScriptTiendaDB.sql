CREATE DATABASE HardwareStoreDB;
GO

USE HardwareStoreDB;
GO

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    CategoryId INT NOT NULL,
    ImageUrl NVARCHAR(500),

    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId)
        REFERENCES Categories(Id)
);

INSERT INTO Categories (Name, Description)
VALUES
('Electronics', 'Electronic products'),
('Clothing', 'Clothing items'),
('Home', 'Home goods');

INSERT INTO Products (Name, Description, Price, Stock, CategoryId, ImageUrl)
VALUES
('HP Laptop', 'Core i5 Laptop', 45000.00, 10, 1, NULL),
('Polo Shirt', 'Cotton polo shirt', 1200.00, 25, 2, NULL),
('Blender', '2-liter blender', 3500.00, 8, 3, NULL);

CREATE TABLE Suppliers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(255)
);

CREATE TABLE Clients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Identification NVARCHAR(20),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);

CREATE TABLE Sales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Date DATETIME DEFAULT GETDATE(),
    ClientId INT NULL,
    Total DECIMAL(18,2) NOT NULL,

    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

CREATE TABLE SaleDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,

    FOREIGN KEY (SaleId) REFERENCES Sales(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(30) NOT NULL
);

INSERT INTO Categories (Name, Description)
VALUES
('Tools','Hand and power tools'),
('Paints','Paints and accessories'),
('Electrical','Electrical supplies'),
('Plumbing','Pipes and fittings'),
('Construction','Building materials');

INSERT INTO Suppliers (Name, Phone, Email, Address)
VALUES
('HardwareSupplier SRL','809-555-1000','sales@hardwaresupplier.com','Santo Domingo');
