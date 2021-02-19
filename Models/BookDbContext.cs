using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment5Webpage.Models
{
    public class BookDbContext : DbContext // : means it inherits
    {
        //Create a Constructor
        public BookDbContext(DbContextOptions<BookDbContext> options) : base (options)
        {

        }

        public DbSet<Booklist> Booklists { get; set; }//the object type (or name) you created with attributes
    }
}
