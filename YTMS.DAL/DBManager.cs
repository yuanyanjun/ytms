using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlSugar;
namespace YTMS.DAL
{
    public class DBManager
    {
        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = SugarDao.ConnectionString,
                DbType = DbType.MySql
            });
            return db;
        }

        public static SqlSugarClient GetInstance(string connectionKey)
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = SugarDao.GetConnectionString(connectionKey),
                DbType = DbType.MySql
            });
            return db;
        }
    }
}
