using InfrastructureLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataUIContext
{
    public class DataContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5EHPFDI;Database=UIProduct;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Category>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Product>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Payment>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<User>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Order>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Comment>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<OrderDetail>()
                .HasKey(c => new { c.Id });


            modelBuilder.Entity<Product>()
                .HasOne(c => c.Categories)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CatrgoryId);
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Suppliers)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Users)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Payments)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.PaymentId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(c => c.Products)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(c => c.Orders)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Users)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Products)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ProductId);


                
        }

    }
}
