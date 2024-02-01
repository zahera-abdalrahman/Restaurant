using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {

        public MasterPartnerRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, MasterPartner entity)
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
            Db.MasterPartners.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            Db.MasterPartners.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.MasterPartners.Update(data);
            Db.SaveChanges();
          
        }

        public MasterPartner Find(int Id)
        {
            var data = Db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterPartner entity)
        {
           
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
           return Db.MasterPartners.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return Db.MasterPartners.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
