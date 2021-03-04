using System;
using System.Collections.Generic;

namespace Assignment5Webpage.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Booklist> Booklists { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; } //set in HomeController

            //property can be a variable or an object but it belongs
            //to the method and it's not a function 
    }
}
