using tienda_1.Models;

namespace tienda_1.Data;

public static class DbInitializer
{
    public static void Seed(TiendaContext context)
    {
        if (context.Categories.Any())
            return;

        var categories = new List<Category>
        {
            new() { Name = "Herramientas Manuales", Description = "Martillos, destornilladores, llaves, etc." },
            new() { Name = "Herramientas Eléctricas", Description = "Taladros, sierras, lijadoras, etc." },
            new() { Name = "Fontanería", Description = "Tuberías, llaves de paso, conectores, etc." },
            new() { Name = "Electricidad", Description = "Cables, interruptores, enchufes, etc." },
            new() { Name = "Pinturas", Description = "Pinturas, brochas, rodillos, etc." }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var products = new List<Product>
        {
            new() { Name = "Martillo de Uña", Description = "Martillo de acero forjado con mango de madera", Price = 15.99m, Stock = 50, CategoryId = categories[0].Id },
            new() { Name = "Destornillador Plano", Description = "Destornillador plano 6mm x 100mm", Price = 5.99m, Stock = 100, CategoryId = categories[0].Id },
            new() { Name = "Taladro Eléctrico", Description = "Taladro percutor 600W con mandril", Price = 89.99m, Stock = 20, CategoryId = categories[1].Id },
            new() { Name = "Sierra Circular", Description = "Sierra circular 1200W disco 185mm", Price = 129.99m, Stock = 15, CategoryId = categories[1].Id },
            new() { Name = "Tubería PVC 1/2", Description = "Tubería de PVC para agua fría 1/2 pulgada x 3m", Price = 8.50m, Stock = 200, CategoryId = categories[2].Id },
            new() { Name = "Llave de Paso", Description = "Llave de paso de bola 1/2 pulgada", Price = 12.99m, Stock = 80, CategoryId = categories[2].Id },
            new() { Name = "Cable Eléctrico THW", Description = "Cable THW calibre 12 gauge x 100m", Price = 45.00m, Stock = 60, CategoryId = categories[3].Id },
            new() { Name = "Interruptor Sencillo", Description = "Interruptor de luz empotrable color blanco", Price = 3.99m, Stock = 150, CategoryId = categories[3].Id },
            new() { Name = "Pintura Acrílica Blanca", Description = "Pintura acrílica blanca mate 4 litros", Price = 28.99m, Stock = 40, CategoryId = categories[4].Id },
            new() { Name = "Brocha Plana 2", Description = "Brocha plana de cerdas sintéticas 2 pulgadas", Price = 6.49m, Stock = 90, CategoryId = categories[4].Id }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
