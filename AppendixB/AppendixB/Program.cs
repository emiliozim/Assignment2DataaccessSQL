using Microsoft.Data.SqlClient;
using System;

namespace AppendixB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Build connection string (CHANGE TO YOUR INSTANCE)
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ND-5CG9030M69\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;

            // Connect to the SQLServer instance
            Console.Write("Connecting to SQL Server ... ");


            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                
                Console.WriteLine("Done");
                string sql = "SELECT * FROM Customer";
                string sql2 = "UPDATE Customer SET LastName = @newLastName WHERE CustomerId = @CustomerId";
                int CustoerId2 = 1;
                string lastName = "Joe";
                using (SqlCommand command = new SqlCommand(sql2, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@newLastName", lastName);
                        command.Parameters.AddWithValue("@CustomerId", CustoerId2);

                        command.ExecuteNonQuery();


                    }
                    catch (Exception e)
                    {

                    }

                }
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)}");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(7)} {reader.GetString(8)} {reader.GetString(9)} {reader.GetString(11)}");
                            }
                        }
                        catch (Exception e)
                        {
                            
                        }
                    }
                }
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
}
