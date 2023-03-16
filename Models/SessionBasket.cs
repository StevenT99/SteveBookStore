using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SteveBookStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// This is the new page set up for mission 11 to control the session. 
// Remember to search each term to know what it does
namespace SteveBookStore.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Books proj, int qty)
        {
            base.AddItem(proj, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Books proj)
        {
            base.RemoveItem(proj);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
