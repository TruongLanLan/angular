
using eShopAPI.Data.ViewModel.Category;
using eShopAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.Delete(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddVM category)
        {
            var result = await _categoryService.Add(category);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateVM category)
        {
            var result = await _categoryService.Update(category);
            return Ok(result);
        }
    }
}
