using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SteveBookStore.Infrastructure;
using SteveBookStore.Models;

namespace SteveBookStore.Pages
{
    public class CartModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public CartModel (IBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(b => b.BookId == bookId);


            basket.AddItem(b, 1);



            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(b => b.Books.BookId == bookId).Books);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
