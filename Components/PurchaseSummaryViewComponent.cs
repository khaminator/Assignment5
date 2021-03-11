using System;
using Microsoft.AspNetCore.Mvc;
using Assignment5Webpage.Models;

namespace Assignment5Webpage.Components
{
    public class PurchaseSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public PurchaseSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
