using Microsoft.EntityFrameworkCore;
using PaymentDetailApi.Models;

namespace PaymentDetailApi.Data
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) : base(options)
        {

        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
