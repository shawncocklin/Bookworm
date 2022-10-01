using Bookworm.DataAccess.Repository.IRepository;
using Bookworm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDBContext _dBContext;

        public CategoryRepository(AppDBContext db) : base(db)
        {
            _dBContext = db;
        }

        public void Update(Category obj)
        {
            _dBContext.Categories.Update(obj);
        }
    }
}
