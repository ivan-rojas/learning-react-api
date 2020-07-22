using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningReactAPI.Data.Models
{
    [Table("Product")]
    public class Product
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("Cost")]
        [Required]
        public float Cost { get; set; }

        [Column("Price")]
        [Required]
        public float Price { get; set; }

        [Column("BrandId")]
        [ForeignKey("Brand")]
        [Required]
        public int BrandId { get; set; }
        
        public Brand Brand { get; set; }
    }
}
