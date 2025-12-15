using Microsoft.EntityFrameworkCore;
using WebAPI.Models; // Đảm bảo dòng này đúng với tên Project của bạn

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký Database In-Memory
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Giữ lại Swagger để bạn dễ test
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- ĐỊNH NGHĨA CÁC API TODO ---

app.MapGet("/", () => "Hello World! Todo API is running.");

// GET: Lấy danh sách (Trả về DTO -> Ẩn field Secret)
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.Select(x => new TodoItemDTO(x)).ToListAsync());

// GET: Lấy chi tiết theo ID
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(new TodoItemDTO(todo))
            : Results.NotFound());

// POST: Tạo mới (Nhận DTO -> Lưu vào DB -> Trả về DTO)
app.MapPost("/todoitems", async (TodoItemDTO todoItemDTO, TodoDb db) =>
{
    // Chuyển từ DTO sang Entity (chưa có Secret)
    var todoItem = new Todo
    {
        IsComplete = todoItemDTO.IsComplete,
        Name = todoItemDTO.Name
    };

    db.Todos.Add(todoItem);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todoItem.Id}", new TodoItemDTO(todoItem));
});

// PUT: Cập nhật công việc
app.MapPut("/todoitems/{id}", async (int id, TodoItemDTO todoItemDTO, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = todoItemDTO.Name;
    todo.IsComplete = todoItemDTO.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// DELETE: Xóa công việc
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(new TodoItemDTO(todo));
    }

    return Results.NotFound();
});

app.Run();