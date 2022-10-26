using NCB.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Data.ViewModels.User
{
    public class UserVM
    {
        public string USER_ID { get; set; }
        public string LAST_NM { get; set; }
        public string FIRST_NM { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string STATUS_CD { get; set; }
        public IEnumerable<Log_Login> LogLogins { get; set; }
    }
}
