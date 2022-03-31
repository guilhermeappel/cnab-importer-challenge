using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;

namespace CNAB.Importer.API.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepositoryBase<User> _repository;

    public UserRepository(IRepositoryBase<User> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> GetAsync(Expression<Func<User, bool>>? filter = null, CancellationToken cancellationToken = default)
    {
        return await _repository.GetAsync(filter, cancellationToken);
    }

    public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        await _repository.AddAsync(entity, cancellationToken);
    }
}