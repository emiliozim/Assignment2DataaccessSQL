using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Models
{
    /// <summary>
    /// CustomerSpender class.
    /// </summary>
    public class CustomerSpender
    {
        public decimal TotalSpender { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }  

    }
}
 