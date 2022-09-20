using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Features.ProductFeatures.Queries
{
    public class GetProductById : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
