using AppendixB.Models;
using AppendixB.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AppendixB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            ReadAllCustomers(repository);
            SpecificCustomerById(repository);
            SpecificCustomerByName(repository);
            ReadLimitAndOffset(repository);
            AddNewCustomer(repository);
            UpdateCustomer(repository);
            ReadCustomersByCountry(repository);
            ReadCustomersByInvoice(repository);
            SpecificGenereById(repository);



        }
        /// <summary>
        /// Reads all customers from Chinook Database
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void ReadAllCustomers(ICustomerRepository repository)
        {
            try
            {

                Console.WriteLine(" ---------------------- Display All Customers ------------------------------------------- \n");
                PrintCustomer(repository.GetAllCustomers());
                Console.WriteLine(" ------------------------------------------------------------------------------------------\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Reads A specific Customer by CustomerID from customer tabel
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void SpecificCustomerById(ICustomerRepository repository)
        {
            try
            {
                Console.WriteLine(" ---------------------- Read Specific Customer by ID ------------------------------------- \n");
                PrintCustomer(repository.GetCustomerById(2));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        ///  Reads A specific Customer by Name(firstName)
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void SpecificCustomerByName(ICustomerRepository repository)
        {
            try
            {
                Console.WriteLine(" ---------------------- Read Specific Customer by Name ----------------------------------- \n");
                PrintCustomer(repository.GetCustomerByName("Marc"));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Reads customer limit and offset
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        static void ReadLimitAndOffset(ICustomerRepository repository)
        {
            try
            {
                Console.WriteLine(" -------------------- Gets Customers with Limit And Offset -------------------------------- \n");
                PrintCustomer(repository.GetAllCustomersWithLimitAndOffset(3, 5));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Adds a New customer into the database
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void AddNewCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                FirstName = "Jaber",
                LastName = "Ali",
                Country = "Sweden",
                PostalCode = "82880",
                Phone = "+46782584588",
                Email = "Ali@gmail.com"
            };
            try
            {
                if (repository.CreateNewCustomer(customer))
                {
                    Console.WriteLine(" -------------------- New Customer Added --------------------------------------------- \n");
                    Console.WriteLine("Success");

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Updates a customer
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void UpdateCustomer(ICustomerRepository repository)
        {

            Customer customer = new Customer()
            {
                CustomerId = 63,
                FirstName = "Emilio",
                LastName = "Em",
                Country = "Norway",
                PostalCode = "35248",
                Phone = "+4670524562",
                Email = "Emilio@gmail.com"
            };
            try
            {
                if (repository.UpdateCustomer(customer))
                {
                    Console.WriteLine(" -------------------- A Customer has been Updated -------------------------------------- \n");
                    Console.WriteLine("Customer Updated");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Reads the amount of customers in countries and orders them from high to low
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void ReadCustomersByCountry(ICustomerRepository repository)
        {
            try
            {
                List<CustomerCountry> numbers = repository.GetCustomersByCountry();
                Console.WriteLine(" -------------------- Customers Order By Country from High To Low ---------------------------- \n");
                foreach (CustomerCountry customerObj in numbers)
                {
                    var order = string.Format("|{0,5} |{1,5} | ", customerObj.CountryName, customerObj.Quantity);
                    Console.WriteLine(order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Reads customers total spender from high to low
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void ReadCustomersByInvoice(ICustomerRepository repository)
        {
            try
            {
                List<CustomerSpender> numbers = repository.GetCustomersByHighestSpenders();
                Console.WriteLine(" -------------------- Customers Order By Biggest Spender from High To Low ---------------------------- \n");
                foreach (CustomerSpender customerObj in numbers)
                {
                    var order = string.Format("|{0,5} |{1,5} |{2,5} | ", customerObj.TotalSpender, customerObj.FirstName, customerObj.LastName);
                    Console.WriteLine(order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Reads a specific customer by customerId and their most popular genre.
        /// </summary>
        /// <param name="repository">ICustomerRepository interface obj</param>
        public static void SpecificGenereById(ICustomerRepository repository)
        {
            try
            {
                Console.WriteLine(" ---------------------- Read Specific Customer most popular genre ------------------------------------- \n");
                var order = string.Format("|{0,5} |{1,5} |{2,5} | ", repository.GetMostPopularGenreByCustomerId(2).FirstName, repository.GetMostPopularGenreByCustomerId(2).LastName, repository.GetMostPopularGenreByCustomerId(2).GenreName);
                Console.WriteLine(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Printer Format
        /// </summary>
        /// <param name="customers">customers obj</param>
        public static void PrintCustomer(ICollection customers)
        {

            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);

            }

        }
        /// <summary>
        /// Printer Format
        /// </summary>
        /// <param name="customers">customers obj</param>

        public static void PrintCustomerLimitAndOffset(ICollection customers)
        {

            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);

            }

        }
        /// <summary>
        /// Printer Format
        /// </summary>
        /// <param name="customer">customers obj</param>
        public static void PrintCustomer(Customer customer)
        {
            var print = string.Format("|{0,5} | {1,5} | {2,5} | {3,5} | {4,5} | {5,5} | {6,5} |", customer.CustomerId, customer.FirstName, customer.LastName, customer.Country, customer.PostalCode, customer.Phone, customer.Email);
            Console.WriteLine(print);
        }

    }
}
