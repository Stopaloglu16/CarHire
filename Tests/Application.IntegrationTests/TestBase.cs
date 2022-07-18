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



        public void UseSqlite()
        {
            _useSqlite = true;
        }
    }
}
