using CQRS.Data;
using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Features.ProductFeatures.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly CqrsDbContext _context;
        public CreateProductCommandHandler(CqrsDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Barcode = request.Barcode;
            product.BuyingPrice = request.BuyingPrice;
            product.Rate = request.Rate;
            product.Description = request.Description;
            _context.Products.Add(product);
            await _context.SaveChange();
            return product.Id;
        }
    }
}
