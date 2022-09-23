using AutoMapper;
using eShopAPI.Common;
using eShopAPI.Common.Enum;
using eShopAPI.Data.Entities;
using eShopAPI.Data.UoW;
using eShopAPI.Data.ViewModel.User;
using eShopAPI.Service.Interface;

namespace eShopAPI.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Response> Add(UserAddVM user)
        {
            var data = _mapper.Map<User>(user);
            await _unitOfWork.UserGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "AddSuccess", null);
        }

        public async Task<Response> Delete(int Id)
        {
            var data = await _unitOfWork.UserGenericRepository.GetAsync(Id);
            if (data == null)
            {
                return new Response(SystemCode.Error, "Not found supplier", null);
            }
            _unitOfWork.UserGenericRepository.Delete(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete success", null);
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.UserGenericRepository.GetAllAsync();
            var listData = _mapper.Map<List<UserVM>>(data);
            return new Response(SystemCode.Success, "Get success", listData);
        }

        public async Task<Response> GetById(int Id)
        {
            var data = await _unitOfWork.UserGenericRepository.GetAsync(Id);
            return new Response(SystemCode.Success, "Get success", _mapper.Map<UserVM>(data));
        }

        public async Task<Response> Update(UserUpdateVM user)
        {
            var data = await _unitOfWork.UserGenericRepository.GetAsync(user.Id);
            if (data == null)
            {
                return new Response(SystemCode.Error, "Not found supplier", null);
            }
            _unitOfWork.UserGenericRepository.Update(_mapper.Map<User>(data));
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update success", _mapper.Map<User>(data));
        }
    }
}
