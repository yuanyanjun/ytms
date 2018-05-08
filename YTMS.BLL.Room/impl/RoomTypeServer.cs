using System;
using System.Collections.Generic;

using YTMS.Domain;
using YTMS.DAL;
using YTMS.Common.Core;
namespace YTMS.BLL.Room
{
    public class RoomTypeServer : IRoomTypeServer
    {
        public int Add(RoomTypeDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                var obj = dto as T_Room_Types;
                return db.Insertable<T_Room_Types>(dto).ExecuteReturnIdentity();
            }
        }

        public bool Edit(RoomTypeDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                var dt = DateTime.Now;
                db.Updateable<T_Room_Types>(new
                {
                    Name = dto.Name,
                    Sort = dto.Sort,
                    LastModifyTime = dt
                }).Where(w => w.Id == dto.Id).ExecuteCommand();

                return true;
            }
        }

        public RoomTypeDto Get(int id)
        {
            using (var db = DBManager.GetInstance())
            {
                return db.Queryable<T_Room_Types>().Where(w => w.Id == id).Single().MapTo<RoomTypeDto>();
            }
        }

        public List<RoomTypeDto> List()
        {
            using (var db = DBManager.GetInstance())
            {
                var q =  db.Queryable<T_Room_Types>().Where(w => !SqlSugar.SqlFunc.HasValue(w.DeletedTime));

                return q.ToList().MapToList<RoomTypeDto>();
            }
        }

        public List<RoomTypeDto> List(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return null;

            using (var db = DBManager.GetInstance())
            {
                return db.Queryable<T_Room_Types>().Where(w => ids.Contains(w.Id.Value)).ToList().MapToList<RoomTypeDto>();
            }
        }

        public bool Remove(int id)
        {
            using (var db = DBManager.GetInstance())
            {
                var dt = DateTime.Now;
                db.Updateable<T_Room_Types>(new
                {
                    DeletedTime = dt
                }).Where(w => w.Id == id).ExecuteCommand();

                return true;
            }
        }
    }
}
