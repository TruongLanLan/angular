﻿using AutoMapper;
using eShopBE.Application.Interface;
using eShopBE.Data.UoW;
using eShopBE.Entities;
using eShopBE.Infrastructure.Enum;
using eShopBE.ViewModel.SupplierVM;

namespace eShopBE.Application.Implement
{
    public class SupplierService : ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Add(SupplierAddVM supplier)
        {
            var data = _mapper.Map<Supplier>(supplier);
            await _unitOfWork.SupplierGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "AddSuccess", null);
        }

        public async Task<Response> Delete(int Id)
        {
            var data = await _unitOfWork.SupplierGenericRepository.GetAsync(Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found supplier", null);
            }
            _unitOfWork.SupplierGenericRepository.Delete(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete success", null);
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.SupplierGenericRepository.GetAllAsync();
            var listData = _mapper.Map<List<SupplierVM>>(data);
            return new Response(SystemCode.Success, "Get success", listData);
        }

        public async Task<Response> GetById(int Id)
        {
            var data = await _unitOfWork.SupplierGenericRepository.GetAsync(Id);
            return new Response(SystemCode.Success, "Get success", _mapper.Map<SupplierVM>(data));
        }

        public async Task<Response> Update(SupplierUpdateVM supplier)
        {
            var data = await _unitOfWork.SupplierGenericRepository.GetAsync(supplier.Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found supplier", null);
            }
            _unitOfWork.SupplierGenericRepository.Update(_mapper.Map<Supplier>(data));
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update success", _mapper.Map<Supplier>(data));
        }
    }
}
