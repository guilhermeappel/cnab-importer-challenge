using CNAB.Importer.API.Application.Enums;
using CNAB.Importer.API.Application.ExtensionMethods;
using CNAB.Importer.API.Application.Services.Interfaces;
using CNAB.Importer.API.Application.Utils;
using CNAB.Importer.API.Infrastructure.Application;
using CNAB.Importer.API.Infrastructure.Data.DTOs;
using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;

namespace CNAB.Importer.API.Application.Services.Implementations;

public class TransactionService : BaseService, ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult> ImportFileAsync(IFormFile file)
    {
        // I'm using this approach considering that it always gonna receive "small" files.
        // Otherwise, I would not use this extension method and would create some optimized approach with streaming.
        // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-6.0#upload-large-files-with-streaming
        var (transactions, ignoredLines) = file.ReadTransactions();

        if (!transactions.Any())
        {
            AddError(string.Empty, "Incorrect file format");
            return BaseResult;
        }

        try
        {
            await _repository.AddRangeAsync(transactions);
            BaseResult.Response = new { ignoredLines };
        }
        catch
        {
            AddError(string.Empty, "Unknown error while trying to import transactions");
        }

        return BaseResult;
    }

    public async Task<BaseResult> GetAsync()
    {
        try
        {
            BaseResult.Response = (await _repository.GetAsync())
                .GroupBy(x => x.StoreName)
                .Select(x => new StoreTransactionDTO()
                {
                    StoreName = x.Key,
                    TotalAmount = x.Sum(transaction => IsSumOperator(transaction.Type) ? transaction.Value : -1 * transaction.Value),
                    Transactions = x.Select(transaction => transaction).ToList()
                });
        }
        catch
        {
            AddError(string.Empty, "Unknown error while trying to get transactions");
        }

        return BaseResult;
    }

    private static bool IsSumOperator(TTransaction key)
    {
        return ValidationHelpers.DictionaryOperations[key] == TransactionEnums.TOperation.Sum;
    }
}