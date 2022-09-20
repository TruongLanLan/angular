using CQRS.Data;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS.Features.ProductFeatures.Queries
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
    {
        private readonly CqrsDbContext _context;
        public GetProductByIdHandler(CqrsDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(GetProductById query, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            return product;
        }
    }
}
