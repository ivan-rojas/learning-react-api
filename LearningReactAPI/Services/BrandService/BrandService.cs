using LearningReactAPI.Data;
using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public class BrandService : IBrandService
    {
        #region Attributes and constructors
        private readonly LearningReactDbContext db;

        public BrandService(LearningReactDbContext db)
        {
            this.db = db;
        }
        #endregion

        public List<Brand> GetAll()
        {
            return this.db.Brands.ToList();
        }
    }
}
