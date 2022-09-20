using eShopBE.Infrastructure.Enum;

namespace eShopBE.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Allowed { get; set; }
        public IEnumerable<Order> Orders { get; set; }

    }
}
