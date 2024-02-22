using MediatR;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
public sealed record FinnalyDeleteCategoryCommand(Guid Id) : IRequest;
