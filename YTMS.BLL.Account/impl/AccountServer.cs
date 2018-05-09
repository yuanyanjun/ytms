using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Domain;
using YTMS.DAL;
using YTMS.Common.Core;
using SqlSugar;
namespace YTMS.BLL.Account
{
    public class AccountServer : IAccountServer
    {
        public long Add(AdminDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                var obj = dto as T_Admins;

                return db.Insertable(obj).ExecuteReturnBigIdentity();
            }
        }

        public bool Edit(AdminDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {

                db.Updateable<T_Admins>(new
                {
                    Account = dto.Account,
                    LastModifyTime = dto.LastModifyTime,
                    Name = dto.Name,
                    Sex = dto.Sex,
                    Type = dto.Type,
                    WxChat = dto.WxChat,
                    Phone = dto.Phone
                }).Where(i => i.Id == dto.Id).ExecuteCommand();

                return true;
            }
        }

        public bool EditPassword(string account, string password)
        {
            if (string.IsNullOrWhiteSpace(account))
                throw new CustomerException("账号不能为空");
            if (string.IsNullOrWhiteSpace(password))
                throw new CustomerException("密码不能为空");

            using (var db = DBManager.GetInstance())
            {
                db.Updateable<T_Admins>(new
                {
                    Password = password
                }).Where(i => i.Account == account).ExecuteCommand();

                return true;
            }
        }

        public bool ExistName(string account, long? id)
        {
            using (var db = DBManager.GetInstance())
            {
                var q = db.Queryable<T_Admins>().Where(i => i.Account == account);

                if (id.HasValue)
                    q = q.Where(i => i.Id == id);

                return q.Any();
            }
        }

        public AdminDto Get(long id)
        {
            using (var db = DBManager.GetInstance())
            {
                var row = db.Queryable<T_Admins>().Where(w => w.Id == id).ToList().FirstOrDefault();

                if (row != null)
                    return row.MapTo<AdminDto>();

                return null;
            }
        }

        public AdminDto Get(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;

            using (var db = DBManager.GetInstance())
            {
                var row = db.Queryable<T_Admins>().Where(w => w.Account == userName).ToList().FirstOrDefault();

                if (row != null)
                    return row.MapTo<AdminDto>();

                return null;
            }
        }

        public List<AdminDto> List(AdminQueryFilter filter)
        {
            if (filter == null)
                return null;
            using (var db = DBManager.GetInstance())
            {
                var q = db.Queryable<T_Admins>();

                if (!string.IsNullOrWhiteSpace(filter.Keywords))
                    q = q.Where(w => w.Name.Equals(filter.Keywords) || w.Account.Equals(filter.Keywords));

                if (filter.IsDeleted.HasValue && filter.IsDeleted.Value)
                {
                    q = q.Where(w => !SqlFunc.IsNullOrEmpty(w.DeletedTime));
                }
                else
                {
                    //默认排除掉删除项目
                    q = q.Where(w => SqlFunc.IsNullOrEmpty(w.DeletedTime));
                }

                if (filter.AccountIds != null && filter.AccountIds.Count > 0)
                {
                    q = q.Where(w => filter.AccountIds.Contains(w.Id.Value));
                }

                int total = 0;
                var data = q.ToPageList(filter.PageIndex, filter.PageSize, ref total).MapToList<AdminDto>();
                filter.TotalCount = total;

                return data;
            }
        }

        public bool Remove(long id)
        {
            using (var db = DBManager.GetInstance())
            {
                db.Updateable<T_Admins>(new { DeletedTime = SqlFunc.GetDate() }).Where(w => w.Id == id).ExecuteCommand();

                return true;
            }
        }
    }
}
