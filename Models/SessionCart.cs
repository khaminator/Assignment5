using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Assignment5Webpage.Infrastructure;

namespace Assignment5Webpage.Models
{
    public class SessionCart : Cart 
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;

        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Booklist booklist, int qty)
        {
            base.AddItem(booklist, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Booklist booklist)
        {
            base.RemoveLine(booklist);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }

}