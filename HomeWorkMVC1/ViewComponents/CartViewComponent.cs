using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkMVC1.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkMVC1.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartservice)
        {
            _cartService = cartservice;
        }

        public IViewComponentResult Invoke()
        {
            var cartView = _cartService.TransformCart();
            return View(cartView);
        }
    }
}
