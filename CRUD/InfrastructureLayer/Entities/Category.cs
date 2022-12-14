using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public bool Active { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
