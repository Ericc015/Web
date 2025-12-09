using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Lab_02.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100)]
        [Display(Name = "Họ tên khách hàng")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        // Quan hệ: Một khách hàng có thể mua nhiều vé
        public ICollection<Ticket>? Tickets { get; set; }
    }
}