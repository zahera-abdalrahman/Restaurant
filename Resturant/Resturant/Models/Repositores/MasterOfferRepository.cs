using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {

        public MasterOfferRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterOffer entity)
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
            Db.MasterOffers.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterOffer entity)
        {
           Db.MasterOffers.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterOffers.Update(data);
            Db.SaveChanges();
           
        }

        public MasterOffer Find(int Id)
        {
            var data = Db.MasterOffers.SingleOrDefault(x=>x.MasterOfferId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterOffer entity)
        {
          
            Db.MasterOffers.Update(entity);
           Db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return Db.MasterOffers.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return Db.MasterOffers.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
