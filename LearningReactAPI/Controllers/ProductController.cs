using LearningReactAPI.Data;
using LearningReactAPI.Data.Models;
using LearningReactAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public List<Product> GetAll()
        {
            return this.productService.GetAll();
        }


        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
