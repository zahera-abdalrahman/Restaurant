using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {

        public MasterWorkingHourRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterWorkingHour entity)
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
            Db.MasterWorkingHours.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterWorkingHour entity)
        {
            Db.MasterWorkingHours.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHour entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterWorkingHours.Update(data);
            Db.SaveChanges();
        }

        public MasterWorkingHour Find(int Id)
        {
            var data = Db.MasterWorkingHours.SingleOrDefault(x=>x.MasterWorkingHourId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterWorkingHour entity)
        {
            
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterWorkingHour> View()
        {
            return Db.MasterWorkingHours.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHour> ViewClient()
        {
            return Db.MasterWorkingHours.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
