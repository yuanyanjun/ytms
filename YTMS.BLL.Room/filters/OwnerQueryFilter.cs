using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Room
{
    public class OwnerQueryFilter:YTMS.Common.Core.QueryPageFilter
    {
        public List<long> OwnerIds { get; set; }

        public bool? IsDeleted { get; set; }

        public string Phone { get; set; }

        public string CardNo { get; set; }
    }
}
