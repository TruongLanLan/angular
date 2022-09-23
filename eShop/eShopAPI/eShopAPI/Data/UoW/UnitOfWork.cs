using eShopAPI.Data.Context;
using eShopAPI.Data.Entities;
using eShopAPI.DataAccess.Implemention;
using eShopAPI.DataAccess.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace eShopAPI.Data.UoW
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
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Category>(_dbContext);
                }
                return _categoryRepository;
            }
        }

        public IGenericRepository<Product> ProductGenericRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_dbContext);
                }
                return _productRepository;
            }
        }

        public IGenericRepository<Comment> CommentGenericRepository
        {
            get { return _commentRepository; }
        }

        public IGenericRepository<SaleCode> SaleCodeGenericRepository
        {
            get
            {
                if (this._saleCodeRepository == null)
                {
                    this._saleCodeRepository = new GenericRepository<SaleCode>(_dbContext);
                }
                return _saleCodeRepository;
            }
        }

        public IGenericRepository<Payment> PaymentGenericRepository
        {
            get { return _paymentRepository; }
        }

        public IGenericRepository<User> UserGenericRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_dbContext);
                }
                return _userRepository;
            }
        }

        public IGenericRepository<Supplier> SupplierGenericRepository
        {
            get

            {
                if (this._supplierRepository == null)
                {
                    this._supplierRepository = new GenericRepository<Supplier>(_dbContext);
                }
                return _supplierRepository;
            }
        }

        public IGenericRepository<Order> OrderGenericRepository
        {
            get { return _orderRepository; }
        }

        public IGenericRepository<OrderDetail> OrderDetailGenericRepository
        {
            get { return _orderDetailRepository; }
        }

        public IGenericRepository<Picture> PictureGenericRepository
        {
            get
            {
                if (this._pictureRepository == null)
                {
                    this._pictureRepository = new GenericRepository<Picture>(_dbContext);
                }
                return _pictureRepository;
            }
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
            if (!this.dispose)
            {
                if (disposing)
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
