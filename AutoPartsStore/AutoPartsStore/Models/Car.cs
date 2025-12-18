using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPartsStore.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        // Thêm dòng này để lưu link ảnh
        public string? ImageUrl { get; set; }

        [Required]
        public int CarModelId { get; set; }

        [ForeignKey(nameof(CarModelId))]
        public CarModel CarModel { get; set; } = null!;
    }
}