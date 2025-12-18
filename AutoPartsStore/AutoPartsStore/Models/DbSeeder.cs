using AutoPartsStore.Models;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        // Kiểm tra nếu chưa có Brand thì mới tạo
        if (!context.Brands.Any())
        {
            var toyota = new Brand { Name = "Toyota", Country = "Japan" };
            var hyundai = new Brand { Name = "Hyundai", Country = "Korea" };

            context.Brands.AddRange(toyota, hyundai);
            context.SaveChanges();

            var vios = new CarModel { Name = "Vios", BrandId = toyota.Id };
            var camry = new CarModel { Name = "Camry", BrandId = toyota.Id };
            var accent = new CarModel { Name = "Accent", BrandId = hyundai.Id };

            context.CarModels.AddRange(vios, camry, accent);
            context.SaveChanges();

            // --- CẬP NHẬT: Thêm xe có link ảnh ---
            context.Cars.AddRange(
                new Car
                {
                    Name = "Vios E CVT",
                    CarModelId = vios.Id,
                    // Link ảnh Toyota Vios
                    ImageUrl = "https://toyota-trungtam.vn/upload/product/vios-e-cvt/vios-e-cvt-2021.png"
                },
                new Car
                {
                    Name = "Camry 2.5Q",
                    CarModelId = camry.Id,
                    // Link ảnh Toyota Camry
                    ImageUrl = "https://toyota-trungtam.vn/upload/product/camry-2.5q/camry-2-5q-2022.png"
                },
                new Car
                {
                    Name = "Accent AT",
                    CarModelId = accent.Id,
                    // Link ảnh Hyundai Accent
                    ImageUrl = "https://hyundaialo.com/wp-content/uploads/2021/03/accent-2021-trang.png"
                }
            );
            context.SaveChanges();
        }
    }
}