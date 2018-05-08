using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Common.Core;
namespace YTMS.BLL.Order
{
    public class RecordQueryFilter : QueryFilter
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<long> RoomIds { get; set; }
    }
}
