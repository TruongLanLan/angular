using eShopAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopAPI.Data.Context
{
    public class eShopDBContext : DbContext
    {
        public eShopDBContext(DbContextOptions<eShopDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleCode> SaleCodes { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Supplier>(supplier =>
            {
                supplier.HasKey(x => x.Id);
            });

            modelBuilder.Entity<User>(customer =>
            {
                customer.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Comment>(comment =>
            {
                comment.HasKey(x => x.Id);
                comment.HasOne(k => k.User).WithMany(k => k.Comments).HasForeignKey(k => k.UserId);
                comment.HasOne(x => x.Product).WithMany(x => x.Comments).HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey(x => x.Id);
                product.HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.SupplierId);
                product.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

            });
            modelBuilder.Entity<OrderDetail>(orderDetail =>
            {
                orderDetail.HasKey(x => x.Id);
                orderDetail.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId);
                orderDetail.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            });


            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(x => x.Id);
                order.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
                order.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentId);
            });
            modelBuilder.Entity<Payment>(payment =>
            {
                payment.HasKey(x => x.Id);
            });
            modelBuilder.Entity<SaleCode>(salecode =>
            {
                salecode.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Picture>(img =>
            {
                img.HasKey(x => x.Id);
                img.HasOne(x => x.Product).WithMany(x => x.Pictures).HasForeignKey(x => x.ProductId);
            });



        }
    }
}
