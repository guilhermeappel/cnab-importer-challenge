using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using CNAB.Importer.API.Infrastructure.Data.Repositories;
using CNAB.Importer.UnitTests.Infrastructure;

namespace CNAB.Importer.UnitTests.Utils
{
    public static class AuxiliaryMethods
    {
        public static UserRegisterInputModel CreateDefaultRegisterUser()
        {
            return new UserRegisterInputModel()
            {
                Username = "user",
                Password = "pswd",
            };
        }

        public static UserAuthInputModel CreateDefaultAuthUser()
        {
            return new UserAuthInputModel()
            {
                Username = "user",
                Password = "pswd",
            };
        }

        public static IUserRepository GetUserRepository(string databaseName = "test-db")
        {
            var contextFactory = new TestDbContextFactory(databaseName);
            var repositoryBase = new RepositoryBase<User>(contextFactory);

            return new UserRepository(repositoryBase);
        }
    }

}
