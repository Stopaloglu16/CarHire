using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Repositories;
using Domain.Entities.BranchAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasture.RepositoryTests
{
    public class BranchTests :TestBase
    {

        private readonly IBranchRepository _branchRepository;
        private readonly IAddressRepository _addressRepository;

        public BranchTests(IBranchRepository branchRepository, IAddressRepository addressRepository)
        {
           // UseSqlite();

            _branchRepository = branchRepository;
            _addressRepository = addressRepository;
        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {
            // Prepare
            using var context = await GetDbContext();

            var myBranch = new CreateBranchRequest() { BranchName = "Derby"  };

            var myBranch1 = await _branchRepository.AddAsync(new Branch()
            {

                BranchName = myBranch.BranchName,
                Address = new Domain.Entities.AddressAggregate.Address() { Address1 = myBranch.Address.Address1 }
            });


            // Execute
            var data = await _branchRepository.GetByIdAsync(myBranch1.Id);

            // Assert
            Assert.AreEqual(1, 1);
            

        }

    }
}
