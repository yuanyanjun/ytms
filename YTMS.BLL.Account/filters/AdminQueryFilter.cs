using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Account
{
    public class AdminQueryFilter : YTMS.Common.Core.QueryPageFilter
    {
        public bool? IsDeleted { get; set; }

        public List<long> AccountIds { get; set; }
    }
}
