using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email{ get; set; }
        public string UserName { get; set; }
        public int CountOrder { get; set; }
        public string phone { get; set; }
        public double TotalPrice { get; set; }
        public string Password { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
