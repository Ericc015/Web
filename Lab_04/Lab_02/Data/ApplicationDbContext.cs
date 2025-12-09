using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab_02.Models;

namespace Lab_02.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        // Thêm 3 dòng này:
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
    }
}