using System.Diagnostics;
using Cafe.Data.Models.Models.Products;
using Cafe.Data.Repositories.Abstract;
using Cafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public ViewResult Index() => View();
    
        public ViewResult About() => View();
    
        public ViewResult Menu() => View();
        
        public ViewResult Products() 
            => View(_productRepository.GetAll());
    
        public ViewResult Reviews() => View();

        public ViewResult Catalog()
             => View(_productRepository.GetAll());
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}