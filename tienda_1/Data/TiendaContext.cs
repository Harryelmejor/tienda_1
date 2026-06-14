using Microsoft.EntityFrameworkCore;
using tienda_1.Models;

namespace tienda_1.Data;

public class TiendaContext : DbContext
{
    public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categorias");
            entity.Property(e => e.Name).HasColumnName("Nombre");
            entity.Property(e => e.Description).HasColumnName("Descripcion");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Productos");
            entity.Property(e => e.Name).HasColumnName("Nombre");
            entity.Property(e => e.Description).HasColumnName("Descripcion");
            entity.Property(e => e.Price).HasColumnName("Precio").HasPrecision(18, 2);
            entity.Property(e => e.CategoryId).HasColumnName("CategoriaId");
            entity.Property(e => e.ImageUrl).HasColumnName("ImagenUrl");

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Proveedores");
            entity.Property(e => e.Name).HasColumnName("Nombre");
            entity.Property(e => e.Phone).HasColumnName("Telefono");
            entity.Property(e => e.Email).HasColumnName("Correo");
            entity.Property(e => e.Address).HasColumnName("Direccion");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Clientes");
            entity.Property(e => e.Name).HasColumnName("Nombre");
            entity.Property(e => e.Identification).HasColumnName("Cedula");
            entity.Property(e => e.Phone).HasColumnName("Telefono");
            entity.Property(e => e.Address).HasColumnName("Direccion");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Ventas");
            entity.Property(e => e.Date).HasColumnName("Fecha").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.ClientId).HasColumnName("ClienteId");
            entity.Property(e => e.Total).HasPrecision(18, 2);

            entity.HasOne(e => e.Client)
                .WithMany(c => c.Sales)
                .HasForeignKey(e => e.ClientId);
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.ToTable("DetalleVentas");
            entity.Property(e => e.SaleId).HasColumnName("VentaId");
            entity.Property(e => e.ProductId).HasColumnName("ProductoId");
            entity.Property(e => e.Quantity).HasColumnName("Cantidad");
            entity.Property(e => e.UnitPrice).HasColumnName("PrecioUnitario").HasPrecision(18, 2);
            entity.Property(e => e.Subtotal).HasPrecision(18, 2);

            entity.HasOne(e => e.Sale)
                .WithMany(s => s.Details)
                .HasForeignKey(e => e.SaleId);

            entity.HasOne(e => e.Product)
                .WithMany(p => p.SaleDetails)
                .HasForeignKey(e => e.ProductId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.Property(e => e.FullName).HasColumnName("Nombre");
            entity.Property(e => e.Username).HasColumnName("Usuario");
            entity.Property(e => e.Password).HasColumnName("Clave");
            entity.Property(e => e.Role).HasColumnName("Rol");

            entity.HasIndex(e => e.Username).IsUnique();
        });
    }
}
