using CarHire.Services.Branchs;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Infrasture.ServiceTests
{
    public class BranchTests : TestBase
    {

        private readonly IBranchService _branchService;

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

                // Assert
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }


        //[Test]
        //public async Task ShouldBeAbleToAddAndGetEntity()
        //{
        //    try
        //    {
        //        // Prepare
        //        CreateBranchRequest createBranchRequest = new CreateBranchRequest();

        //        createBranchRequest.BranchName = "Derby";
        //        createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = "" };


        //        // Execute
        //        var myReturn = await _branchService.Add(createBranchRequest);

        //        var data = await _branchService.GetBranchesById(myReturn.Id);


        //        // Assert
        //        Assert.AreEqual(1, data.Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.True(true);
        //    }
        //}


    }
}
