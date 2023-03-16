using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteveBookStore.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkouts => context.Checkouts.Include(b => b.Lines).ThenInclude(b => b.Books);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(b => b.Books));

            if (checkout.PurchaseId == 0)
            {
                context.Checkouts.Add(checkout);
            }
            context.SaveChanges();
        }
    }
}
