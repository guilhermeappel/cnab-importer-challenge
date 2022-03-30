using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;

namespace CNAB.Importer.API.Infrastructure.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IRepositoryBase<Transaction?> _repository;

    public TransactionRepository(IRepositoryBase<Transaction?> repository)
    {
        _repository = repository;
    }

    public async Task AddRangeAsync(IEnumerable<Transaction> transactions, CancellationToken cancellationToken = default)
    {
        await _repository.AddRangeAsync(transactions, cancellationToken);
    }
}