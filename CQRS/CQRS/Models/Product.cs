using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }
        public int Rate { get; set; }
        public int BuyingPrice { get; set; }
        public string ConfidentialData { get; set; }
    }
}
