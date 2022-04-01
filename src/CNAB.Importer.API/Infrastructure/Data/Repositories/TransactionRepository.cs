using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;

namespace CNAB.Importer.API.Infrastructure.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IRepositoryBase<Transaction> _repository;

    public TransactionRepository(IRepositoryBase<Transaction> repository)
    {
        _repository = repository;
    }

    public async Task AddRangeAsync(IEnumerable<Transaction> transactions, CancellationToken cancellationToken = default)
    {
        await _repository.AddRangeAsync(transactions, cancellationToken);
    }

    public async Task<IEnumerable<Transaction>> GetAsync(Expression<Func<Transaction, bool>>? filter = null, CancellationToken cancellationToken = default)
    {
        return await _repository.GetAsync(filter, cancellationToken);
    }
}