using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPartsStore.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }

        public Brand Brand { get; set; } = null!;

        
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}