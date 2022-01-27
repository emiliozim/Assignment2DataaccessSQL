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
    /// <inheritdoc />
    public class CustomerRepository : ICustomerRepository   
    {
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public List<CustomerCountry> GetCustomersByCountry()
        {
           
            List<CustomerCountry> custList = new List<CustomerCountry>();

            string sql = "SELECT COUNT(CustomerId) AS TotalNumber," +
                " Country" +
                " FROM Customer" +
                " GROUP BY Country" +
                " ORDER BY TotalNumber DESC";

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
        /// <inheritdoc/>
        public List<CustomerSpender> GetCustomersByHighestSpenders()
        {

            List<CustomerSpender> custList = new List<CustomerSpender>();

            string sql = "SELECT FirstName," +
                " LastName," +
                "SUM(Total) AS Total" +
                " From Customer c" +
                " JOIN Invoice i ON c.CustomerId = i.CustomerId" +
                " GROUP BY c.FirstName, c.LastName" +
                " ORDER BY Total DESC";
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
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.FirstName = reader.GetString(0);
                                customerSpender.LastName = reader.GetString(1);
                                customerSpender.TotalSpender = reader.GetDecimal(2);
                                custList.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return custList;
        }
        /// <inheritdoc/>
        public CustomerGenre GetMostPopularGenreByCustomerId(int id)
        {
            CustomerGenre temp = new CustomerGenre();

            string sql = $"SELECT TOP 1 WITH TIES " +
                $"c.FirstName, " +
                $"c.LastName," +
                $"g.Name AS Genre," +
                $"COUNT(g.GenreId) AS Total " +
                $"FROM Customer c " +
                $"JOIN Invoice i ON C.CustomerId = i.CustomerId " +
                $"JOIN InvoiceLine il ON i.InvoiceId = il.InvoiceId " +
                $"JOIN Track t ON il.TrackId = t.TrackId " +
                $"JOIN Genre g ON t.GenreId = g.GenreId " +
                $"WHERE c.CustomerId = {id} " +
                $"GROUP BY c.FirstName, " +
                $"c.LastName, " +
                $"g.Name " +
                $"ORDER BY COUNT(g.GenreId) DESC";


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

                            temp.FirstName = reader.GetString(0);
                            temp.LastName = reader.GetString(1);
                            temp.GenreName = reader.GetString(2);
                            
                        }
                    }
                }
            }
            return temp;
        }

    }

}
