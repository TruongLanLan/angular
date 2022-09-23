using AutoMapper;
using eShopAPI.Common;
using eShopAPI.Common.Enum;
using eShopAPI.Data.Entities;
using eShopAPI.Data.UoW;
using eShopAPI.Data.ViewModel.SaleCode;
using eShopAPI.Service.Interface;

namespace eShopAPI.Service.Implement
{
    public class SaleCodeService : ISaleCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SaleCodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> AddSaleCode(SaleCodeAddVM saleCode)
        {
            if (saleCode.EndDateCode < saleCode.StartDateCode)
            {
                return new Response(SystemCode.Error, "EndDate cant not less StartDate", null);
            }
            var saleCodeNew = _mapper.Map<SaleCode>(saleCode);

            await _unitOfWork.SaleCodeGenericRepository.AddAsync(saleCodeNew);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add SaleCode Success", saleCodeNew.Id);
        }

        public async Task<Response> DeleteCode(int id)
        {
            var saleCode = await _unitOfWork.SaleCodeGenericRepository.GetAsync(id);
            if (saleCode == null) { return new Response(SystemCode.Error, "Salecode is null", null); }

            _unitOfWork.SaleCodeGenericRepository.Delete(saleCode);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete is Success ", saleCode.Id);
        }


        public async Task<Response> GetAllSaleCode()
        {
            var data = await _unitOfWork.SaleCodeGenericRepository.GetAllAsync();
            return new Response(SystemCode.Success, "Get all success", data);
        }

      
        public async Task<Response> UpdateSaleCode(SaleCodeUpdateVM saleCode)
        {

            var saleCodeData = await _unitOfWork.SaleCodeGenericRepository.GetAsync(saleCode.Id);
            if (saleCodeData == null)
            {
                return new Response(SystemCode.Error, "Get data is null", null);
            }
            var saleCodeUpdate = _mapper.Map<SaleCode>(saleCode);
            _unitOfWork.SaleCodeGenericRepository.Update(saleCodeUpdate);
            return new Response(SystemCode.Success, "Update Sale Code Success full", saleCode.Id);
        }




    }
}
