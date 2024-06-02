using AutoMapper;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Authentication;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;

public class LoginQueriesHandler : IRequestHandler<LoginQueries, LoginRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IExceptionConfiguration _exceptionConfiguration;

    public LoginQueriesHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator,
        IExceptionConfiguration exceptionConfiguration)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
        _exceptionConfiguration = exceptionConfiguration;
    }

    public async Task<LoginRequest> Handle(LoginQueries queries, CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomLoginValidator(queries);

        var user = await _userRepository.CheckPasswordLoginAsync(queries.Email, queries.Password);

        if (user == null)
        {
            throw new CheckPasswordLoginException(queries.Password);
        }

        var token = _jwtTokenGenerator.GenerateLoginToken(user);
        var login = _mapper.Map<LoginRequest>(user);

        login.Token = token;
        login.Role = user.Role;

        await _unitOfWork.Save(cancellationToken);

        await _userRepository.LoginAsync(user, cancellationToken);

        return login;
    }
}
