using LearningReactAPI.Data;
using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearningReactAPI.Domain.ViewModels;

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
            // TODO: Add validation cost-price

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public ProductVM Get(int id)
        {
            var product = this.db.Products.Include(x => x.Brand).FirstOrDefault(x => x.Id == id);
            // TODO: Add validation if it's null
            return new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Price = product.Price,
                Brand = new BrandVM
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                }
            };
        }

        public List<ProductVM> GetAll()
        {
            List<ProductVM> productVmList = new List<ProductVM>();

            var productList = this.db.Products.Include(p => p.Brand).ToList();
            foreach(Product prod in productList)
            {
                ProductVM prodVm = new ProductVM
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Cost = prod.Cost,
                    Price = prod.Price,
                    Brand = new BrandVM
                    {
                        Id = prod.Brand.Id,
                        Name = prod.Brand.Name
                    }
                };

                productVmList.Add(prodVm);
            }

            return productVmList;
        }

        public void Remove(int productId)
        {
            Product product = this.db.Products.Find(productId);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            Product productToUpdate = this.db.Products.Find(id);
            productToUpdate.Name = product.Name;
            productToUpdate.Cost = product.Cost;
            productToUpdate.Price = product.Price;
            productToUpdate.BrandId = product.BrandId;
            this.db.SaveChanges();
        }
    }
}
