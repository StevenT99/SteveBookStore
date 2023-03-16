using Microsoft.AspNetCore.Mvc;
using SteveBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteveBookStore.Views.Shared.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        // private basket
        private Basket basket;
        //this is going to be my public vuiew
        public CartSummaryViewComponent(Basket basketService)
        {
            basket = basketService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
