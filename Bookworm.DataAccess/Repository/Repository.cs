using Bookworm.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.DataAccess.Repository
{
    // implements the generic methods defined in the interface
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(AppDBContext db)
        {
            _dbContext = db;
            _dbContext.Products.Include(item => item.Category).Include(item => item.CoverType);
            this.dbSet = _dbContext.Set<T>();
        }
        
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                foreach(var props in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(props);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // finds the instance of the dbset that matches the filter condition
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var props in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(props);
                }
            }
            // returns the instance as type of the entity passed in
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
