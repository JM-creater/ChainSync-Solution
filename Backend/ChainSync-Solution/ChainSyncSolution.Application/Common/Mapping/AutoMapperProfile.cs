using AutoMapper;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ForgotPassword;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ResetPassword;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.UpdateProducts;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Contracts.Common.Products;
using ChainSyncSolution.Contracts.Common.Users;
using ChainSyncSolution.Domain.Common.Enum;
using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Common.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Register
        CreateMap<RegisterCommand, User>()
             .ForMember(dest => dest.ProfileImage, opt => opt.Ignore())
              .ConstructUsing(src => new User(
                Guid.NewGuid(),                  
                DateTimeOffset.Now,           
                DateTimeOffset.Now,            
                null,                           
                src.FirstName,
                src.LastName,
                string.Empty,             
                src.Gender,
                src.Email,
                src.PhoneNumber,
                src.Password,                   
                src.Address,
                src.CompanyName,
                string.Empty,                 
                string.Empty,                 
                string.Empty,                  
                true,                         
                false,                          
                UserRole.Customer,
                string.Empty,
                default
             ));
        CreateMap<User, RegisterRequest>();

        CreateMap<SupplierRegisterCommand, User>()
           .ForMember(dest => dest.Document, opt => opt.Ignore())
           .ConstructUsing(src => new User(
                Guid.NewGuid(),                 
                DateTimeOffset.Now,            
                DateTimeOffset.Now,             
                null,                         
                string.Empty,                  
                string.Empty,                  
                src.SupplierId,
                string.Empty,                   
                src.Email,
                src.PhoneNumber,
                src.Password,                  
                src.Address,
                src.CompanyName,
                src.BizLicenseNumber,
                string.Empty,                 
                string.Empty,                   
                true,                          
                false,                         
                UserRole.Supplier,
                string.Empty,
                default
           ));
        CreateMap<User, SupplierRequest>();

        // Login
        CreateMap<LoginQueries, User>()
            .ConstructUsing(src => new User(
                Guid.NewGuid(),            
                DateTimeOffset.Now,           
                DateTimeOffset.Now,        
                null,                         
                string.Empty,                  
                string.Empty,                  
                string.Empty,                
                string.Empty,                   
                src.Email,
                string.Empty,                   
                src.Password,                  
                string.Empty,                  
                string.Empty,               
                string.Empty,                  
                string.Empty,                
                string.Empty,               
                true,                           
                false,                    
                UserRole.Customer,
                string.Empty,
                default
            )); 
        CreateMap<User, LoginRequest>();

        // Update Customer Profile
        CreateMap<User, UpdateCustomerProfileRequest>();

        // Forgot Password
        CreateMap<ForgotPasswordCommand, ForgotPasswordRequest>();

        // Reset Password
        CreateMap<ResetPasswordCommand, User>();
        CreateMap<User, ResetPasswordRequest>();

        // Create Product
        CreateMap<CreateProductsCommand, Product>()
            .ForMember(dest => dest.ProductImage, opt => opt.Ignore())
            .ConstructUsing(src => new Product(
                Guid.NewGuid(),
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                null,
                src.ProductName,
                src.Description,
                src.SupplierId,
                src.PhoneNumber,
                src.Price,
                string.Empty,
                src.QuantityOnHand,
                false
                ));
        CreateMap<Product, CreateProductsRequest>();

        // Update Product
        CreateMap<UpdateProductsCommand, Product>()
            .ForMember(dest => dest.ProductImage, opt => opt.Ignore());
        CreateMap<Product, UpdateProductsRequest>();
    }
}
