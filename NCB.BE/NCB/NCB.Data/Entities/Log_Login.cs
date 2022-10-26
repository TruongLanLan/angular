using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Data.Entities
{
    public class Log_Login
    {
        [Key]
        [Required]
        public int SEQ { get; set; }
        [MaxLength(14)]
        [Required]
        public User USER_ID { get; set; }
        [MaxLength(8)]
        public DateTime LOGIN_DATE { get; set; }
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
        public User User { get; set; }

    }
}
