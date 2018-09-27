using System.Linq;
using HomeWorkMVC1.Domain.Filters;
using HomeWorkMVC1.Entities.Base.Interfaces;
using HomeWorkMVC1.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkMVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductData _productData;

        public HomeController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Index(int? sectionId, int? brandId)
        {
            //return View();

            var products = _productData.GetProducts(new ProductFilter { BrandId = brandId, SectionId =
                sectionId });
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    Brand = p.Brand != null ? p.Brand.Name : string.Empty
                }).OrderBy(p => p.Order).ToList()
            };
            return View(model);
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}