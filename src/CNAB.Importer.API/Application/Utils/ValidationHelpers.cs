using CNAB.Importer.API.Application.Enums;
using CNAB.Importer.API.Infrastructure.Data.Entities;

namespace CNAB.Importer.API.Application.Utils;

public class ValidationHelpers
{
    public static Dictionary<TTransaction, TransactionEnums.TOperation> DictionaryOperations = new()
    {
        { TTransaction.Debit, TransactionEnums.TOperation.Sum },
        { TTransaction.Boleto, TransactionEnums.TOperation.Subtract },
        { TTransaction.Financing, TransactionEnums.TOperation.Subtract },
        { TTransaction.Credit, TransactionEnums.TOperation.Sum },
        { TTransaction.LoanReceipt, TransactionEnums.TOperation.Sum },
        { TTransaction.Sales, TransactionEnums.TOperation.Sum },
        { TTransaction.TedReceipt, TransactionEnums.TOperation.Sum },
        { TTransaction.DocReceipt, TransactionEnums.TOperation.Sum },
        { TTransaction.Rent, TransactionEnums.TOperation.Subtract }
    };
}