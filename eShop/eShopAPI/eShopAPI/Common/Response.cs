using eShopAPI.Common.Enum;

namespace eShopAPI.Common
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
