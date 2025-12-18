using AutoPartsStore.Models;
using AutoPartsStore.Models.ViewModels;
using AutoPartsStore.Repositories.Interfaces;
using AutoPartsStore.Services.Interfaces;

namespace AutoPartsStore.Services.Implementations
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _repository;

        public CarModelService(ICarModelRepository repository)
        {
            _repository = repository;
        }

        public List<CarModelVm> GetCarModels()
        {
            return _repository.GetAll();
        }

        public CarModel? GetCarModelById(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateCarModel(CarModel carModel)
        {
            _repository.Add(carModel);
        }

        public void UpdateCarModel(CarModel carModel)
        {
            _repository.Update(carModel);
        }

        public void DeleteCarModel(int id)
        {
            _repository.Delete(id);
        }
    }
}