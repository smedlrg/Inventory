using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

/// <summary>
/// Context EF implementation
/// </summary>
public class InventoryContext : DbContext, IInventoryContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //Connection string should ideally by in appsettings file
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
    /// <summary>
    /// Binding properties on model create
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.Description)
            .HasColumnName("Description")
            .HasMaxLength(50)
            .IsUnicode(false);

            entity.Property(e => e.Count)
            .HasColumnName("Count");

            entity.Property(e => e.Price)
            .HasColumnName("Price");

        });
    }
    /// <summary>
    /// Items
    /// </summary>
    public virtual DbSet<Item> Item { get; set; }
}
