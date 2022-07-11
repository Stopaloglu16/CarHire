using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{
    public class BranchData
    {

        private readonly string[] branchNameArray;

        public BranchData()
        {
            branchNameArray = new string[4] { "Derby", "Nottingham", "Sheffield", "Mansfield" };
        }

        public  IEnumerable<CreateBranchRequest> CreateBranchData()
        {

            var myList = new List<CreateBranchRequest>();

            for (int i = 0; i < branchNameArray.Length; i++)
            {
                CreateBranchRequest createBranchRequest = new CreateBranchRequest();

                createBranchRequest.BranchName = branchNameArray[i];
                createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = branchNameArray[i] };

                myList.Add(createBranchRequest);
            }

            return myList;
        }


        public  IEnumerable<BranchDto> DisplayBranchData()
        {

            var myList = new List<BranchDto>();

            for (int i = 0; i < branchNameArray.Length; i++)
            {
                BranchDto createBranchRequest = new BranchDto();

                createBranchRequest.BranchName = branchNameArray[i];
                createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = branchNameArray[i] };

                myList.Add(createBranchRequest);
            }

            return myList;
        }


    }
}
