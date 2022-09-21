using eShopBE.Data.repository.Interfaces;
using eShopBE.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace eShopBE.Data.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryGenericRepository { get; }
        IGenericRepository<Product> ProductGenericRepository { get; }
        IGenericRepository<Comment> CommentGenericRepository { get; }
        IGenericRepository<SaleCode> SaleCodeGenericRepository { get; }
        IGenericRepository<Payment> PaymentGenericRepository { get; }
        IGenericRepository<User> UserGenericRepository { get; }
        IGenericRepository<Supplier> SupplierGenericRepository { get; }
        IGenericRepository<Order> OrderGenericRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailGenericRepository { get; }
        IGenericRepository <Picture> PictureGenericRepository { get; }

        Task<int> CommitAsync();
        int SaveChange();
        Task<IDbContextTransaction> BeginTransactionAsync();

    }
}
