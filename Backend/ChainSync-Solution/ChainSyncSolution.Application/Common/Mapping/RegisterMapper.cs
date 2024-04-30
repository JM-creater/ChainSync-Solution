using AutoMapper;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register;
using ChainSyncSolution.Domain.Dtos;
using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Common.Mapping;

public class RegisterMapper : Profile
{
    public RegisterMapper()
    {
        CreateMap<RegisterCommand, User>()
             .ForMember(dest => dest.ProfileImage, opt => opt.Ignore());
        CreateMap<User, RegisterRequest>();
    }
}
