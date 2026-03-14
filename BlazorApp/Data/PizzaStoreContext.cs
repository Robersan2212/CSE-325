using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;

namespace BlazorApp.Data;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPizza> OrderPizzas { get; set; }
    public DbSet<PizzaSpecial> Specials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(b =>
        {
            b.HasKey(o => o.OrderId);
            b.HasMany(o => o.Pizzas).WithOne().HasForeignKey(p => p.OrderId);
        });

        modelBuilder.Entity<OrderPizza>(b =>
        {
            b.HasKey(p => p.OrderPizzaId);
            b.HasOne(p => p.Special).WithMany().HasForeignKey(p => p.SpecialId);
            b.Ignore(p => p.MinimumSize);
            b.Ignore(p => p.MaximumSize);
            b.Ignore(p => p.Toppings);
        });
    }
}
