using Hafta._5.Application.Features.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryRequest: BaseGetQuery, IRequest<GetUserQueryResponse>
    {
        public int AgeRangeCeiling { get; set; }
        public int AgeRangeLower{ get; set; }
        public string? SearchByName { get; set; }
        public string? SearchByCity { get; set; }

    }
}
