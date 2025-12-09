using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_02.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ngày đặt vé")]
        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Range(1, 100, ErrorMessage = "Số ghế phải từ 1 đến 100")]
        public int SeatNumber { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // Khóa ngoại đến Movie (Bắt buộc: Vé phải thuộc về 1 phim)
        [Required]
        [Display(Name = "Phim")]
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }

        // Khóa ngoại đến Customer (Bắt buộc: Vé phải do 1 khách mua)
        [Required]
        [Display(Name = "Khách hàng")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}