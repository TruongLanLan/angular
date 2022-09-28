using eShopAPI.Common;

namespace eShopAPI.Service.Interface
{
    public interface IPictureService
    {
        public Task<Response> GetAll();
    }
}
