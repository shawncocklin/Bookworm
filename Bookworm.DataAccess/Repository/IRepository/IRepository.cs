using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.DataAccess.Repository.IRepository
{
    // defines generic methods for repositories
    public interface IRepository<T> where T : class
    {
        // runs a lamda expression with the passed in iterable entity,
        // returning the first result that returns true
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        // returns an iterable of the passed in entity
        IEnumerable<T> GetAll(string? includeProperties = null);
        // add passed in entity 
        void Add(T entity);
        // remove passed in entity
        void Remove(T entity);
        // remove multiple entities
        void RemoveRange(IEnumerable<T> entities);
    }
}
