using eShopBE.Application.Interface;
using eShopBE.ViewModel.ProductVM;
using Microsoft.AspNetCore.Mvc;

namespace eShopBE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int Id)
        {
            return Ok(await _productService.GetById(Id));   
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            return Ok(await _productService.GetProductByCategoryId(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetIdProductMax()
        {
            return Ok(await _productService.GetIdProductMax());
        }
        [HttpDelete]
        public async Task<IActionResult> DeteleProduct(int Id)
        {
            return Ok(await _productService.Detele(Id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateVM product)
        {
            return Ok(await _productService.Update(product));
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddVM product)
        {
            return Ok(await _productService.Add(product));
        }

    }
}
