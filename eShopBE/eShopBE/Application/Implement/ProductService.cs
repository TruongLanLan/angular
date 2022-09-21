using AutoMapper;
using eShopBE.Application.Interface;
using eShopBE.Data.repository.Interfaces;
using eShopBE.Data.UoW;
using eShopBE.Entities;
using eShopBE.Infrastructure;
using eShopBE.Infrastructure.Enum;
using eShopBE.ViewModel.ProductVM;

namespace eShopBE.Application.Implement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Add(ProductAddVM product)
        {
            var caegory = await _unitOfWork.CategoryGenericRepository.GetAsync(product.CategoryId);
            if(caegory == null)
            {
                return new Response(SystemCode.Error, "Category not exits", null);
            }
            var supplier = await _unitOfWork.SupplierGenericRepository.GetAsync(product.SupplierId);
            if(supplier == null)
            {
                return new Response(SystemCode.Error, "Supplier not exits", null);
            }
            if(product.Price < product.PriceInput)
            {
                return new Response(SystemCode.Warning, "The price must not be lower than the price input", null);
            }
            var data = _mapper.Map<Product>(product);
            await _unitOfWork.ProductGenericRepository.AddAsync(data);
            foreach(var item in data.Pictures)
            {
                item.ProductId = data.Id;
                item.Image = ConvertImage.SaveImage(item.Image, "Create Images");
                await _unitOfWork.PictureGenericRepository.AddAsync(item);
            }
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add Success", data.Id);
        }

        public async Task<Response> Detele(int id)
        {
            var data = await _unitOfWork.ProductGenericRepository.GetAsync(id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found product", null);
            }
            data.IsDeleted = true;
            _unitOfWork.ProductGenericRepository.Update(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete is success", data);
        }

        public async Task<Response> GetAll()
        {
            var data = await _productRepository.GetAllProduct();
            return new Response(SystemCode.Success, "get success", data);
        }

        public Task<Response> GetAllProductAdmin()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetAllProductInHome()
        {
            var data = await _productRepository.GetAllProductInHome();
            return new Response(SystemCode.Success, "Get success", data);
        }

        public async Task<Response> GetById(int id)
        {
            var data = await _productRepository.GetProductById(id); 
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found product", null);
            }
            return new Response(SystemCode.Success,"Get success", data);
        }

        public Task<Response> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetFeaturedProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetIdProductMax()
        {
            var data = await _productRepository.GetIdProductMax();
            return new Response(SystemCode.Success, "Get success", data.Id);
        }

        public async Task<Response> GetProductByCategoryId(int categoryId)
        {
            var data = await _productRepository.GetProductCategoryId(categoryId);
            if(data == null)
            {
                return new Response(SystemCode.Error, "No category", null);
            }
            return new Response(SystemCode.Success, "Get success", data);
        }

        public Task<Response> GetProductStock()
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetRecentProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(ProductUpdateVM product)
        {
            if(product.Price < product.PriceInput)
            {
                return new Response(SystemCode.Error, "The price must not be lower than the price input", null);
            }
            var data = await _unitOfWork.ProductGenericRepository.GetAsync(product.Id);
            if(data == null)
            {
                return new Response(SystemCode.Error, "Not found product", null);
            }
            var category = await _unitOfWork.CategoryGenericRepository.GetAsync(product.CategoryId);
            if(category == null)
            {
                return new Response(SystemCode.Error, "category not exits", null);
            }
            var supplier = await _unitOfWork.SupplierGenericRepository.GetAsync(product.SupplierId);
            if(supplier == null)
            {
                return new Response(SystemCode.Error, "Supplier not exits", null);
            }
            _unitOfWork.ProductGenericRepository.Update(_mapper.Map<Product>(data));
            var imageProductById = await _productRepository.GetImageByProductId(product.Id);
            if(imageProductById == null)
            {
                foreach(var item in product.Pictures)
                {
                    var picture = new Picture();
                    picture.ProductId = product.Id;
                    picture.Image = ConvertImage.SaveImage(item.Image, "Create Image");
                    _unitOfWork.PictureGenericRepository.Update(picture);
                }
            }
            else
            {
                foreach(var item in imageProductById)
                {
                    _unitOfWork.PictureGenericRepository.Delete(item);
                }
                foreach(var item in product.Pictures)
                {
                    var picture = new Picture();
                    picture.ProductId = product.Id;
                    picture.Image = ConvertImage.SaveImage(item.Image, "updateImages");
                    await _unitOfWork.PictureGenericRepository.AddAsync(picture);
                }
            }
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update success", data);
        }
    }
}
