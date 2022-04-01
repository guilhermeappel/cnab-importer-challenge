using CNAB.Importer.API.Application.Services.Implementations;
using CNAB.Importer.UnitTests.Infrastructure;
using CNAB.Importer.UnitTests.Utils;
using System.Threading.Tasks;
using Xunit;

namespace CNAB.Importer.UnitTests.Tests.Services;

public class UserTests : DependencyInjectionTest
{
    [Fact]
    public async Task UserValidate_Register_Success()
    {
        var repository = AuxiliaryMethods.GetUserRepository();
        var service = new UserService(repository, AppSettings);

        var inputUser = AuxiliaryMethods.CreateDefaultRegisterUser();

        var result = await service.RegisterAsync(inputUser);

        Assert.True(result.IsValid());
    }

    [Fact]
    public async Task UserValidate_Authenticate_Success()
    {
        var repository = AuxiliaryMethods.GetUserRepository();
        var service = new UserService(repository, AppSettings);

        var inputUserRegister = AuxiliaryMethods.CreateDefaultRegisterUser();
        _ = await service.RegisterAsync(inputUserRegister);

        var inputUserAuthenticate = AuxiliaryMethods.CreateDefaultAuthUser();
        var result = await service.AuthenticateAsync(inputUserAuthenticate);

        Assert.True(result.IsValid());
        Assert.NotNull(result.Response);
    }

    [Fact]
    public async Task UserValidate_Authenticate_Fail()
    {
        var repository = AuxiliaryMethods.GetUserRepository();
        var service = new UserService(repository, AppSettings);

        var inputUserAuthenticate = AuxiliaryMethods.CreateDefaultAuthUser();

        var result = await service.AuthenticateAsync(inputUserAuthenticate);

        Assert.False(result.IsValid());
        Assert.Null(result.Response);
    }
}