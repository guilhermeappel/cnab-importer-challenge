using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Application.Services.Interfaces;
using CNAB.Importer.API.Application.Utils;
using CNAB.Importer.API.Infrastructure.Application;
using CNAB.Importer.API.Infrastructure.Data.DTOs;
using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CNAB.Importer.API.Application.Services.Implementations;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _repository;
    private readonly IOptionsMonitor<AppSettings> _appSettings;

    public UserService(IUserRepository repository, IOptionsMonitor<AppSettings> appSettings)
    {
        _repository = repository;
        _appSettings = appSettings;
    }

    public async Task<BaseResult> AuthenticateAsync(UserAuthInputModel inputUser)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_appSettings.CurrentValue.AuthTokenSecretKey);

        var databaseUser = (await _repository.GetAsync(x => x.Username == inputUser.Username)).FirstOrDefault();

        if (databaseUser == null)
        {
            AddError("InvalidLogin", "User not registered.");
            return BaseResult;
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, inputUser.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, databaseUser.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        BaseResult.Response = new UserTokenDTO()
        {
            UserId = databaseUser.Id,
            Token = jwtTokenHandler.WriteToken(token)
        };

        return BaseResult;
    }

    public async Task<BaseResult> RegisterAsync(UserRegisterInputModel inputUser)
    {
        var argon2HashManager = new Argon2HashManager(_appSettings);

        var hashPassword = argon2HashManager.CreatePasswordHash(inputUser.Password);

        inputUser.Password = hashPassword;
        inputUser.PasswordConfirmation = hashPassword;

        var user = new User()
        {
            Username = inputUser.Username,
            Password = inputUser.Password
        };

        try
        {
            await _repository.AddAsync(user);
            BaseResult.Response = user.Id;
        }
        catch
        {
            AddError(string.Empty, "Unknown error while trying to register the user");
        }

        return BaseResult;
    }
}