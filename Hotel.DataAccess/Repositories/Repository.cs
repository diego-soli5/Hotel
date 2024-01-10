using Hotel.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using Hotel.Entities;

namespace Hotel.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        protected readonly DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(string propertiesToInclude = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (propertiesToInclude != null)
            {
                foreach (var prop in propertiesToInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return query.Where(t => t.TbEstado)
                        .AsEnumerable(); 
        }

        public TEntity GetById(int id, string propertiesToInclude = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (propertiesToInclude != null)
            {
                foreach (var prop in propertiesToInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return query.Where(t => t.TbEstado)
                        .FirstOrDefault(x => x.Id == id); 
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
