using CQRS.Data;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Features.ProductFeatures.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly CqrsDbContext _context;
        public GetAllProductsQueryHandler(CqrsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            if (productList == null)
            {
                return null;
            }
            return productList.AsReadOnly();

        }
    }
}
