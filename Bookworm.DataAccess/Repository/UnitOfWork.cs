using Bookworm.DataAccess.Repository.IRepository;
using Bookworm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDBContext _dbContext;

        public UnitOfWork(AppDBContext db)
        {
            _dbContext = db;
            Category = new CategoryRepository(_dbContext);
            CoverType = new CoverTypeRepository(_dbContext);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
