using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string phone { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
