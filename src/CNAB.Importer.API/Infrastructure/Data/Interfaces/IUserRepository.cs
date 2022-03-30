using CNAB.Importer.API.Infrastructure.Data.Entities;

namespace CNAB.Importer.API.Infrastructure.Data.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(User entity, CancellationToken cancellationToken = default);
}