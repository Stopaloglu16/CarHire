using Application.Aggregates.AddressAggregate.Queries;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public class BranchTests : TestBase
    {

        public BranchTests()
        {
            UseSqlite();
        }

        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {
            // Prepare
            using var context = await GetDbContext();

            // Prepare
            Branch branch = new Branch();

            branch.BranchName = "Derby";
            branch.Address = new Address() { Address1 = "", Postcode = "", City = "" };


            // Execute
            context.Add(branch);
            await context.SaveChangesAsync();

            // Assert
            Assert.AreEqual(1, branch.Id);

        }


        [Test]
        public async Task ShouldRequireMinimumFields()
        {

            // Prepare
            using var context = await GetDbContext();

            // Prepare
            Branch branch = new Branch();

            //branch.BranchName;
            branch.Address = new Address() { Address1 = "", Postcode = "", City = "" };

            // Execute
            context.Add(branch);

            // Assert
            Assert.ThrowsAsync<DbUpdateException>(async() => await context.SaveChangesAsync());

        }
    }
}
