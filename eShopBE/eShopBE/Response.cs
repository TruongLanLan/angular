using eShopBE.Infrastructure.Enum;

namespace eShopBE
{
    public class Response
    {
        public Response()
        {
        }

        public Response(SystemCode code, string message, dynamic data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        public SystemCode Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

    }
}
