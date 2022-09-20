using eShopBE.Data.Context;
using eShopBE.Data.repository.Interfaces;
using eShopBE.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace eShopBE.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly eShopDBContext _dbContext;

        protected IGenericRepository<Category> _categoryRepository;
        protected IGenericRepository<Product> _productRepository;
        protected IGenericRepository<Order> _orderRepository;
        protected IGenericRepository<OrderDetail> _orderDetailRepository;
        protected IGenericRepository<Payment> _paymentRepository;
        protected IGenericRepository<Picture> _pictureRepository;
        protected IGenericRepository<Comment> _commentRepository;
        protected IGenericRepository<Supplier> _supplierRepository;
        protected IGenericRepository<SaleCode> _saleCodeRepository;
        protected IGenericRepository<User> _userRepository;

        public UnitOfWork(eShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<Category> CategoryGenericRepository
        {
            get { return _categoryRepository; }
        }

        public IGenericRepository<Product> ProductGenericRepository
        {
            get { return _productRepository; }
        }

        public IGenericRepository<Comment> CommentGenericRepository
        {
            get { return _commentRepository; }
        }

        public IGenericRepository<SaleCode> SaleCodeGenericRepository
        {
            get { return _saleCodeRepository;}
        }

        public IGenericRepository<Payment> PaymentGenericRepository
        {
            get { return _paymentRepository; }
        }

        public IGenericRepository<User> UserGenericRepository
        {
            get { return _userRepository; }
        }

        public IGenericRepository<Supplier> SupplierGenericRepository
        {
            get { return _supplierRepository; }
        }

        public IGenericRepository<Order> OrderGenericRepository
        {
            get { return _orderRepository; }
        }

        public IGenericRepository<OrderDetail> OrderDetailGenericRepository
        {
            get { return _orderDetailRepository; }
        }

        public IGenericRepository<Picture> PictureOrderDetailGenericRepository
        {
            get { return _pictureRepository; }
        }
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync(new CancellationToken());
            
        }

        private bool dispose = false;
        protected virtual void Dispose(bool disposing)
        {
           if(!this.dispose)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
            }
           this.dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
    }
}
