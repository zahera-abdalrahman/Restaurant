using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Models.Repositores
{
    public class CustomerRepository : IRepository<Customer>
    {
        public CustomerRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }
        public void Active(int Id, Customer entity)
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
            Db.Customer.Update(data);
            Db.SaveChanges();
        }

        public void Add(Customer entity)
        {
            entity.IsActive = true;
            Db.Customer.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, Customer entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditId = entity.EditId;
            data.EditDate = DateTime.Now;
            Db.Customer.Update(data);
            Db.SaveChanges();
        }

        public Customer Find(int Id)
        {
            var data = Db.Customer.SingleOrDefault(x => x.CustomerId == Id && x.IsDelete == false);
            return data;
        }

        public void Update(int Id, Customer entity)
        {
            entity.EditDate = DateTime.Now;
            Db.Customer.Update(entity);
            Db.SaveChanges();
        }

        public List<Customer> View()
        {
            return Db.Customer.Where(x => x.IsDelete == false).ToList();
        }

        public List<Customer> ViewClient()
        {
            return Db.Customer.Where(x => x.IsActive == true && x.IsDelete == false).ToList();

        }
    }
}
