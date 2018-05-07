using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Room_Owner_Month_Settles
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 业主ID
        /// </summary>
        public long OwnerId { get; set; }

        /// <summary>
        /// 业主实际分成金额  按分成比例计算 
        /// </summary>
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 系统补差金额
        /// </summary>
        public decimal CompensationAmount { get; set; }

        /// <summary>
        /// 系统补差标准 如1800保底 此处存储就是1800
        /// </summary>
        public decimal FloorAmount { get; set; }

        /// <summary>
        /// 分成比例 0.35
        /// </summary>
        public decimal SeparatePercent { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
