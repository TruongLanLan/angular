using AutoMapper;
using eShopBE.Application.Interface;
using eShopBE.Data.repository.Interfaces;
using eShopBE.Data.UoW;
using eShopBE.Entities;
using eShopBE.Infrastructure.Enum;
using eShopBE.ViewModel.UserViewM;

namespace eShopBE.Application.Implement
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response> Add(UserAddVM user)
        {
            if(await _userRepository.GetUserbyUserName(user.UserName) !=null)
            {
                return new Response(SystemCode.Error, "User exits", null);
            }
            var data = _mapper.Map<User>(user);
            data.CustomerRank = RANK.A;
            data.CoutOrder = 0;
            data.TotalPrice = 0;
            await _unitOfWork.UserGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add Success", data.Id);
        }

        public async Task<Response> Delete(int id)
        {
            var data = await _unitOfWork.UserGenericRepository.GetAsync(id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found user", null);
            }
            if(data.IsDeleted)
            {
                return new Response(SystemCode.Error, "User is deleted", null);
            }
            data.IsDeleted = true;
            _unitOfWork.UserGenericRepository.Update(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete success", data.Id);
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.UserGenericRepository.GetAllAsync();
            if(data == null)
            {
                return new Response(SystemCode.Error, "No user", null);
            }

            return new Response(SystemCode.Success, "Get success", data);
        }

        public async Task<Response> GetAllCustomers()
        {
            var data = await _userRepository.GetAllCustomers();
            if(data == null)
            {
                return new Response(SystemCode.Error, "No user", null);
            }
            var listData = _mapper.Map<UserVM>(data);
            return new Response(SystemCode.Success, "Get success", listData);
        }

        public async Task<Response> GetUserById(int id)
        {
            var data = await _unitOfWork.UserGenericRepository.GetAsync(id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "No user", null);
            }
            return new Response(SystemCode.Success, "Find success", data);
        }

        public async Task<Response> GetUserbyUserName(string userName)
        {
            var data = await _userRepository.GetUserbyUserName(userName);
            if(data == null)
            {
                return new Response(SystemCode.Error, "user not exits", null);
            }
            return new Response(SystemCode.Success, "Get success", data);
        }

        public async Task<Response> Update(UserUpdateVM user)
        {
            var data = await _unitOfWork.UserGenericRepository.GetAsync(user.Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "User not exits", null);
            }
            if(data.IsDeleted)
            {
                return new Response(SystemCode.Error, "User is deleted", null);
            }
            _unitOfWork.UserGenericRepository.Update(_mapper.Map<User>(data));
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update success", data.Id);
        }
    }
}
