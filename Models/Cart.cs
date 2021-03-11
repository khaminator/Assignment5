using System;
using System.Collections.Generic;
using System.Linq;

//Session state can only hold integers, strings, and bytes.

namespace Assignment5Webpage.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Booklist booklist, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Booklist.BookID == booklist.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Booklist = booklist,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Booklist booklist) =>
            Lines.RemoveAll(i => i.Booklist.BookID == booklist.BookID);

        public double ComputeTotalSum() => Lines.Sum(e => e.Booklist.Price * e.Quantity); //double may need to be decimal

        public virtual void Clear() => Lines.Clear();

    }
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Booklist Booklist { get; set; }
            public int Quantity { get; set; }
        }

    

}
