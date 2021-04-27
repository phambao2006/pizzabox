using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain
{
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityID);


      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityID);


      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Size>().HasKey(e => e.EntityID);

      builder.Entity<Crust>().HasKey(e => e.EntityID);

      builder.Entity<Customer>().HasKey(e => e.EntityID);

      builder.Entity<Topping>().HasKey(e => e.EntityID);

      builder.Entity<Order>().HasKey(e => e.EntityID);

      builder.Entity<APizza>().HasMany(p => p.Toppings).WithMany(t => t.Pizzas);
      builder.Entity<APizza>().HasOne(p => p.Size).WithMany(s => s.Pizzas).HasForeignKey(p => p.SizeEntityId);
      builder.Entity<APizza>().HasOne(p => p.Crust).WithMany(c => c.Pizzas).HasForeignKey(p => p.CrustEntityId);


      OnDataSeeding(builder);
    }
    private void OnDataSeeding(ModelBuilder builder)
    {
      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping{EntityID = 1,Name = "Chicken", Price = 2},
        new Topping{EntityID = 2,Name = "Pork", Price = 2},
        new Topping{EntityID = 3,Name = "Beef", Price = 2},
        new Topping{EntityID = 4,Name = "Mushroom", Price = 2},
        new Topping{EntityID = 5,Name = "Pineapple", Price = 2},
        new Topping{EntityID = 6,Name = "Bell Pepper", Price = 2}
      });
      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust{EntityID = 1,Name = "Original", Price = 2},
        new Crust{EntityID = 2,Name = "Thin Crust", Price = 2},
        new Crust{EntityID = 3,Name = "Stuffed Crust", Price = 3}
      });
      builder.Entity<Size>().HasData(new Size[]
      {
        new Size{EntityID = 1,Name = "Small", Price = 2},
        new Size{EntityID = 2,Name = "Medium", Price = 3},
        new Size{EntityID = 3,Name = "Large", Price = 4}
      });

      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore{EntityID = 1,Name = "Downtown"}
      });
      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore{EntityID = 2,Name = "Times Square"}
      });

    }
  }
}