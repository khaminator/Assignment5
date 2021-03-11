﻿using System;
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
        public IActionResult Index(string category, int pageNum = 1)
        {
            //Tells program which pages and items to grab.
            return View(new ProjectListViewModel
            {
                //Similar to SQL - doing a query. 
                Booklists = _repository.Booklists
                        .Where(b => category == null || b.Category == category)
                        .OrderBy(b => b.BookID)
                        .Skip((pageNum - 1) * ItemsPerPage)
                        .Take(ItemsPerPage)
                    ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = ItemsPerPage, //maybe change name to PageAmt to differentiate
                    TotalNumItems = category == null ?  _repository.Booklists.Count() :
                        _repository.Booklists.Where(b => b.Category == category).Count()

                },

                CurrentCategory = category
              


            });
               
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}