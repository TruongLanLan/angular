
using DataAccessLayer.Interfaces;
using InfrastructureLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfworks
{
    public interface IUnitOfWork
    {
        public IGenericDataAccessLayer<Category> CategoryGeneric { get; }
        public IGenericDataAccessLayer<Supplier> SupplierGeneric { get; }
        public IGenericDataAccessLayer<Product> ProductGeneric { get; }
        public IGenericDataAccessLayer<Payment> PaymentGeneric { get; }
        public IGenericDataAccessLayer<User> UserGeneric { get; }
        public IGenericDataAccessLayer<Order> OrderGeneric { get; }
        public IGenericDataAccessLayer<OrderDetail> OrderDetailGeneric { get; }
        public IGenericDataAccessLayer<Comment> CommentGeneric { get; }

        void Save();
    }
}
