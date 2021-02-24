using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; //This is like SQL, used for querying.
using System.Threading.Tasks;
using Assignment5Webpage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment5Webpage.Models.ViewModels;

namespace Assignment5Webpage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Add the repository from the DB to the controller and pass into controller.
        private iBookRepository _repository;

        //Variable to hold the items per page
        public int ItemsPerPage = 5;

        public HomeController(ILogger<HomeController> logger, iBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //INDEX VIEW, Insert the data from the DB.
        public IActionResult Index(int page = 1)
        {
            //Tells program which pages and items to grab.
            return View(new ProjectListViewModel
            {
                Booklists = _repository.Booklists
                        .OrderBy(b => b.BookID)
                        .Skip((page - 1) * ItemsPerPage)
                        .Take(ItemsPerPage)
                    ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = ItemsPerPage, //maybe change name to PageAmt to differentiate
                    TotalNumItems = _repository.Booklists.Count()

                }

            });
               
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}