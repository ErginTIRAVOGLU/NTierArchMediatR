using AutoMapper;
using NTierArch.Entities.DTOs.Categories;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.DTOs.Products;
using NTierArch.Entities.DTOs.Roles;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;

namespace NTierArch.Business.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        CreateMap<CreateRoleDto, AppRole>();
        CreateMap<UpdateRoleDto, AppRole>();

        CreateMap<CreateEmailParameterDto, EmailParameter>();
        CreateMap<UpdateEmailParameterDto, EmailParameter>();

        CreateMap<CreateSmsParameterDto, SmsParameter>();
        CreateMap<UpdateSmsParameterDto, SmsParameter>();
    }
}
