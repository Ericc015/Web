using AutoPartsStore.Models;
using AutoPartsStore.Models.ViewModels;

namespace AutoPartsStore.Services.Interfaces
{
    public interface ICarModelService
    {
        List<CarModelVm> GetCarModels();
        CarModel? GetCarModelById(int id);
        void CreateCarModel(CarModel carModel);
        void UpdateCarModel(CarModel carModel);
        void DeleteCarModel(int id);
    }
}