using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public MasterMenuRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterMenu entity)
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
            Db.MasterMenus.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            entity.IsActive = true;
            Db.MasterMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterMenus.Update(data);
            Db.SaveChanges();
          
        }

        public MasterMenu Find(int Id)
        {
            var data = Db.MasterMenus.SingleOrDefault(x=>x.MasterMenuId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterMenu entity)
        {
            
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return Db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return Db.MasterMenus.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
