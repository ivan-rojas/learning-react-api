using LearningReactAPI.Data.Models;
using LearningReactAPI.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public interface IProductService
    {
        public List<ProductVM> GetAll();
        public ProductVM Get(int id);
        public void Add(Product product);
        public void Update(int id, Product product);
        public void Remove(int productId);
    }
}
