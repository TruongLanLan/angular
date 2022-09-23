using eShopAPI.Common.Enum;

namespace eShopAPI.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DeliveryStatus TransacStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string OrderCode { get; set; }
        public decimal TotalCost { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
