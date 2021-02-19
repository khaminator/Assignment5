using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment5Webpage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment5Webpage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Add the repository from the DB to the controller and pass into controller.
        private iBookRepository _repository;

        public HomeController(ILogger<HomeController> logger, iBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //INDEX VIEW, Insert the data from the DB.
        public IActionResult Index()
        {
            return View(_repository.Booklists);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}