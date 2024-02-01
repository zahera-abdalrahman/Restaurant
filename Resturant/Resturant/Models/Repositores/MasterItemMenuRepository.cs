using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {

        public MasterItemMenuRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterItemMenu entity)
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
            Db.MasterItemMenus.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
            entity.IsActive = true;
            Db.MasterItemMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterItemMenus.Update(data);
            Db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            var data = Db.MasterItemMenus.SingleOrDefault(x=>x.MasterItemMenuId==Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterItemMenu entity)
        {
           
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return Db.MasterItemMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            Db.MasterItemMenus.Include(x=>x.MasterCategoryMenu).ToList();
            return Db.MasterItemMenus.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
