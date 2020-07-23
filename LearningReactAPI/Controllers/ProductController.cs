using LearningReactAPI.Data.Models;
using LearningReactAPI.Domain.ViewModels;
using LearningReactAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult GetAll()
        {
            try
            {
                var productList = this.productService.GetAll();
                return Ok(productList);
            }
            catch(ApplicationException exception)
            {
                return StatusCode(405, exception.Message);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            try
            {
                var product = this.productService.Get(id);
                return Ok(product);
            }
            catch(ApplicationException exception)
            {
                return StatusCode(405, exception.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {
                this.productService.Add(product);
                return Ok();
            }
            catch (ApplicationException exception)
            {
                return StatusCode(405, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                product.Id = id;
                this.productService.Update(id, product);
                return Ok();
            }
            catch (ApplicationException exception)
            {
                return StatusCode(405, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.productService.Remove(id);
                return Ok();
            }
            catch (ApplicationException exception)
            {
                return StatusCode(405, exception.Message);
            }
        }
    }
}
