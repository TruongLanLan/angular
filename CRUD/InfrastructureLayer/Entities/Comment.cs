using InfrastructureLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Entities
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public User Users { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public string CommentText { get; set; }

    }
}
