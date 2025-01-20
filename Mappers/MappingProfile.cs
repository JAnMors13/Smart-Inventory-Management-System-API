using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Smart_Inventory_Management_System.DTOs.Account;
using Smart_Inventory_Management_System.DTOs.Category;
using Smart_Inventory_Management_System.DTOs.Order;
using Smart_Inventory_Management_System.DTOs.OrderItem;
using Smart_Inventory_Management_System.DTOs.Product;
using Smart_Inventory_Management_System.DTOs.User;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileRequestDto>().ReverseMap();
            CreateMap<UserProfile, CreateUserProfileRequestDto>().ReverseMap();
            CreateMap<IdentityUser, UserProfile>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductRequestDto>().ReverseMap();
            CreateMap<Product, UpdateProductRequestDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequestDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderRequestDto>().ReverseMap();
            CreateMap<Order, UpdateOrderRequestDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>()
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Product.Price * src.Quantity));
            CreateMap<OrderItem, CreateOrderItemRequestDto>().ReverseMap();

            CreateMap<RegisterDto, AppUser>().ReverseMap();

        }
    }
}
