namespace CNAB.Importer.API.Application.InputModels;

public class UserRegisterInputModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}