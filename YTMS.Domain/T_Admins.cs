using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlSugar;
namespace YTMS.Domain
{
    [SqlSugar.SugarTable("admins")]
    public class T_Admins
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public string Name { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "Img")]
        public string HeaderPicture { get; set; }

        public string WxChat { get; set; }

        public string OpenId { get; set; }

        public string Type { get; set; }

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
