﻿using ChainSyncSolution.Application.Interfaces.Abstraction;
using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Interfaces.Persistence;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> Register(User user);
    Task<User> GetByEmail(string email, CancellationToken request);
}