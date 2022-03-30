namespace CNAB.Importer.API.Infrastructure.Data.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
}