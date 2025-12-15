namespace WebAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; } // Field bí mật, sẽ dùng để demo bảo mật sau này
    }
}