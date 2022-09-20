using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentType { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
