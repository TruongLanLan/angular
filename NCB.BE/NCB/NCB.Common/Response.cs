using NCB.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Common
{
    public class Response
    {
        public Response()
        {

        }
        public Response(SystemCode code, string message, dynamic data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
        public SystemCode Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
