using AutoMapper;
using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.Models.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category)));

        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Product)));

        CreateMap<Order, OrderDto>();
        CreateMap<OrderProduct, OrderProductDto>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Users,opt => opt.MapFrom(src => new UserDto{ UserId = src.UserId, UserName = src.UserName} ));
        // CreateMap<DepositHistory, DepositHistoryDto>()
        //     .ForMember(dest => dest.UserwalletId,
        //         opt => opt.MapFrom(src => src.UserWallet.Id));

    }
    
}