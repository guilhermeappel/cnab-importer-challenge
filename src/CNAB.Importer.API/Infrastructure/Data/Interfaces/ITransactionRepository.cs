using CNAB.Importer.API.Infrastructure.Data.Entities;
using System.Linq.Expressions;

namespace CNAB.Importer.API.Infrastructure.Data.Interfaces;

public interface ITransactionRepository
{
    Task AddRangeAsync(IEnumerable<Transaction> entities, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transaction>> GetAsync(Expression<Func<Transaction, bool>>? filter = null, CancellationToken cancellationToken = default);
}