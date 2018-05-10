using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YTMS.Domain
{
    [SqlSugar.SugarTable("users")]
    public class T_Owner
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "id_card")]
        public string CardNo { get; set; }

        public string WxChat { get; set; }

        public string OpenId { get; set; }

        public string Img { get; set; }

        public string Address { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "room_num")]
        public int RoomNum { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "bank_name")]
        public string BankName { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "bank_deposit")]
        public string BankDeposit { get; set; }

        [SqlSugar.SugarColumn(ColumnName = "bank_account")]
        public string BankAccount { get; set; }

        public string Remark { get; set; }

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
