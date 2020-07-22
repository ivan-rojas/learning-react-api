using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Domain.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public BrandVM Brand { get; set; }
    }
}
