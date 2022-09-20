using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Data
{
    public class CqrsDbContext : DbContext, ICqrsDbContext
    {

        public DbSet<Product> Products { get; set; }
        public CqrsDbContext(DbContextOptions<CqrsDbContext> options) : base(options)
        {

        }
        public async Task<int> SaveChange()
        {
            return await base.SaveChangesAsync();
        }
    }
}
