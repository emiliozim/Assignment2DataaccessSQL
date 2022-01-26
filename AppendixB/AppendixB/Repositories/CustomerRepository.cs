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
            return custList;

        }
        public Customer GetCustomerById(int id)
        {
            Customer temp = new Customer();
          
            string sql = $"SELECT CustomerId, FirstName,LastName, Country,PostalCode,Phone,Email FROM Customer WHERE CustomerId = {id}";
           
             
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
            return temp;
        }


        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> custList = new List<Customer>();

            string sql = $"SELECT CustomerId, FirstName,LastName, Country,PostalCode,Phone,Email FROM Customer WHERE FirstName LIKE '{name}'";

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
            return custList;
        }
        public List<Customer> GetAllCustomersWithLimitAndOffset(int  limit, int offset)
        {
            List<Customer> custtList = new List<Customer>();
      
            string sql = $"SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer ORDER BY CustomerId OFFSET { offset} ROWS FETCH NEXT { limit}  ROWS ONLY";
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
            return custtList;
        }

        public bool CreateNewCustomer(Customer customer)
        {
            bool success = false;
            
            string sql = "INSERT INTO Customer(FirstName,LastName,Country,PostalCode,Phone,Email) " + "VALUES(@FirstName,@LastName,@Country,@PostalCode,@Phone,@Email)";

                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            return success;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
         
            string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode,Phone = @Phone,Email = @Email WHERE CustomerId = @CustomerId";

                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }

            return success;
        }
        public List<CustomerCountry> GetCustomersByCountry()
        {
           
            List<CustomerCountry> custList = new List<CustomerCountry>();

            string sql = "SELECT COUNT(Country), Country FROM Customer GROUP BY Country ORDER BY COUNT(Country) DESC";

                using (SqlConnection conn = new SqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                CustomerCountry customerCountryObj = new CustomerCountry();
                                customerCountryObj.CustomerId = reader.GetInt32(0);
                                customerCountryObj.CountryName = reader.GetString(1);
                                custList.Add(customerCountryObj);
                            }
                        }
                    }
                }
            return custList;
        }

    }

}
