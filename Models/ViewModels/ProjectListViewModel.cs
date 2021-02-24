using System;
using System.Collections.Generic;

namespace Assignment5Webpage.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Booklist> Booklists { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
