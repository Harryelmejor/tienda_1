using System.Collections.Generic;
using tienda_1.Models;

namespace tienda_1.Data;

public static class InMemoryData
{
    public static List<Category> Categories { get; } = new()
    {
        new Category { Id = 1, Name = "Herramientas Manuales", Description = "Martillos, destornilladores, llaves, etc." },
        new Category { Id = 2, Name = "Herramientas Eléctricas", Description = "Taladros, sierras, lijadoras, etc." },
        new Category { Id = 3, Name = "Fontanería", Description = "Tuberías, llaves de paso, conectores, etc." },
        new Category { Id = 4, Name = "Electricidad", Description = "Cables, interruptores, enchufes, etc." },
        new Category { Id = 5, Name = "Pinturas", Description = "Pinturas, brochas, rodillos, etc." }
    };

    public static List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Martillo de Uña", Description = "Martillo de acero forjado con mango de madera", Price = 15.99m, Stock = 50, CategoryId = 1 },
        new Product { Id = 2, Name = "Destornillador Plano", Description = "Destornillador plano 6mm x 100mm", Price = 5.99m, Stock = 100, CategoryId = 1 },
        new Product { Id = 3, Name = "Taladro Eléctrico", Description = "Taladro percutor 600W con mandril", Price = 89.99m, Stock = 20, CategoryId = 2 },
        new Product { Id = 4, Name = "Sierra Circular", Description = "Sierra circular 1200W disco 185mm", Price = 129.99m, Stock = 15, CategoryId = 2 },
        new Product { Id = 5, Name = "Tubería PVC 1/2", Description = "Tubería de PVC para agua fría 1/2 pulgada x 3m", Price = 8.50m, Stock = 200, CategoryId = 3 },
        new Product { Id = 6, Name = "Llave de Paso", Description = "Llave de paso de bola 1/2 pulgada", Price = 12.99m, Stock = 80, CategoryId = 3 },
        new Product { Id = 7, Name = "Cable Eléctrico THW", Description = "Cable THW calibre 12 gauge x 100m", Price = 45.00m, Stock = 60, CategoryId = 4 },
        new Product { Id = 8, Name = "Interruptor Sencillo", Description = "Interruptor de luz empotrable color blanco", Price = 3.99m, Stock = 150, CategoryId = 4 },
        new Product { Id = 9, Name = "Pintura Acrílica Blanca", Description = "Pintura acrílica blanca mate 4 litros", Price = 28.99m, Stock = 40, CategoryId = 5 },
        new Product { Id = 10, Name = "Brocha Plana 2", Description = "Brocha plana de cerdas sintéticas 2 pulgadas", Price = 6.49m, Stock = 90, CategoryId = 5 }
    };

    private static int _nextProductId = 11;
    private static int _nextCategoryId = 6;

    public static int NextProductId => _nextProductId++;
    public static int NextCategoryId => _nextCategoryId++;
}
