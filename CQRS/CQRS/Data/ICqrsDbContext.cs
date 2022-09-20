using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Data
{
    public interface ICqrsDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChange();
    }
}
