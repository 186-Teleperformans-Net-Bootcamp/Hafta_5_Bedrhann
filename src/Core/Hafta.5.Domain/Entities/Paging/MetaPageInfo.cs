using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Domain.Entities.Paging
{
    public class MetaPageInfo
    {
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
