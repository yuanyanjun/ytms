using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlSugar;
namespace YTMS.Domain
{
    [SqlSugar.SugarTable("rooms")]
    public class T_Room
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        /// <summary>
        /// 业主ID
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "user_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "serial_no")]
        public string SerialNo { get; set; }

        /// <summary>
        /// 房号
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_no")]
        public string RoomNo { get; set; }

        /// <summary>
        /// 房型ID
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_type_id")]
        public int RoomTypeId { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "floor_num", IsNullable = true)]
        public int FloorNum { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "bed_num")]
        public int BedNum { get; set; }
    }
}
