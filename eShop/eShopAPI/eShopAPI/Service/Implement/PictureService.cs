using AutoMapper;
using eShopAPI.Common;
using eShopAPI.Common.Enum;
using eShopAPI.Data.UoW;
using eShopAPI.Data.ViewModel.Picture;
using eShopAPI.Service.Interface;

namespace eShopAPI.Service.Implement
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PictureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.PictureGenericRepository.GetAllAsync();
            var listPictureVm = _mapper.Map<List<PictureVM>>(data);
            return new Response(SystemCode.Success, "Find Success", listPictureVm);

        }
    }
}
