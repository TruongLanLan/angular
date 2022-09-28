
using eShopAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PictureController : Controller
    {

        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPicture()
        {
            var result = await _pictureService.GetAll();
            return Ok(result);
        }
    }
}
