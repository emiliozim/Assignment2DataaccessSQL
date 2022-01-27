using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Models
{
    /// <summary>
    /// CustomerGenre class.
    /// </summary>
    public class CustomerGenre
    {
        public int GenreId { get; set; }
        public int CustomerId { get; set; }
        public string GenreName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
