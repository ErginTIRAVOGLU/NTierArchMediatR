using MediatR;

namespace NTierAcrh.Business.Features.Products.DeleteProduct;
public sealed record DeleteProductCommand(
    Guid Id,
    Guid DeletedById
) : IRequest<Unit>;