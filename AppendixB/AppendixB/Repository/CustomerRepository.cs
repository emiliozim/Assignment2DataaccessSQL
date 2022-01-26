using AppendixB.Model;
using AppendixB.SqlHelper;
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
            Customer currentCustomer = new Customer();

            string sql = $"SELECT * FROM Customer WHERE CustomerId = {customerId}";
            try
            {

                using (SqlConnection conn = new SqlConnection(DbConnect.GetDbConnect()))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("CustomerId", customerId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                currentCustomer.CustomerId = reader.GetInt32(0);
                                currentCustomer.FirstName = reader.GetString(1);
                                currentCustomer.LastName = reader.GetString(2);
                                currentCustomer.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                currentCustomer.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                currentCustomer.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                currentCustomer.Email = reader.IsDBNull(6) ? "Null" : reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return currentCustomer;
        }

        public Customer GetCustomerByName(string name)
        {
            Customer currentCustomer = new Customer();

            string sql = $"SELECT * FROM Customer WHERE FirstName Like '{name}'";
            try
            {

                using (SqlConnection conn = new SqlConnection(DbConnect.GetDbConnect()))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("FirstName", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                currentCustomer.CustomerId = reader.GetInt32(0);
                                currentCustomer.FirstName = reader.GetString(1);
                                currentCustomer.LastName = reader.GetString(2);
                                currentCustomer.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                currentCustomer.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                currentCustomer.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                currentCustomer.Email = reader.IsDBNull(6) ? "Null" : reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return currentCustomer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            string sql = "SELECT * FROM Customer";
            List<Customer> customersList = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(DbConnect.GetDbConnect()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                           
                            while (reader.Read())
                            {
                                Customer CurrentCustomer = new Customer();
                                CurrentCustomer.CustomerId = reader.GetInt32(0);
                                CurrentCustomer.FirstName = reader.GetString(1);
                                CurrentCustomer.LastName = reader.GetString(2);
                                CurrentCustomer.Country = reader.IsDBNull(3) ? "Null" : reader.GetString(3);
                                CurrentCustomer.PostalCode = reader.IsDBNull(4) ? "Null" : reader.GetString(4);
                                CurrentCustomer.Phone = reader.IsDBNull(5) ? "Null" : reader.GetString(5);
                                CurrentCustomer.Email = reader.IsDBNull(6) ? "Null" : reader.GetString(6);
                                customersList.Add(CurrentCustomer);
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }

            }
            return customersList;
        }

        public bool InsertCustomer(Customer customer)
        {
            string sql2 = "INSERT INTO Customer( FirstName," +
                    " LastName," +
                    " Company," +
                    " Address," +
                    " City," +
                    " State," +
                    " Country," +
                    " PostalCode," +
                    " Phone," +
                    " Fax," +
                    " Email)" +
                    " VALUES (@newFirstName, @newLastName,  @newCompany, @newAddress, @newCity, @newState, @newCountry, @newPostalCode, @newPhone, @newFax,  @newEmail)";
            using (SqlConnection connection = new SqlConnection(DbConnect.GetDbConnect()))
            {
                connection.Open();
    
                using (SqlCommand command = new SqlCommand(sql2, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@newFirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@newLastName", customer.LastName);
                        command.Parameters.AddWithValue("@newCompany", customer.Company);
                        command.Parameters.AddWithValue("@newAddress", customer.Address);
                        command.Parameters.AddWithValue("@newCity", customer.City);
                        command.Parameters.AddWithValue("@newState", customer.State);
                        command.Parameters.AddWithValue("@newCountry", customer.Country);
                        command.Parameters.AddWithValue("@newPostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@newPhone", customer.Phone);
                        command.Parameters.AddWithValue("@newFax", customer.Fax);
                        command.Parameters.AddWithValue("@newEmail", customer.Email);
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);

                        command.ExecuteNonQuery();
                        return true;

                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                }
            }

        }
    

        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(DbConnect.GetDbConnect())) 
            {
                connection.Open();  
                string sql2 = "UPDATE Customer SET FirstName = @newFirstName," +
                    " LastName = @newLastName," +
                    " Company = @newCompany," +
                    " Address = @newAddress, " +
                    " City = @newCity, " +
                    " State = @newState, " +
                    " Country =@newCountry, " +
                    " PostalCode = @newPostalCode, " +
                    " Phone = @newPhone, " +
                    " Fax = @newFax, " +
                    " Email = @newEmail" +
                    " WHERE CustomerId = @CustomerId";
                
                using (SqlCommand command = new SqlCommand(sql2, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@newFirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@newLastName", customer.LastName);
                        command.Parameters.AddWithValue("@newCompany", customer.Company);
                        command.Parameters.AddWithValue("@newAddress", customer.Address);
                        command.Parameters.AddWithValue("@newCity", customer.City);
                        command.Parameters.AddWithValue("@newState", customer.State);
                        command.Parameters.AddWithValue("@newCountry", customer.Country);
                        command.Parameters.AddWithValue("@newPostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@newPhone", customer.Phone);
                        command.Parameters.AddWithValue("@newFax", customer.Fax);
                        command.Parameters.AddWithValue("@newEmail", customer.Email);
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);

                        command.ExecuteNonQuery();
                        return true;

                    }
                    catch (Exception e)
                    {
                        return false;   
                    }

                }
            }

        }
    }
}
