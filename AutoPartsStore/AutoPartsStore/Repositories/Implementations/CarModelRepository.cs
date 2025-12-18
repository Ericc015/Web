using Microsoft.EntityFrameworkCore; 
using AutoPartsStore.Models;
using AutoPartsStore.Models.ViewModels;
using AutoPartsStore.Repositories.Interfaces;

namespace AutoPartsStore.Repositories.Implementations
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public List<CarModelVm> GetAll()
        {
            return _context.CarModels
                .Include(cm => cm.Brand) 
                .Select(cm => new CarModelVm
                {
                    Id = cm.Id,
                    CarModelName = cm.Name,
                    BrandId = cm.BrandId,
                    BrandName = cm.Brand.Name
                })
                .ToList();
        }

        public CarModel? GetById(int id)
        {
            return _context.CarModels.Find(id);
        }

        public void Add(CarModel carModel)
        {
            _context.CarModels.Add(carModel);
            _context.SaveChanges();
        }

        public void Update(CarModel carModel)
        {
            _context.CarModels.Update(carModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var carModel = _context.CarModels.Find(id);
            if (carModel != null)
            {
                _context.CarModels.Remove(carModel);
                _context.SaveChanges();
            }
        }
    }
}