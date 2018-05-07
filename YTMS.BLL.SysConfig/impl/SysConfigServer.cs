using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Common.Core;
using YTMS.Domain;
using YTMS.DAL;
namespace YTMS.BLL.SysConfig
{
    public class SysConfigServer : ISysConfigServer
    {
        public SysConfigDto Get()
        {
            using (var db = DBManager.GetInstance())
            {
                var data = db.Queryable<T_Configs>().ToList().FirstOrDefault();

                if (data != null)
                    return data.MapTo<SysConfigDto>();
                return null;
            }

        }

        public bool Set(SysConfigDto opt)
        {
            if (opt == null)
                throw new ArgumentNullException("opt");

            using (var db = DBManager.GetInstance())
            {

                var config = db.Queryable<T_Configs>().ToList().FirstOrDefault();

                bool isAdd = config == null;

                if (isAdd)
                {
                    var obj = opt.MapTo<T_Configs>();
                    db.Insertable(obj).ExecuteCommand();
                }
                else
                {
                    db.Updateable<T_Configs>(new
                    {
                        Proportion = opt.Proportion,
                        FixedLoss = opt.FixedLoss,
                        PlatformPoint = opt.PlatformPoint,
                        FloorEarnings = opt.FloorEarnings,
                        RoomCoverMaxNum = opt.RoomCoverMaxNum,
                        LastModifyBy = opt.LastModifyBy,
                        LastModifyTime = opt.LastModifyTime
                    }).Where(w => w.Id == config.Id).ExecuteCommand();
                }

                return true;
            }
        }
    }
}
