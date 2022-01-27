using AppendixB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Repositories
{
    /// <summary>
    /// Interface for CustomerRepository
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all Customers form the database
        /// </summary>
        /// <returns>A list with all the Customers</returns>
        public List<Customer> GetAllCustomers();
        /// <summary>
        /// Gets a specific customer by id.
        /// </summary>
        /// <param name="id">The customer id</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerById(int id);
        /// <summary>
        /// Gets a specific customer by name.
        /// </summary>
        /// <param name="name">The name of the Customer</param>
        /// <returns>A customer</returns>
        public List<Customer> GetCustomerByName(string name);
        /// <summary>
        /// Gets a page of the customer database, with a starting and ending point.
        /// </summary>
        /// <param name="limit">Starting point</param>
        /// <param name="offset">Ending point</param>
        /// <returns>A list with a part of the Customer database</returns>
        public List<Customer> GetAllCustomersWithLimitAndOffset(int limit, int offset);
        /// <summary>
        /// Creates and adds new customer to the database
        /// </summary>
        /// <param name="customer">A Customer object</param>
        /// <returns>Ture if success else false</returns>
        public bool CreateNewCustomer(Customer customer);
        /// <summary>
        /// Updates ac customer in the database
        /// </summary>
        /// <param name="customer">A Customer object</param>
        /// <returns>Ture if success else false</returns>
        public bool UpdateCustomer(Customer customer);
        /// <summary>
        /// Gets a list containing the number of customer in each country
        /// </summary>
        /// <returns>CustomerCountry list</returns>
        public List<CustomerCountry> GetCustomersByCountry();
        /// <summary>
        /// Gets a list containing the total Spending of all the customer.
        /// </summary>
        /// <returns>CustomerSpender list</returns>
        public List<CustomerSpender> GetCustomersByHighestSpenders();
        /// <summary>
        /// Gets a CustomerGenre whith the most popular genre.
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns>CustomerGenre object</returns>
        public CustomerGenre GetMostPopularGenreByCustomerId(int id);
    }
}
