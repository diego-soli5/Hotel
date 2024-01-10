using Hotel.Entities;

namespace Hotel.DataAccess.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Base
    {
        TEntity GetById(int id, string includeProperties = null);
        IEnumerable<TEntity> GetAll(string includeProperties = null);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
