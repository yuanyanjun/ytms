using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Month_Settles
    {
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert =true)]
        public int? Id { get; set; }

        public string DataKey { get; set; }

        public int OwerId { get; set; }

        public decimal ActualAmount { get; set; }

        public decimal SysCompensationAmount { get; set; }

        public decimal SysCompensationModel { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
