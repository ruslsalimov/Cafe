using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cafe.Data.Models.Models.Products;
using Cafe.Data.Models.Models.Users;
using Cafe.Data.Repositories.Abstract;
using Cafe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private IReviewRepository _reviewRepository;
        private UserManager<User> _userManager;

        public HomeController(
            IProductRepository productRepository,
            IReviewRepository reviewRepository,
            UserManager<User> userManager)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _userManager = userManager;
        }
    
        public ViewResult Index() => View();
    
        public ViewResult About() => View();
    
        public ViewResult Menu() => View();
        
        public ViewResult Products() 
            => View(_productRepository.GetAll());
    
        public ViewResult Reviews() 
            => View(_reviewRepository.GetReviewsWithUser());
        
        [HttpPost]
        public async Task<IActionResult> AddReview(string review)
        {
            if (!string.IsNullOrWhiteSpace(review))
            {
                Review rev = new Review()
                {
                    Text = review,
                    User = await _userManager.GetUserAsync(HttpContext.User)
                };
                _reviewRepository.Add(rev);
                _reviewRepository.Commit();
            }
            
            return RedirectToAction("Reviews");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

    }
}