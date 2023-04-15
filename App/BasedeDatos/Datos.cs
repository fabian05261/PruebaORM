using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace App
{
  public class DatabaseContext : DbContext
  {
    public DbSet<Product> Products { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=database.db");
    }
  }

  public class Order
  {
    public int OrderId { get; set; }

    public DateTime? Created { get; set; }
  
    public ICollection<OrderItem> Items { get; set; }
  }

  public class OrderItem
  {
    public int OrderItemId { get; set; }
    public int Quantity { get; set; }
    public virtual Product Product { get; set; }
  }

  public class Product 
  {
    public int ProductId { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
  }
}