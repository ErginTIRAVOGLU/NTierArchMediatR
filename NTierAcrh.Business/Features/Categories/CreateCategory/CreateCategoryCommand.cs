using MediatR;

namespace NTierAcrh.Business.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    string Name) : IRequest;
