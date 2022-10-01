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
        private AppDBContext _dBContext;

        public UnitOfWork(AppDBContext db)
        {
            _dBContext = db;
            Category = new CategoryRepository(_dBContext);
        }
        public ICategoryRepository Category { get; private set; }

        public void Save()
        {
            _dBContext.SaveChanges();
        }
    }
}
