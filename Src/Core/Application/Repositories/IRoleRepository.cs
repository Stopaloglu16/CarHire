using Application.Aggregates.RoleAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.RoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {

        Task<IEnumerable<RoleDto>> GetCars();


    }
}
