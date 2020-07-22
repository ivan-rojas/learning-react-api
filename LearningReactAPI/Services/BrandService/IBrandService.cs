using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public interface IBrandService
    {
        public List<Brand> GetAll();
    }
}
