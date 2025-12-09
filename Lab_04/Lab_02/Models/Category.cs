using System.ComponentModel.DataAnnotations;

namespace Lab_02.Models // Đảm bảo namespace là Lab_02
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [StringLength(50)]
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}