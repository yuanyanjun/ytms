using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Configs
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public int? Id { get; set; }

        /// <summary>
        /// 分成比例
        /// </summary>
        public int Proportion { get; set; }

        /// <summary>
        /// 固定损耗
        /// </summary>
        public decimal FixedLoss { get; set; }

        /// <summary>
        /// 第三方平台扣点
        /// </summary>
        public float PlatformPoint { get; set; }

        /// <summary>
        /// 保底分成
        /// </summary>
        public decimal FloorEarnings { get; set; }

        /// <summary>
        /// 客房上传封面最大数量
        /// </summary>
        public int RoomCoverMaxNum { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModifyBy { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastModifyTime { get; set; }
    }
}
