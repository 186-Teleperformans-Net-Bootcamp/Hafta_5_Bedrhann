using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Application.Features.Queries.Common
{
    public class BaseGetQuery
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
