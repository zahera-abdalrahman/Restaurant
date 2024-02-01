using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {

        public TransactionBookTableRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, TransactionBookTable entity)
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
            Db.TransactionBookTables.Update(data);
            Db.SaveChanges();
        }

        public void Add(TransactionBookTable entity)
        {
            entity.IsActive = true;
            Db.TransactionBookTables.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.TransactionBookTables.Update(data);
            Db.SaveChanges();
        }

        public TransactionBookTable Find(int Id)
        {
            var data = Db.TransactionBookTables.SingleOrDefault(x=>x.TransactionBookTableId==Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, TransactionBookTable entity)
        {
           
            Db.TransactionBookTables.Update(entity);
            Db.SaveChanges();
        }

        public List<TransactionBookTable> View()
        {
           return Db.TransactionBookTables.Where(x=>x.IsDelete == false).ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
            return Db.TransactionBookTables.Where(x => x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
