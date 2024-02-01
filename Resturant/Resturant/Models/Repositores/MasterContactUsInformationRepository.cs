using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {


        public MasterContactUsInformationRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }


        public void Active(int Id, MasterContactUsInformation entity)
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
            Db.MasterContactUsInformations.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterContactUsInformation entity)
        {
            entity.IsActive = true;
            Db.MasterContactUsInformations.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId=entity.EditId;
            data.EditDate=DateTime.Now;
            Db.MasterContactUsInformations.Update(data);
            Db.SaveChanges();
        }

        public MasterContactUsInformation Find(int Id)
        {
            var data = Db.MasterContactUsInformations.SingleOrDefault(x=>x.MasterContactUsInformationId==Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, MasterContactUsInformation entity)
        {
           
            Db.MasterContactUsInformations.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return Db.MasterContactUsInformations.Where(x=>x.IsDelete == false).ToList();
        }

        public List<MasterContactUsInformation> ViewClient()
        {
            return Db.MasterContactUsInformations.Where(x=>x.IsActive==true && x.IsDelete==false).ToList();
        }
    }
}
