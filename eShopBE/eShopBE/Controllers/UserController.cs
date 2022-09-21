using eShopBE.Application.Interface;
using eShopBE.ViewModel.UserViewM;
using Microsoft.AspNetCore.Mvc;

namespace eShopBE.Controllers
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
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddVM user)
        {
            return Ok(_userService.Add(user));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(_userService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateVM user)
        {
            return Ok(_userService.Update(user));
        }

    }
}
