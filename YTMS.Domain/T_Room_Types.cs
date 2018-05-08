using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlSugar;
namespace YTMS.Domain
{
    [SqlSugar.SugarTable("room_types")]
    public class T_Room_Types
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert =true)]
        public int? Id { get; set; }


        public string Name { get; set; }

        public int Sort { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "created_name")]
        public string CreateBy { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "created_at")]
        public DateTime CreateTime { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "updated_at")]
        public DateTime LastModifyTime { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "deleted_at", IsNullable = true)]
        public DateTime? DeletedTime { get; set; }
    }
}
