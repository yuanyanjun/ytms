using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using System.Configuration;

namespace YTMS.DAL
{
    public class SugarDao
    {
        //禁止实例化
        private SugarDao()
        {

        }
        public static string ConnectionString
        {
            get
            {
                string reval = ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString; //这里可以动态根据cookies或session实现多库切换
                return reval;
            }
        }

        public static string GetConnectionString(string contactionKey)
        {
            if (string.IsNullOrWhiteSpace(contactionKey))
            {

                return ConnectionString;
            }

            return ConfigurationManager.ConnectionStrings[contactionKey].ConnectionString;
        }

        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = ConnectionString });
            return db;
        }
    }
}
