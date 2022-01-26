using AppendixB.Model;
using AppendixB.Repository;
using AppendixB.SqlHelper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendixB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //// Build connection string (CHANGE TO YOUR INSTANCE)
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = "ND-5CG9030M69\\SQLEXPRESS";
            //builder.InitialCatalog = "Chinook";
            //builder.IntegratedSecurity = true;

            //// Connect to the SQLServer instance
            //Console.Write("Connecting to SQL Server ... ");
            Customer newCustomer = new Customer()
            {
               
                FirstName = "nn",
                LastName = "dd",
                Company = "VG",
                Address = "1234",
                City = "1234",
                State = "1234",
                Country = "1234",
                PostalCode = "1234",
                Phone = "1234",
                Fax = "1234",
                Email = "joe1@gmail.com"
            };

            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.InsertCustomer(newCustomer);
            //customerRepository.UpdateCustomer(newCustomer);
            //Customer idCust = customerRepository.GetCustomerById(1);
            
            List<Customer> list = (List<Customer>)customerRepository.GetCustomers();
            foreach (Customer customer in list) 
            {
            //    Console.WriteLine(customer.FirstName);    
            //}


            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            try
            //            {
            //                Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)}");
            //                while (reader.Read())
            //                {
            //                    Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(7)} {reader.GetString(8)} {reader.GetString(9)} {reader.GetString(11)}");
            //                }
            //            }
            //            catch (Exception e)
            //            {

            //            }
            //        }
            //    }

            //using (SqlConnection connection = new SqlConnection(DbConnect.GetDbConnect()))
            //{
            //    connection.Open();

            //    Console.WriteLine("Done");
            //    string sql = "SELECT * FROM Customer";
            //    string sql2 = "UPDATE Customer SET LastName = @newLastName, FirstName = @newFirstName WHERE CustomerId = @CustomerId";
            //    int custoerId2 = 1;
            //    string lastName = "lock";
            //    string firstName = "Joe";
            //    using (SqlCommand command = new SqlCommand(sql2, connection))
            //    {

            //        try
            //        {
            //            command.Parameters.AddWithValue("@newLastName", lastName);
            //            command.Parameters.AddWithValue("@newFirstName", firstName);
            //            command.Parameters.AddWithValue("@CustomerId", custoerId2);

            //            command.ExecuteNonQuery();


            //        }
            //        catch (Exception e)
            //        {

            //        }

            //    }
            //    using (SqlCommand command = new SqlCommand(sql, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            try
            //            {
            //                Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)}");
            //                while (reader.Read())
            //                {
            //                    Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(7)} {reader.GetString(8)} {reader.GetString(9)} {reader.GetString(11)}");
            //                }
            //            }
            //            catch (Exception e)
            //            {

            //            }
            //        }
            //    }
            //string sql1 = "SELECT FROM Customer WHERE ID = @CustomerID";
            //int CustoerId = 1;
            //using (SqlCommand command = new SqlCommand(sql1, connection))
            //{
            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        try 
            //        {

            //              //  Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(7)} {reader.GetString(8)} {reader.GetString(9)} {reader.GetString(11)}");



            //        }
            //        catch (Exception e)
            //        {

            //        }
            //    }
            //}





        }
       
    }
}
