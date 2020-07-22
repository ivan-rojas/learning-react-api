using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningReactAPI.Data.Models
{
    [Table("Brand")]
    public class Brand
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
    }
}
