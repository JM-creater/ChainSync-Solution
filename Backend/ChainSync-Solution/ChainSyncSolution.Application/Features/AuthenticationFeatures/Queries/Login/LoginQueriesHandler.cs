using AutoMapper;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;

public class LoginQueriesHandler : IRequestHandler<LoginQueries, LoginRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueriesHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginRequest> Handle(
        LoginQueries queries,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(queries);

        var token = _jwtTokenGenerator.GenerateLoginToken(user);
        var login = _mapper.Map<LoginRequest>(user);

        login.Token = token;

        await _unitOfWork.Save(cancellationToken);

        await _userRepository.Login(user);

        return login;
    }
}
