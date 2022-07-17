using Application.Repositories;
using Domain.Entities.CarHireAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CarHireRepos
{

    public class CarHireRepository : EfCoreRepository<CarHire>, ICarHireRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarHireRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckCarAvabilityById(int Id)
        {
            await Task.Delay(100);

         //   var careHireList = await _context.CarHires.FromSqlRaw("Select * FROM [Portalnow].[dbo].[PostcodeGroups] " +
         //"WHERE Id IN(SELECT[PostcodeGroupId]" +
         //"FROM[Portalnow].[dbo].[CompanyZonePostcodes] " +
         // "WHERE[PostcodeId] = ( " +
         //          "SELECT [Id] FROM[Portalnow].[dbo].[Postcodes] " +
         //          "WHERE IsDeleted = 0 AND PostcodeText = '" + _carId + "') ) ").ToListAsync();



            return true;
        }


        //public async Task<IEnumerable<BranchDto>> GetBranches()
        //{

        //    return await GetListByBool(true).Include(bb => bb.Address)
        //                                            .Select(ss => new BranchDto
        //                                            {
        //                                                Id = ss.Id,
        //                                                BranchName = ss.BranchName
        //                                                 ,
        //                                                Address = new AddressDto()
        //                                                {
        //                                                    Address1 = ss.Address.Address1,
        //                                                    City = ss.Address.City,
        //                                                    Postcode = ss.Address.Postcode
        //                                                }

        //                                            }).ToListAsync();
        //}
    }
}
