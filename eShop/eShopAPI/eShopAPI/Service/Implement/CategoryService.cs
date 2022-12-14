using AutoMapper;
using eShopAPI.Common;
using eShopAPI.Common.Enum;
using eShopAPI.Data.Entities;
using eShopAPI.Data.UoW;
using eShopAPI.Data.ViewModel.Category;
using eShopAPI.Service.Interface;

namespace eShopAPI.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       // private eShopDBContext _eShopDBContext;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Add(CategoryAddVM category)
        {
            var data = _mapper.Map<Category>(category);
           //var data = new Category(){
           //    CategoryName = category.CategoryName,
           //    Active = category.Active

           //};
            //await _eShopDBContext.Set<Category>().AddAsync(data);
            //await _eShopDBContext.SaveChangesAsync();            
            await _unitOfWork.CategoryGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add Success", null);
        }

        public async Task<Response> Delete(int Id)
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAsync(Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found category", null);
            }
            _unitOfWork.CategoryGenericRepository.Delete(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Detele success", null);

        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAllAsync();
            //var listCategoryVm = new List<CategoryVM>();
            //foreach (var item in data)
            //{
            //    var dataVm = _mapper.Map<CategoryVM>(item);
            //    listCategoryVm.Add(dataVm);
            //}
            var listCategoryVm = _mapper.Map<List<CategoryVM>>(data);
            return new Response(SystemCode.Success, "Find Success", listCategoryVm);

        }

        public async Task<Response> GetById(int Id)
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAsync(Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found category", null);
            }

            return new Response(SystemCode.Success, "Find Success", _mapper.Map<CategoryVM>(data));
        }

        public async Task<Response> Update(CategoryUpdateVM category)
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAsync(category.Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found category", null);
            }
            //   data = _mapper.Map<Category>(ả);
            data.CategoryName = category.CategoryName;
            data.Active = category.Active;
            _unitOfWork.CategoryGenericRepository.Update(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update success", data);
        }   
    }
}
