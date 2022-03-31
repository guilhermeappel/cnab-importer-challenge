using CNAB.Importer.API.Application.Services.Implementations;
using CNAB.Importer.API.Application.Validators;
using CNAB.Importer.UnitTests.Infrastructure;
using CNAB.Importer.UnitTests.Utils;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CNAB.Importer.UnitTests.Tests.Validators
{
    public class UserTests : DependencyInjectionTest
    {
        [Fact]
        public async Task UserValidate_Authenticate_Success()
        {
            var repository = AuxiliaryMethods.GetUserRepository();

            var inputUserRegister = AuxiliaryMethods.CreateDefaultRegisterUser();

            var service = new UserService(repository, AppSettings);
            _ = await service.RegisterAsync(inputUserRegister);

            var inputUserAuth = AuxiliaryMethods.CreateDefaultAuthUser();

            var validator = new UserAuthInputModelValidator(repository, AppSettings);
            var validationResult = await validator.ValidateAsync(inputUserAuth);

            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public async Task UserValidate_Authenticate_Fail()
        {
            var repository = AuxiliaryMethods.GetUserRepository();

            var inputUserAuth = AuxiliaryMethods.CreateDefaultAuthUser();

            var validator = new UserAuthInputModelValidator(repository, AppSettings);
            var result = await validator.ValidateAsync(inputUserAuth);

            Assert.False(result.IsValid);
            Assert.Equal("Invalid username or password", result.Errors.First().ErrorMessage);
        }
    }
}
