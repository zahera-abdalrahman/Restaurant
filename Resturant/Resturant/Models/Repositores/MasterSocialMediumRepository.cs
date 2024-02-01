using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterSocialMediumRepository : IRepository<MasterSocialMedium>
    {

        public MasterSocialMediumRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterSocialMedium entity)
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
            Db.MasterSocialMedia.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterSocialMedium entity)
        {
            
           Db.MasterSocialMedia.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedium entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterSocialMedia.Update(data);
            Db.SaveChanges();
        }

        public MasterSocialMedium Find(int Id)
        {
            var data = Db.MasterSocialMedia.SingleOrDefault(x=>x.MasterSocialMediumId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterSocialMedium entity)
        {
           
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterSocialMedium> View()
        {
            return Db.MasterSocialMedia.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedium> ViewClient()
        {
            return Db.MasterSocialMedia.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
