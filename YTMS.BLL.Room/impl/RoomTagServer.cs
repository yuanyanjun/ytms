using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Domain;
using YTMS.DAL;
using YTMS.Common.Core;
namespace YTMS.BLL.Room
{
    public class RoomTagServer : IRoomTagServer
    {
        public int Add(RoomTagDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                var obj = dto as T_Room_Tags;
                return db.Insertable<T_Room_Tags>(dto).ExecuteReturnIdentity();
            }
        }

        public bool Edit(RoomTagDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                var dt = DateTime.Now;
                db.Updateable<T_Room_Tags>(new
                {
                    Name = dto.Name,
                    Sort = dto.Sort,
                    LastModifyTime = dt
                }).Where(w => w.Id == dto.Id).ExecuteCommand();

                return true;
            }
        }

        public bool ExistName(string name, int? id)
        {
            using (var db = DBManager.GetInstance())
            {
                var q = db.Queryable<T_Room_Tags>().Where(w => w.Name == name);

                if (id.HasValue)
                    q = q.Where(w => w.Id != id);

                return q.Any();
            }
        }

        public RoomTagDto Get(int id)
        {
            using (var db = DBManager.GetInstance())
            {
                return db.Queryable<T_Room_Tags>().Where(w => w.Id == id).Single().MapTo<RoomTagDto>();
            }
        }

        public List<RoomTagDto> List()
        {
            using (var db = DBManager.GetInstance())
            {
                var q = db.Queryable<T_Room_Tags>().Where(w => !SqlSugar.SqlFunc.HasValue(w.DeletedTime)).OrderBy(w => w.Sort);

                return q.ToList().MapToList<RoomTagDto>();
            }
        }

        public List<RoomTagDto> List(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return null;

            using (var db = DBManager.GetInstance())
            {
                return db.Queryable<T_Room_Tags>().Where(w => ids.Contains(w.Id.Value)).ToList().MapToList<RoomTagDto>();
            }
        }

        public bool Remove(int id)
        {
            using (var db = DBManager.GetInstance())
            {
                var dt = DateTime.Now;
                db.Updateable<T_Room_Tags>(new
                {
                    DeletedTime = dt
                }).Where(w => w.Id == id).ExecuteCommand();

                return true;
            }
        }
    }
}
