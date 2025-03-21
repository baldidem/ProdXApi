using MediatR;
using ProdX.Application.Interfaces;
using ProdX.Application.Queries.Requests;
using ProdX.Application.Queries.Responses;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProdX.Application.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            return new GetByIdProductQueryResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price= product.Price,
                Description= product.Description
            };
        }
    }
}
