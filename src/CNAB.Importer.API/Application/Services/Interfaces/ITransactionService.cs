using CNAB.Importer.API.Infrastructure.Application;

namespace CNAB.Importer.API.Application.Services.Interfaces;

public interface ITransactionService
{
    public Task<BaseResult> GetAsync();
    public Task<BaseResult> ImportFileAsync(IFormFile file);
}