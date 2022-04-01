namespace CNAB.Importer.API.Infrastructure.Data.Entities;

public class Transaction : BaseEntity
{
    public TTransaction Type { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public string Document { get; set; }
    public string Card { get; set; }
    public string Hour { get; set; }
    public string StoreOwnerName { get; set; }
    public string StoreName { get; set; }
}

public enum TTransaction : byte
{
    Debit = 1,
    Boleto = 2,
    Financing = 3,
    Credit = 4,
    LoanReceipt = 5,
    Sales = 6,
    TedReceipt = 7,
    DocReceipt = 8,
    Rent = 9
}