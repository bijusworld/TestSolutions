using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderApp.Domain;
using System;

namespace OrderApp.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }
        //private readonly IConfiguration _config;

        //public OrderContext(IConfiguration config)
        //{
        //    _config = config;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        //{
        //    base.OnConfiguring(bldr);

        //    bldr.UseSqlServer(_config.GetConnectionString("OrderAppConn"));
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("money");

            modelBuilder.Entity<OrderItem>()
              .Property(o => o.UnitPrice)
              .HasColumnType("money");

            modelBuilder.Entity<Order>()
              .HasData(new Order()
              {
                  Id = 1,
                  OrderDate = DateTime.UtcNow,
                  OrderNumber = "12345"
              });
        }
    }

}
