using Application.IntegrationTests.TestData;
using CarHire.Services.Branchs;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class BranchServiceTests : TestBase
    {

        public BranchServiceTests()
        {
            UseSqlite();
        }

        private string? myBranchName;
        private BranchData? branchData;


        [SetUp]
        public void SetUp()
        {
            myBranchName = "Derby";
            branchData = new BranchData();
        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            using var context = await GetDbContext();
            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var myList = branchData.CreateBranchData().ToList();

            // Execute
            var myReturn = await myBranchService.Add(myList[0]);

            var data = await myBranchService.GetBranchesById(myReturn.Id);

            // Assert
            Assert.AreEqual(myBranchName, data.BranchName);

        }



        [Test]
        public async Task ShouldBeAbleToAddMultiAndGetList()
        {

            using var context = await GetDbContext();
            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var myList = branchData.CreateBranchData().ToList();

            // Execute
            for (int i = 0; i < myList.Count; i++)
            {
                var myReturn = await myBranchService.Add(myList[i]);
            }


            var data = await myBranchService.GetBranches();

            // Assert
            Assert.AreEqual(myList.Count, (int)data.Count());


        }


        [Test]
        public async Task ShouldBeAbleToAddMultiRemoveOneAndGetList()
        {

            using var context = await GetDbContext();
            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var myList = branchData.CreateBranchData().ToList();

            // Execute
            for (int i = 0; i < myList.Count; i++)
            {
                await myBranchService.Add(myList[i]);
            }


            await myBranchService.DeleteBranchById(2);

            var data = await myBranchService.GetBranches();

            // Assert
            Assert.AreEqual(myList.Count - 1, (int)data.Count());


        }


        [TearDown]
        public void Cleanup()
        {
            myBranchName = null;
            branchData = null;
            GC.Collect();
        }


    }


}
