using CNAB.Importer.API.Infrastructure.Data.Entities;

namespace CNAB.Importer.API.Infrastructure.Data.Interfaces;

public interface ITransactionRepository
{
    Task AddRangeAsync(IEnumerable<Transaction> entities, CancellationToken cancellationToken = default);
}