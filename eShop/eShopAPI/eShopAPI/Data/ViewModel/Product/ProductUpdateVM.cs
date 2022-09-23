using eShopAPI.Data.ViewModel.Picture;

namespace eShopAPI.Data.ViewModel.Product
{
    public class ProductUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceInput { get; set; }
        public int Sale { get; set; }
        public int Inventory { get; set; }
        public int Insurance { get; set; }
        public string Accessory { get; set; }
        public string Sensor { get; set; }
        public string ImageProcessor { get; set; }
        public string Screen { get; set; }
        public string ISO { get; set; }
        public string ShutterSpeed { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public IEnumerable<PictureUpdateVM> Pictures { get; set; }
    }
}
