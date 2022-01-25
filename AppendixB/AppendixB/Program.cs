using AppendixB.Models;
using AppendixB.Repositories;
using System;
using System.Collections;

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
        }
        public static void ReadAllCustomers(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetAllCustomers());
            Console.WriteLine(" ------------------------------------------------------------------------------------------\n");
          
        }
        public static void SpecificCustomerById(ICustomerRepository repository)
        {
            Console.WriteLine(" ---------------------- Read Specific Customer by ID ------------------------------------- \n");
            PrintCustomer(repository.GetCustomerById(2));
            Console.WriteLine();
        }
        public static void SpecificCustomerByName(ICustomerRepository repository)
        {
            Console.WriteLine(" ---------------------- Read Specific Customer by Name ---------------------------------- \n");
            PrintCustomer(repository.GetCustomerByName("Marc"));
            Console.WriteLine();
        }
        static void ReadLimitAndOffset(ICustomerRepository repository)
        {
            Console.WriteLine(" -------------------- Gets Customers with Limit And Offset -------------------------------- \n");
            PrintCustomer(repository.GetAllCustomersWithLimitAndOffset(3, 5));
        }



        public static void PrintCustomer(ICollection customers)
        {

            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);

            }
          
        }

        public static void PrintCustomerLimitAndOffset(ICollection customers)
        {

            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);

            }

        }
        public static void PrintCustomer(Customer customer)
        {
            var print = string.Format("|{0,5} | {1,5} | {2,5} | {3,5} | {4,5} | {5,5} | {6,5} |", customer.CustomerId, customer.FirstName, customer.LastName, customer.Country, customer.PostalCode, customer.Phone, customer.Email);
            Console.WriteLine(print);
        }
  
    }
}
