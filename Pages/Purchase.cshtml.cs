using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment5Webpage.Models;
using Assignment5Webpage.Infrastructure;

namespace Assignment5Webpage.Pages
{
    public class PurchaseModel : PageModel // : means inherit
    {
        private iBookRepository repository;

        //Constructor

        public PurchaseModel(iBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;

        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        /*/OLD Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";  //?? means if it's null then x
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        } */

        public IActionResult OnPost(long BookID, string returnUrl)
        {
            Booklist booklist = repository.Booklists.FirstOrDefault(b => b.BookID == BookID);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(booklist, 1);

            //HttpContext.Session.SetJson("cart", Cart);
                
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long BookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Booklist.BookID == BookID).Booklist);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
