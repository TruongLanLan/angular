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
    public class GetAllProductQuery :IRequest<IEnumerable<Product>>
    {
      
    }
}
