using Infrastructure.Data;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public abstract class TestBase
    {
        private bool _useSqlite;
        private static IServiceScopeFactory _scopeFactory;
        private static string _currentUserId;


        public async Task<ApplicationDbContext> GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            if (_useSqlite)
            {
                // Use Sqlite DB.
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                // Use In-Memory DB.
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(w =>
                {
                    w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                });
            }


            //var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            //                          .UseInMemoryDatabase(databaseName: "TestCatalog")
            //                          .Options;

            var dbContext = new ApplicationDbContext(builder.Options, null);

            if (_useSqlite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database and MS SQL.
                await dbContext.Database.OpenConnectionAsync();
            }

            await dbContext.Database.EnsureCreatedAsync();

            return dbContext;
        }



        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }


        public static async Task<string> RunAsDefaultUserAsync()
        {
            var userName = "test@local";
            var password = "Testing1234!";

            //using var scope = _scopeFactory.CreateScope();

            //var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            //var user = new ApplicationUser { UserName = userName, Email = userName };

            //var result = await userManager.CreateAsync(user, password);

            //_currentUserId = user.Id;
            await Task.Delay(1000);

            return _currentUserId;
        }


        public void UseSqlite()
        {
            _useSqlite = true;
        }
    }
}
