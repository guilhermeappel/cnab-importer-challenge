namespace CNAB.Importer.API.Infrastructure.Data.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
}