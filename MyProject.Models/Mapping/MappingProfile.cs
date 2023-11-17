using AutoMapper;
using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.Models.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Category , opt => opt.MapFrom(src => src.Category.CategoryName));
        
        CreateMap<Category, CategoryDto>();
        
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts.Select(p => p.Product)));
        CreateMap<OrderProduct, OrderProductDto>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Users,opt => opt.MapFrom(src => new UserDto{ UserId = src.ID, UserName = src.UserName} ));
        // CreateMap<DepositHistory, DepositHistoryDto>()
        //     .ForMember(dest => dest.UserwalletId,
        //         opt => opt.MapFrom(src => src.UserWallet.Id));

    }
    
}