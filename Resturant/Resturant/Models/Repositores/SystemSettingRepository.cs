using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {

        public SystemSettingRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, SystemSetting entity)
        {
            var data = Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
                data.EditId = entity.EditId;
                data.EditDate = DateTime.Now;
            }

            else
            {
                data.IsActive = true;
                data.EditId = entity.EditId;
                data.EditDate = DateTime.Now;
            }
            Db.SystemSettings.Update(data);
            Db.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            entity.IsActive = true;
            Db.SystemSettings.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.SystemSettings.Update(data);
            Db.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            var data = Db.SystemSettings.SingleOrDefault(x=>x.SystemSettingId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, SystemSetting entity)
        {
           
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return Db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
            return Db.SystemSettings.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
