using MediatR;
using ProdX.Application.Interfaces;
using ProdX.Application.Queries.Requests;
using ProdX.Application.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdX.Application.Handlers.QueryHandlers
{
    public class GetAllProductsQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProducts();
            return products.Select(p => new GetAllProductQueryResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            }).ToList();
        }
    }
}
