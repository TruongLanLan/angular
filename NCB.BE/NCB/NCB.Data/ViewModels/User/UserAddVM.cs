using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Data.ViewModels.User
{
    public class UserAddVM
    {
        public string LAST_NM { get; set; }

        public string FIRST_NM { get; set; }

        public string ROLE_TYPE_CD { get; set; }

        public string PASSWORD { get; set; }

        public string STATUS_CD { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public string CREATE_USER { get; set; }

        public DateTime UPDATE_DATE { get; set; }

        public string UPDATE_USER { get; set; }

    }
}
