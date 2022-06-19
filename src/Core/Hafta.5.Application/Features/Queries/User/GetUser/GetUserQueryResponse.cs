using Hafta._5.Domain.Entities.Identity;
using Hafta._5.Domain.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryResponse
    {
        public IQueryable<AppUser> AppUsers { get; set; }
        public MetaPageInfo MetaPageInfo { get; set; }
    }
}
