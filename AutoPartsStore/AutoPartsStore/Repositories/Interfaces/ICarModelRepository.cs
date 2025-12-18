using AutoPartsStore.Models;
using AutoPartsStore.Models.ViewModels; // Nhớ using cái này

namespace AutoPartsStore.Repositories.Interfaces
{
    public interface ICarModelRepository
    {
        List<CarModelVm> GetAll(); // Trả về ViewModel
        CarModel? GetById(int id);
        void Add(CarModel carModel);
        void Update(CarModel carModel);
        void Delete(int id);
    }
}