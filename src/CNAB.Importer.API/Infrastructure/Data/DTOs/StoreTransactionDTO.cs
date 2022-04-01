using CNAB.Importer.API.Infrastructure.Data.Entities;

namespace CNAB.Importer.API.Infrastructure.Data.DTOs;

public class StoreTransactionDTO
{
    public string StoreName { get; set; }
    public decimal TotalAmount { get; set; }
    public List<Transaction> Transactions { get; set; }
}