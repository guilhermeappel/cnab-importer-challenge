using CNAB.Importer.API.Infrastructure.Data.Entities;

namespace CNAB.Importer.API.Application.ExtensionMethods;

public static class FileExtensions
{
    public static (List<Transaction> transactions, List<string> ignoredLines) ReadTransactions(this IFormFile file)
    {
        var transactions = new List<Transaction>();
        var ignoredLines = new List<string>();

        using var reader = new StreamReader(file.OpenReadStream());

        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine()?.TrimStart();

            if (string.IsNullOrWhiteSpace(line) || line.Length < 62)
            {
                continue;
            }

            try
            {
                var transaction = new Transaction()
                {
                    Type = line[..1].ToEnum<TTransaction>(),
                    Date = line[1..9].ToDateTime("yyyyMMdd"),
                    Value = line[9..19].ToFixedDecimal(),
                    Document = line[19..30],
                    Card = line[30..42],
                    Hour = line[42..48].ToStringHour(),
                    StoreOwnerName = line[48..62].Trim(),
                    StoreName = line[62..].Trim(),
                };

                transactions.Add(transaction);
            }
            catch
            {
                ignoredLines.Add(line);
            }
        }

        return (transactions, ignoredLines);
    }
}