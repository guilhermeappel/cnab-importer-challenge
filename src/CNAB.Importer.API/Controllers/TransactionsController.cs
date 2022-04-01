using CNAB.Importer.API.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CNAB.Importer.API.Controllers;

public class TransactionsController : BaseController
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService service)
    {
        _transactionService = service;
    }

    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadAsync(IFormFile file)
    {
        var result = await _transactionService.ImportFileAsync(file);

        return result.IsValid() ? Ok(result.Response) : CustomResponse(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _transactionService.GetAsync();

        return result.IsValid() ? Ok(result.Response) : CustomResponse(result);
    }
}