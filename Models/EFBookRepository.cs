using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment5Webpage.Models
{
    public class EFBookRepository : iBookRepository
    {

        private BookDbContext _context;

        //Constructor
        public EFBookRepository (BookDbContext context)
        {
            _context = context;
        }


        public IQueryable<Booklist> Booklists => _context.Booklists;
        
    }
}
