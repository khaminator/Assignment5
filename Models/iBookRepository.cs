using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Webpage.Models
{
    public interface iBookRepository
    {
        IQueryable<Booklist> Booklists { get; }
    }
}
