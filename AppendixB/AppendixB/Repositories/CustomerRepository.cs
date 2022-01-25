using AppendixB.Connection;
using AppendixB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Repositories
{
    public class CustomerRepository : ICustomerRepository   
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName,LastName, Country,PostalCode,Phone,Email FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return custList;

        }
        public Customer GetCustomerById(int id)
        {
            Customer temp = new Customer();
          
            string sql = $"SELECT CustomerId, FirstName,LastName, Country,PostalCode,Phone,Email FROM Customer WHERE CustomerId = {id}";
            try
            {
             
                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("CustomerId", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return temp;
        }


        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> custList = new List<Customer>();

            string sql = $"SELECT CustomerId, FirstName,LastName, Country,PostalCode,Phone,Email FROM Customer WHERE FirstName LIKE '{name}'";
            try
            {
               
                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);

            }
            return custList;
        }
        public List<Customer> GetAllCustomersWithLimitAndOffset(int  limit, int offset)
        {
            List<Customer> custtList = new List<Customer>();
      
            string sql = $"SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer ORDER BY CustomerId OFFSET { offset} ROWS FETCH NEXT { limit}  ROWS ONLY";

            try
            {
         
                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("LIMIT", limit);
                        cmd.Parameters.AddWithValue("OFFSET", offset);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                custtList.Add(temp);

                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return custtList;
        }

    }
}
