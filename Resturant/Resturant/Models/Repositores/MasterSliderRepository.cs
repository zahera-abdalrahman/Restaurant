using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {

        public MasterSliderRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterSlider entity)
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
            Db.MasterSliders.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            Db.MasterSliders.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterSliders.Update(data);
            Db.SaveChanges();        
        }

        public MasterSlider Find(int Id)
        {
            var data = Db.MasterSliders.SingleOrDefault(x=>x.MasterSliderId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterSlider entity)
        {
            Db.MasterSliders.Update(entity);
            Db.SaveChanges();         
        }

        public List<MasterSlider> View()
        {
           return Db.MasterSliders.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return Db.MasterSliders.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
