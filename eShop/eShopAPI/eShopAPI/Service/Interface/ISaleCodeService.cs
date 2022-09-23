using eShopAPI.Common;
using eShopAPI.Data.ViewModel.SaleCode;

namespace eShopAPI.Service.Interface
{
    public interface ISaleCodeService
    {
        public Task<Response> DeleteCode(int id);
        public Task<Response> AddSaleCode(SaleCodeAddVM saleCode);
        public Task<Response> UpdateSaleCode(SaleCodeUpdateVM saleCode);
        public Task<Response> GetAllSaleCode();

    }
}
