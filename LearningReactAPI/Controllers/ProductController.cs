using LearningReactAPI.Data.Models;
using LearningReactAPI.Domain.ViewModels;
using LearningReactAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Attributes and constructors
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        #endregion

        [HttpGet]
        public List<ProductVM> GetAll()
        {
           return this.productService.GetAll();
        }

        [HttpGet("{id}", Name = "Get")]
        public ProductVM Get(int id)
        {
            return this.productService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            this.productService.Add(product);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            this.productService.Update(id, product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.productService.Remove(id);
        }
    }
}
