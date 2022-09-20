using DataAccessLayer.DataUIContext;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using InfrastructureLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfworks
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        protected IGenericDataAccessLayer<Category> _categoryGeneric;
        protected IGenericDataAccessLayer<Supplier> _supplierGeneric;
        protected IGenericDataAccessLayer<Product> _productGeneric;
        protected IGenericDataAccessLayer<Payment> _paymentGeneric;
        protected IGenericDataAccessLayer<User> _userGeneric;
        protected IGenericDataAccessLayer<Order> _orderGeneric;
        protected IGenericDataAccessLayer<OrderDetail> _orderDetailGeneric;
        protected IGenericDataAccessLayer<Comment> _commentGeneric;


        public IGenericDataAccessLayer<Category> CategoryGeneric
        {
            get
            {
                if(this._categoryGeneric == null)
                {
                    this._categoryGeneric = new GenericDataAccessLayer<Category>(_dataContext);
                }
                return _categoryGeneric;
            }
        }

        public IGenericDataAccessLayer<Supplier> SupplierGeneric
        {
            get
            {
                if (this._supplierGeneric == null)
                {
                    this._supplierGeneric = new GenericDataAccessLayer<Supplier>(_dataContext);
                }
                return _supplierGeneric;
            }
        }
        public IGenericDataAccessLayer<Product> ProductGeneric
        {
            get
            {
                if (this._productGeneric == null)
                {
                    this._productGeneric = new GenericDataAccessLayer<Product>(_dataContext);
                }
                return _productGeneric;
            }
        }
        public IGenericDataAccessLayer<Payment> PaymentGeneric
        {
            get
            {
                if (this._paymentGeneric == null)
                {
                    this._paymentGeneric = new GenericDataAccessLayer<Payment>(_dataContext);
                }
                return _paymentGeneric;
            }
        }
        public IGenericDataAccessLayer<User> UserGeneric
        {
            get
            {
                if (this._userGeneric == null)
                {
                    this._userGeneric = new GenericDataAccessLayer<User>(_dataContext);
                }
                return _userGeneric;
            }
        }
        public IGenericDataAccessLayer<Order> OrderGeneric
        {
            get
            {
                if (this._orderGeneric == null)
                {
                    this._orderGeneric = new GenericDataAccessLayer<Order>(_dataContext);
                }
                return _orderGeneric;
            }
        }
        public IGenericDataAccessLayer<OrderDetail> OrderDetailGeneric
        {
            get
            {
                if (this._orderDetailGeneric == null)
                {
                    this._orderDetailGeneric = new GenericDataAccessLayer<OrderDetail>(_dataContext);
                }
                return _orderDetailGeneric;
            }
        }
        public IGenericDataAccessLayer<Comment> CommentGeneric
        {
            get
            {
                if (this._commentGeneric == null)
                {
                    this._commentGeneric = new GenericDataAccessLayer<Comment>(_dataContext);
                }
                return _commentGeneric;
            }
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
