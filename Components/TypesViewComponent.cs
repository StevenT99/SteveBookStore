using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteveBookStore.Models;

namespace SteveBookStore.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public TypesViewComponent (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["Category"];
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
