using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product Get();
        public void Add(Product product);
        public void Update(Product product);
        public void Remove(int productId);
    }
}
