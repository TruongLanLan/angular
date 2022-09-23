
using eShopAPI.Data.ViewModel.User;
using eShopAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSupplier(int id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplier(UserAddVM user)
        {
            var result = await _userService.Add(user);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(UserUpdateVM user)
        {
            var result = await _userService.Update(user);
            return Ok(result);
        }
    }
}
