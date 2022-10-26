using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Data.Entities
{
    public class User
    {
        [Key]
        [MaxLength(14)]
        [Required]
        public string USER_ID { get; set; }

        [MaxLength(200)]
        public string LAST_NM { get; set; }

        [MaxLength(200)]
        public string FIRST_NM { get; set; }

        [MaxLength(1)]
        public string ROLE_TYPE_CD { get; set; }

        [MaxLength(64)]
        public string PASSWORD { get; set; }

        [MaxLength(5)]
        public string STATUS_CD { get; set; }

        [MaxLength(8)]
        public DateTime CREATE_DATE { get; set; }

        [MaxLength(14)]
        public string CREATE_USER { get; set; }

        [MaxLength(8)]
        public DateTime UPDATE_DATE { get; set; }

        [MaxLength(14)]
        public string UPDATE_USER { get; set; }

        public IEnumerable<Log_Login> LogLogins { get; set; }
    }
}
