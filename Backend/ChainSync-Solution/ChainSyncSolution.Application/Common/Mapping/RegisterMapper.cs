using AutoMapper;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Common.Mapping;

public class RegisterMapper : Profile
{
    public RegisterMapper()
    {
        // Register
        CreateMap<RegisterCommand, User>()
             .ForMember(dest => dest.ProfileImage, opt => opt.Ignore());
        CreateMap<User, RegisterRequest>();

        // Login
        CreateMap<LoginQueries, User>();
        CreateMap<User, LoginRequest>();   
    }
}
