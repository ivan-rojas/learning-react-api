using LearningReactAPI.Data;
using LearningReactAPI.Data.Models;
using LearningReactAPI.Domain.ViewModels;
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

        public List<BrandVM> GetAll()
        {
            List<BrandVM> brandVmList = new List<BrandVM>();

            var brandList = this.db.Brands.ToList();
            foreach(var brand in brandList)
            {
                BrandVM brandVm = new BrandVM
                {
                    Id = brand.Id,
                    Name = brand.Name
                };

                brandVmList.Add(brandVm);
            }

            return brandVmList;
        }
    }
}
