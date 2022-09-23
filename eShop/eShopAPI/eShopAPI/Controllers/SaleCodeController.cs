
using eShopAPI.Data.ViewModel.SaleCode;
using eShopAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SaleCodeController : Controller
    {
        private readonly ISaleCodeService _saleCodeService;
        public SaleCodeController(ISaleCodeService saleCodeService)
        {
            _saleCodeService = saleCodeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetSaleCodeName()
        {
            var response = await _saleCodeService.GetAllSaleCode();
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddSaleCode(SaleCodeAddVM salecode)
        {
            var reponse = await _saleCodeService.AddSaleCode(salecode);
            return Ok(reponse);
        }
        

        [HttpPost]
        public async Task<IActionResult> UpdateSaleCode(SaleCodeUpdateVM saleCode)
        {
            var reponse = await _saleCodeService.UpdateSaleCode(saleCode);
            return Ok(reponse);
        }
       
        [HttpDelete]
        public async Task<IActionResult> DeleteCode(int id)
        {
            var reponse = await _saleCodeService.DeleteCode(id);
            return Ok(reponse);
        }

    }
}
