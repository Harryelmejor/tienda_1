CREATE DATABASE TiendaDB;
GO

USE TiendaDB;
GO

-- Tabla Categorias
CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

-- Tabla Productos
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(500),
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    CategoriaId INT NOT NULL,
    ImagenUrl NVARCHAR(500),

    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (CategoriaId)
        REFERENCES Categorias(Id)
);

-- Datos de ejemplo
INSERT INTO Categorias (Nombre, Descripcion)
VALUES
('Electrónica', 'Productos electrónicos'),
('Ropa', 'Prendas de vestir'),
('Hogar', 'Artículos para el hogar');

INSERT INTO Productos
(Nombre, Descripcion, Precio, Stock, CategoriaId, ImagenUrl)
VALUES
('Laptop HP', 'Laptop Core i5', 45000.00, 10, 1, NULL),
('Camisa Polo', 'Camisa de algodón', 1200.00, 25, 2, NULL),
('Licuadora', 'Licuadora 2 litros', 3500.00, 8, 3, NULL);

CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(255)
);

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Cedula NVARCHAR(20),
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(255)
);

CREATE TABLE Ventas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    ClienteId INT NULL,
    Total DECIMAL(18,2) NOT NULL,

    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE DetalleVentas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VentaId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,

    FOREIGN KEY (VentaId) REFERENCES Ventas(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Usuario NVARCHAR(50) UNIQUE NOT NULL,
    Clave NVARCHAR(255) NOT NULL,
    Rol NVARCHAR(30) NOT NULL
);

INSERT INTO Categorias (Nombre, Descripcion)
VALUES
('Herramientas','Herramientas manuales y eléctricas'),
('Pinturas','Pinturas y accesorios'),
('Electricidad','Materiales eléctricos'),
('Plomería','Tuberías y accesorios'),
('Construcción','Materiales de construcción');

INSERT INTO Proveedores
(Nombre,Telefono,Correo,Direccion)
VALUES
('FerreSuplidor SRL','809-555-1000','ventas@ferresuplidor.com','Santo Domingo');
