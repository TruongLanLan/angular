namespace eShopAPI.Data.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
