using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceInput { get; set; }
        public double Inventory { get; set; }
        public string Description { get; set; }
        public int CatrgoryId { get; set; }
        public Category Categories { get; set; }
        public int SupplierId { get; set; }
        public Supplier Suppliers { get; set; }
        public string Images { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
