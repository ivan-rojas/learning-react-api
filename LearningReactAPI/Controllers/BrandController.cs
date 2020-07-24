using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningReactAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        #region Attributes and constructors
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        #endregion

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var brandList = this.brandService.GetAll();
                return Ok(brandList);
            }
            catch (ApplicationException exception)
            {
                return StatusCode(405, exception.Message);
            }
        }
    }
}
