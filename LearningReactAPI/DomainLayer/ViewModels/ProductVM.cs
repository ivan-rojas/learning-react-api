using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.DomainLayer.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }

    }
}
