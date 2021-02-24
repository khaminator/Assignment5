using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Webpage.Models //change the namespace to Assignment5?
{
    public class Booklist

    {
        //PROPERTIES OR MODEL ATTRIBUTES 

        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Please enter Title Field")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Please enter Author's First Name")]
        public string AuthorFirst { get; set; }

        [Required(ErrorMessage = "Please enter Author's Last Name ")]
        public string AuthorLast { get; set; }

        [Required(ErrorMessage = "Please enter Publisher's Name")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please enter ISBN field in this format: XXX-XXXXXXXXX")]
        [RegularExpression(@"^(?=(?:\D*\d){3}(?:(?:\D*\d){10})?$)[\d-]+$", ErrorMessage = "Invalid Format")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

        public int PageNum { get; set;}
           
    }
}
