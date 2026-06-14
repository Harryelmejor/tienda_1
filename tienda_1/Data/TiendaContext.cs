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
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Price).HasPrecision(18, 2);

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Total).HasPrecision(18, 2);

            entity.HasOne(e => e.Client)
                .WithMany(c => c.Sales)
                .HasForeignKey(e => e.ClientId);
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
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
            entity.HasIndex(e => e.Username).IsUnique();
        });
    }
}
