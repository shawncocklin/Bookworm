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
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDBContext _dbContext;

        public ProductRepository(AppDBContext db) : base(db)
        {
            _dbContext = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _dbContext.Products.FirstOrDefault(item => item.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.BulkPrice50 = obj.BulkPrice50;
                objFromDb.BulkPrice100 = obj.BulkPrice100;
                objFromDb.Author = obj.Author;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;

                if(objFromDb.ImgageUrl != null)
                {
                    objFromDb.ImgageUrl = obj.ImgageUrl;
                }

            }
        }
    }
}
