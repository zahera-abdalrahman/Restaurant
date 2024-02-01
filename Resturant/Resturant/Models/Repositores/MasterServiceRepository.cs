using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterServiceRepository : IRepository<MasterService>
    {

        public MasterServiceRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterService entity)
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
            Db.MasterServices.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterService entity)
        {
            Db.MasterServices.Add(entity);
            Db.SaveChanges();

        }

        public void Delete(int Id, MasterService entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterServices.Update(data);
            Db.SaveChanges();
        }

        public MasterService Find(int Id)
        {
            var data = Db.MasterServices.SingleOrDefault(x => x.MasterServiceId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterService entity)
        {
            
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterService> View()
        {
            return Db.MasterServices.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterService> ViewClient()
        {
            return Db.MasterServices.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
