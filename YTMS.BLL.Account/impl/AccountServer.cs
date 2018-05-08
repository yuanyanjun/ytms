using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Domain;
using YTMS.DAL;
using YTMS.Common.Core;
namespace YTMS.BLL.Account
{
    public class AccountServer : IAccountServer
    {
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
    }
}
