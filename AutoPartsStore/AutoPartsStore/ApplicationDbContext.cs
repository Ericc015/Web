using Microsoft.EntityFrameworkCore;
using AutoPartsStore.Models; // Thay AutoPartsStore bằng tên namespace project của bạn
using AutoPartsStore.Models.ViewModels;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarModel> CarModels { get; set; }

public DbSet<AutoPartsStore.Models.ViewModels.CarModelVm> CarModelVm { get; set; } = default!;
}