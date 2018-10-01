using Microsoft.AspNetCore.Mvc;
using HomeWorkMVC1.Domain.Filters;
using HomeWorkMVC1.Entities.Base.Interfaces;
using HomeWorkMVC1.Infrastructure.Interfaces;

namespace HomeWorkMVC1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductData _productData;

        public HomeController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = _productData.GetProducts(new ProductFilter());
            return View(products);
        }

    }
}