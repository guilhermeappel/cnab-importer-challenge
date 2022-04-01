using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Infrastructure.Data.Entities;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using CNAB.Importer.API.Infrastructure.Data.Repositories;
using CNAB.Importer.UnitTests.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;

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

        public static IFormFile CreateTextFormFile(string content)
        {
            var bytes = Encoding.UTF8.GetBytes(content);

            return new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", Guid.NewGuid().ToString());
        }

        public static IUserRepository GetUserRepository()
        {
            var contextFactory = new TestDbContextFactory();
            var repositoryBase = new RepositoryBase<User>(contextFactory);

            return new UserRepository(repositoryBase);
        }

        public static ITransactionRepository GeTransactionRepository()
        {
            var contextFactory = new TestDbContextFactory();
            var repositoryBase = new RepositoryBase<Transaction>(contextFactory);

            return new TransactionRepository(repositoryBase);
        }
    }

}
