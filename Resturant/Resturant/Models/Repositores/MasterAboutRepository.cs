using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterAboutRepository : IRepository<MasterAbout>
    {
        public MasterAboutRepository(AppDbContext db)
        {
            Db = db;
        }
        public AppDbContext Db { get; }
        public void Active(int Id, MasterAbout entity)
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
            Db.MasterAbout.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterAbout entity)
        {
            Db.MasterAbout.Add(entity);
            Db.SaveChanges();   
        }

        public void Delete(int Id, MasterAbout entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterAbout.Update(data);
            Db.SaveChanges();
        }

        public MasterAbout Find(int Id)
        {
            var data = Db.MasterAbout.SingleOrDefault(x => x.MasterAboutId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterAbout entity)
        {
            Db.MasterAbout.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterAbout> View()
        {
            return Db.MasterAbout.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterAbout> ViewClient()
        {
            return Db.MasterAbout.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
