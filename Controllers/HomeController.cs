using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteveBookStore.Models;
using SteveBookStore.Models.ViewModels;
//Home controller, need to control everything from here
namespace SteveBookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;

        public HomeController (IBookStoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category ==Category || Category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = (Category == null ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == Category).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };
         

            return View(x);
        }
    }
}
