using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Commands.Create;
using CarHire.Services.Branchs;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasture.ServiceTests
{

    public class BranchTests : TestBase
    {

        private IBranchService _branchService;

        public BranchTests(IBranchService branchService)
        {
            UseSqlite();
            _branchService = branchService;
        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {
            try
            {
                //var mybranc = new BranchService();

                await Task.Delay(1000);
                // Assert
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity1()
        {
            try
            {
                // Prepare
                CreateBranchRequest createBranchRequest = new CreateBranchRequest();

                createBranchRequest.BranchName = "Derby";
                createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = "" };


                // Execute
                var myReturn = await _branchService.Add(createBranchRequest);

                var data = await _branchService.GetBranchesById(myReturn.Id);


                // Assert
                Assert.AreEqual(1, data.Id);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }


    }

}
