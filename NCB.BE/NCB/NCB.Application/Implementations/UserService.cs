using AutoMapper;
using AutoMapper.Execution;
using NCB.Application.Interfaces;
using NCB.Common;
using NCB.Common.Enum;
using NCB.Data.Entities;
using NCB.Data.ViewModels.User;
using NCB.DataAccess.EF.Interfaces;
using NCB.DataAccess.EF.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Create(UserAddVM user)
        {
            var data = _mapper.Map<User>(user);
            await _unitOfWork.UserRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Create new user success", data);
        }

        public async Task<Response> Get(SearchKeyword searchKeyword)
        {
            if(searchKeyword.keyWord == null)
            {
                var data = await _unitOfWork.UserRepository.GetAllAsync();
                var listData = _mapper.Map<List<UserVM>>(data);
                return new Response(SystemCode.Success, "List user success", listData);
            }
            else
            {
                var data = await _userRepository.SearchForKeyword(searchKeyword);
                return new Response(SystemCode.Success, "List user with search keyword success", data);
            }
        }

        public async Task<Response> Update(UserUpdateVM user)
        {
            var data = await _unitOfWork.UserRepository.GetAsync(user.USER_ID);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found user", null);
            }
            _unitOfWork.UserRepository.Update(_mapper.Map<User>(data));
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update user success", _mapper.Map<User>(data));
        }
    }
}
