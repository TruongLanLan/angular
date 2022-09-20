using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public double Price { get; set; }
        public double Quanitity { get; set; }

    }
}
