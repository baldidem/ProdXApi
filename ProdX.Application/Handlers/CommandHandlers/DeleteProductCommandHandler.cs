using MediatR;
using ProdX.Application.Commands.Requests;
using ProdX.Application.Commands.Responses;
using ProdX.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdX.Application.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler(IProductRepository _productRepository) : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProduct(request.Id);

            return new DeleteProductCommandResponse { IsSuccess = true };
        }
    }
}
