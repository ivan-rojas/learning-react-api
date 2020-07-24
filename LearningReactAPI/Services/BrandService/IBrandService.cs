using LearningReactAPI.Domain.ViewModels;
using System.Collections.Generic;

namespace LearningReactAPI.Services
{
    public interface IBrandService
    {
        public List<BrandVM> GetAll();
    }
}
