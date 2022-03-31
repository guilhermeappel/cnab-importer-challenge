using CNAB.Importer.API.Infrastructure.Data.Entities;
using System.Linq.Expressions;

namespace CNAB.Importer.API.Infrastructure.Data.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAsync(Expression<Func<User, bool>> filter = null, CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(User entity, CancellationToken cancellationToken = default);
}