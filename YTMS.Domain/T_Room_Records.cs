using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Room_Records
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        /// <summary>
        /// 客人姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 客人联系电话
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public int CardType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// （预抵/入住）时间
        /// </summary>
        public DateTime? ArrvingTime { get; set; }

        /// <summary>
        /// 预离时间
        /// </summary>
        public DateTime? LeavingTime { get; set; }

        /// <summary>
        /// 预定状态下过期时间
        /// </summary>
        public DateTime? ExpiredTime { get; set; }

        /// <summary>
        /// 预定/入住天数
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// 客房ID
        /// </summary>
        public long RoomId { get; set; }

        /// <summary>
        /// 客房价格
        /// </summary>
        public decimal RoomPrice { get; set; }

        /// <summary>
        /// 状态 0：预定  1：入住  2：退房
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
