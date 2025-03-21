using MediatR;
using ProdX.Application.Commands.Requests;
using ProdX.Application.Commands.Responses;
using ProdX.Application.Interfaces;
using ProdX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdX.Application.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productId = Guid.NewGuid();
            var product = new Product
            {
                Id = productId,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description
            };

            await _productRepository.CreateProduct(product);

            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = productId
            };
        }
    }
}
