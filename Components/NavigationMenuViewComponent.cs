using Microsoft.AspNetCore.Mvc;
using System;
using Assignment5Webpage.Models;
using System.Linq;

namespace Assignment5Webpage.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private iBookRepository repository;

        public NavigationMenuViewComponent (iBookRepository repo)
        {
            repository = repo;
        }

       //method of ViewComponent. This is the navigation Component we plug into shared layout
       public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"]; // ? makes it nullable

            return View(repository.Booklists
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }

    }
}

//End of Page