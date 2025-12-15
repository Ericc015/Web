using WebAPI.Models; // Dùng namespace chứa class Todo gốc

namespace WebAPI.Models // BẮT BUỘC PHẢI CÓ DÒNG NÀY
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoItemDTO() { }

        public TodoItemDTO(Todo todoItem) =>
        (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
    }
}