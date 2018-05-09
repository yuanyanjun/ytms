using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    [SqlSugar.SugarTable("room_tags")]
    public class T_Room_Tags
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
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
