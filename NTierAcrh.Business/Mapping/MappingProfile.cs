using AutoMapper;
using NTierAcrh.Business.Features.Categories.CreateCategory;
using NTierAcrh.Business.Features.Categories.UpdateCategory;
using NTierAcrh.Business.Features.Products.CreateProduct;
using NTierAcrh.Business.Features.Products.UpdateProduct;
using NTierAcrh.Business.Features.Roles.CreateRole;
using NTierAcrh.Entities.Models;

namespace NTierAcrh.Business.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();

        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();

        CreateMap<CreateRoleCommand, AppRole>();
    }
}
