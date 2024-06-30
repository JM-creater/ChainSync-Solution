using AutoMapper;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateCustomerProfile;
using ChainSyncSolution.Contracts.Common.Authentication;
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
                UserRole.Customer                   
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
                UserRole.Supplier                
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
                UserRole.Customer                  
            )); 
        CreateMap<User, LoginRequest>();

        // Update Customer Profile
        CreateMap<UpdateCustomerProfileCommand, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<User, UpdateCustomerProfileRequest>();
    }
}
