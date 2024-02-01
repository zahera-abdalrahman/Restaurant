using System.Collections.Generic;

namespace Resturant.Models.Repositores
{
    public interface IRepository<TEntity>
    {

        List<TEntity> View();

        List<TEntity> ViewClient();
        void Add(TEntity entity);
        void Update(int Id, TEntity entity);
        void Active(int Id, TEntity entity);
        void Delete(int Id, TEntity entity);
        TEntity Find(int Id);
     
    }
}
