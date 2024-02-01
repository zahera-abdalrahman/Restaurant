using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {

        public MasterCategoryMenuRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
               
            }

            else
            {
                data.IsActive = true;               
            }
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterCategoryMenus.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterCategoryMenu entity)
        {
            
            Db.MasterCategoryMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterCategoryMenus.Update(data);
            Db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            var data = Db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id && x.IsDelete==false);
            return data;
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
          
            Db.MasterCategoryMenus.Update(entity);
            Db.SaveChanges();

        }

        public List<MasterCategoryMenu> View()
        {
            return Db.MasterCategoryMenus.Where(x => x.IsDelete==false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return Db.MasterCategoryMenus.Where(x=>x.IsDelete==false && x.IsActive==true).ToList();
        }
    }
}
