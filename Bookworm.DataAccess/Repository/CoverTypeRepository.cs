using Bookworm.DataAccess.Repository.IRepository;
using Bookworm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.DataAccess.Repository
{
    internal class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private AppDBContext _dbContext;

        public CoverTypeRepository(AppDBContext db) : base(db)
        {
            _dbContext = db;
        }

        public void Update(CoverType obj)
        {
            _dbContext.CoverTypes.Update(obj);
        }
    }
}
