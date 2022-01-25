using AppendixB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public List<Customer> GetCustomerByName(string name);
        public List<Customer> GetAllCustomersWithLimitAndOffset(int limit, int offset);
    }
}
