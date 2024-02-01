using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {

        public TransactionNewsletterRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, TransactionNewsletter entity)
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
            Db.TransactionNewsletters.Update(data);
            Db.SaveChanges();
        }

        public void Add(TransactionNewsletter entity)
        {
            entity.IsActive = true;
           Db.TransactionNewsletters.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.TransactionNewsletters.Update(data);
            Db.SaveChanges();
        }

        public TransactionNewsletter Find(int Id)
        {
            var data=Db.TransactionNewsletters.SingleOrDefault(x=>x.TransactionNewsletterId==Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
         
            Db.TransactionNewsletters.Update(entity);
            Db.SaveChanges();
        }

        public List<TransactionNewsletter> View()
        {
            return Db.TransactionNewsletters.Where(x=>x.IsDelete == false).ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            return Db.TransactionNewsletters.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
