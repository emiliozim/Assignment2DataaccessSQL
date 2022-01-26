using AppendixB.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {

        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICustomerRepository> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public bool InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
