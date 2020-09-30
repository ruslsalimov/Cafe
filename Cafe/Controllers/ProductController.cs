using System.Collections.Generic;
using Cafe.Data.Models.Models.Products;
using Cafe.Data.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    // [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
            =>  _productRepository.GetAll();

        public ViewResult Create() 
            => View("Edit", new Product());

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                _productRepository.Commit();
                TempData["message"] = $"{product.Name} добавлен";
                return RedirectToAction("Catalog", "Home");
            }
            else
            {
                return View("Edit", product);
            }
        }
        
        public ViewResult Edit(int id) 
            => View(_productRepository.GetById(id));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                _productRepository.Commit();
                TempData["message"] = $"{product.Name} обновлено";
                return RedirectToAction("Catalog", "Home");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product product = _productRepository.GetById(id);

            if (product != null)
            {
                _productRepository.Delete(product);
                _productRepository.Commit();
                TempData["message"] = $"{product.Name} удален";
            }
            else
            {
                TempData["message"] = $"Продукт с id = {id.ToString()} отсутствует";
            }
            
            return RedirectToAction("Catalog", "Home");
        }
    }
}