using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Infrastructure.Application;

namespace CNAB.Importer.API.Application.Services.Interfaces;

public interface IUserService
{
    public Task<BaseResult> AuthenticateAsync(UserAuthInputModel inputUser);
    public Task<BaseResult> RegisterAsync(UserRegisterInputModel inputUser);
}