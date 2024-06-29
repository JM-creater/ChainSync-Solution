using AutoMapper;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsers;

public class GetUsersQueriesHandler : IRequestHandler<GetUsersQueries, List<User>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueriesHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<User>> Handle(GetUsersQueries queries, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUsersAsync();

        await _unitOfWork.Save(cancellationToken);

        return user;
    }
}
