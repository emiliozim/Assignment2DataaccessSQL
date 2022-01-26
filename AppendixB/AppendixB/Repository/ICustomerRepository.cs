using AppendixB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Repository
{
    internal interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        bool InsertCustomer (Customer customer);    
        bool UpdateCustomer (Customer customer);
        bool DeleteCustomer (int customerId);
    }
}
