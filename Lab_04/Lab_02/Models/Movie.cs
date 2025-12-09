using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_02.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        // --- CÁC THUỘC TÍNH BỊ THIẾU ĐÃ ĐƯỢC KHÔI PHỤC ---

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; } // <<-- KHÔI PHỤC

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } // <<-- KHÔI PHỤC

        // --- CÁC THUỘC TÍNH CỦA LAB 4 & KHÓA NGOẠI ---

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string? Rating { get; set; }

        [Display(Name = "Thể loại chính")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}