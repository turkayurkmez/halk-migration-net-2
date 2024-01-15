using ChangingInRazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChangingInRazor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 1)
        {
            var products = new ProductService().GetProducts();
            IndexViewModel model = new IndexViewModel
            {
                Products = products,
                PageInfoModel = new PageInfoModel
                {
                    ItemsPerPage = 4,
                    TotalItemsCount = products.Count,
                    ActivePage = page
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}