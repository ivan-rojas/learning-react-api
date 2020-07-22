using LearningReactAPI.Data;
using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public class ProductService : IProductService
    {
        #region Attributes and constructors
        private readonly LearningReactDbContext db;

        public ProductService(LearningReactDbContext db)
        {
            this.db = db;
        }
        #endregion

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return this.db.Products.ToList();
        }

        public void Remove(int productId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
