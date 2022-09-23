namespace eShopAPI.Data.Entities
{
    public class SaleCode
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public int ValueCode { get; set; }
        public bool IsDelete { get; set; }
        public DateTime StartDateCode { get; set; }
        public DateTime EndDateCode { get; set; }
    }
}
