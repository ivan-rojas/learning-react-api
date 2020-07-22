using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningReactAPI.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
