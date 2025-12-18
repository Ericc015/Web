using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoPartsStore.Models;
using AutoPartsStore.Services.Interfaces;

namespace AutoPartsStore.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;

        public CarModelController(ICarModelService carModelService, IBrandService brandService)
        {
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var data = _carModelService.GetCarModels();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Brands = new SelectList(_brandService.GetAllBrands(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _carModelService.CreateCarModel(carModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Brands = new SelectList(_brandService.GetAllBrands(), "Id", "Name");
            return View(carModel);
        }

        public IActionResult Edit(int id)
        {
            var carModel = _carModelService.GetCarModelById(id);
            if (carModel == null) return NotFound();

            ViewBag.Brands = new SelectList(_brandService.GetAllBrands(), "Id", "Name", carModel.BrandId);
            return View(carModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _carModelService.UpdateCarModel(carModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Brands = new SelectList(_brandService.GetAllBrands(), "Id", "Name", carModel.BrandId);
            return View(carModel);
        }

        public IActionResult Delete(int id)
        {
            _carModelService.DeleteCarModel(id);
            return RedirectToAction(nameof(Index));
        }
    }
}