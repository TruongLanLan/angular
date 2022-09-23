namespace eShopAPI.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
