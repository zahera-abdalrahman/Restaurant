using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {

        public TransactionContactUsRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, TransactionContactUs entity)
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
            Db.TransactionContactUs.Update(data);
            Db.SaveChanges();
        }

        public void Add(TransactionContactUs entity)
        {
            entity.IsActive = true;
            Db.TransactionContactUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.TransactionContactUs.Update(data);
            Db.SaveChanges();
        }

        public TransactionContactUs Find(int Id)
        {
            var data = Db.TransactionContactUs.SingleOrDefault(x=>x.TransactionContactUsId==Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, TransactionContactUs entity)
        {
          
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public List<TransactionContactUs> View()
        {
            return Db.TransactionContactUs.Where(x=>x.IsDelete == false).ToList();
        }

        public List<TransactionContactUs> ViewClient()
        {
            return Db.TransactionContactUs.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
