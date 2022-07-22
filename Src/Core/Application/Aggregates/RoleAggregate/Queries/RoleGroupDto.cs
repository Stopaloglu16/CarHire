using Domain.Common.Mappings;
using Domain.Entities.RoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aggregates.RoleAggregate.Queries
{
    public class RoleGroupDto : IMapFrom<RoleGroup>
    {

        public string RoleGroupName { get; set; }

        public int UserTypeID { get; set; }

    }
}
