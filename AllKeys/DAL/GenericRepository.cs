using AllKeys.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VENTAS_ORM.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal VentasContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(VentasContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);

            context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = dbSet.Where(predicate).ToList();
            entities.ForEach(x => context.Entry(x).State = EntityState.Deleted);
        }

        public void Añadir(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public List<TEntity> GetAll()
        {
            return (List<TEntity>)dbSet.ToList();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            dbSet = context.Set<TEntity>();
            return dbSet.FirstOrDefault(predicate);
        }

    }
}
