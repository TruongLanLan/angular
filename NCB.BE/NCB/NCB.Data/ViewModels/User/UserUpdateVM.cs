using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Data.ViewModels.User
{
    public class UserUpdateVM
    {
        public string USER_ID { get; set; }
        public string LAST_NM { get; set; }

        public string FIRST_NM { get; set; }

        public string ROLE_TYPE_CD { get; set; }

        public string PASSWORD { get; set; }

        public string STATUS_CD { get; set; }
    }
}
