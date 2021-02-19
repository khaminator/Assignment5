using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment5Webpage.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //ADD DATA INITIALLY TO DATABASE

            if(!context.Booklists.Any())
            {
                context.Booklists.AddRange(

                    new Booklist
                    {
                        
                        BookTitle = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic ",
                        Price = 9.95,
                    },

                    new Booklist
                    {
                        
                        BookTitle = "Team of Rivals",
                        AuthorFirst = "Doris Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                    },

                     new Booklist
                     {
                        
                         BookTitle = "The Snowball",
                         AuthorFirst = "Alice",
                         AuthorLast = "Schroeder",
                         Publisher = "Bantam",
                         ISBN = "978-0553384611",
                         Classification = "Non-Fiction",
                         Category = "Biography",
                         Price = 21.54,

                     },

                      new Booklist
                      {
                         
                          BookTitle = "American Ulysses",
                          AuthorFirst = "Ronald C.",
                          AuthorLast = "White",
                          Publisher = "Random House",
                          ISBN = "978-0812981254",
                          Classification = "Non-Fiction",
                          Category = "Biography",
                          Price = 11.61,

                      },

                       new Booklist
                       {
                          
                           BookTitle = "Unbroken",
                           AuthorFirst = "Laura",
                           AuthorLast = "Hillenbrand",
                           Publisher = "Random House",
                           ISBN = "978-0812974492",
                           Classification = "Non-Fiction",
                           Category = "Historical",
                           Price = 13.33,

                       },

                       new Booklist
                       {
                           
                           BookTitle = "The Great Train Robbery",
                           AuthorFirst = "Michael",
                           AuthorLast = "Crichton",
                           Publisher = "Vintage",
                           ISBN = "978-0804171281",
                           Classification = "Fiction",
                           Category = "Historical Fiction",
                           Price = 15.95,

                       },

                       new Booklist
                       {
                         
                           BookTitle = "Deep Work",
                           AuthorFirst = "Cal",
                           AuthorLast = "Newport",
                           Publisher = "Grand Central Publishing",
                           ISBN = "978-1455586691",
                           Classification = "Non-Fiction",
                           Category = "Self-Help",
                           Price = 14.99,

                       },

                       new Booklist
                       {
                           
                           BookTitle = "It's Your Ship",
                           AuthorFirst = "Michael",
                           AuthorLast = "Abrashoff",
                           Publisher = "Grand Central Publishing",
                           ISBN = "978-1455523023",
                           Classification = "Non-Fiction",
                           Category = "Self-Help",
                           Price = 21.66,

                       },

                       new Booklist
                       {
                        
                           BookTitle = "The Virgin Way",
                           AuthorFirst = "Richard",
                           AuthorLast = "Branson",
                           Publisher = "Portfolio",
                           ISBN = "978-1591847984",
                           Classification = "Non-Fiction",
                           Category = "Business ",
                           Price = 29.16,

                       },

                       new Booklist
                       {
                         
                           BookTitle = "Sycamore Row",
                           AuthorFirst = "John",
                           AuthorLast = "Grisham",
                           Publisher = "Bantam",
                           ISBN = "978-0553393613",
                           Classification = "Fiction",
                           Category = "Thrillers ",
                           Price = 15.03,

                       }

                    );

                //THIS CAN BE TAKEN OUT AFTER THE DATABASE HAS BEEN SEEDED.
                context.SaveChanges();
            }
            


        }
    }
}

