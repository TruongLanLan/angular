
using eShopAPI.Data.ViewModel.Supplier;
using eShopAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var result = await _supplierService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdSupplier(int id)
        {
            var result = await _supplierService.GetById(id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var result = await _supplierService.Delete(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierAddVM supplier)
        {
            var result = await _supplierService.Add(supplier);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(SupplierUpdateVM supplier)
        {
            var result = await _supplierService.Update(supplier);
            return Ok(result);
        }
    }
}
