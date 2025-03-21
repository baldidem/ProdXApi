using MediatR;
using ProdX.Application.Commands.Responses;

namespace ProdX.Application.Commands.Requests
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
