using AutoMapper;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsers;

public class GetUsersQueriesHandler : IRequestHandler<GetUsersQueries, List<User>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public GetUsersQueriesHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper,
        IMemoryCache memoryCache)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<List<User>> Handle(
        GetUsersQueries queries,
        CancellationToken cancellationToken)
    {
        const string cacheKey = "User";

        if (!_memoryCache.TryGetValue(cacheKey, out List<User> user))
        {
            user = await _userRepository.GetUsersAsync();

            _memoryCache.Set(cacheKey, user,
                            new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
        }

        await _unitOfWork.Save(cancellationToken);

        return user;
    }
}
