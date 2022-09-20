using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class Order: BaseEntity
    {
        public int UserId { get; set; }
        public User Users { get; set; }
        public string Ordernumber { get; set; }

        public DateTime PaymentDate = DateTime.Now;
        public int PaymentId { get; set; }
        public Payment Payments { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public double TotalCost { get; set; }
        
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
