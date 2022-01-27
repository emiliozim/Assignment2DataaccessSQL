using Microsoft.Data.SqlClient;
using System;


namespace AppendixB.Connection
{
    /// <summary>
    /// A helper class for connecting to the database
    /// </summary>
    public class DbConnection
    {
        /// <summary>
        /// Creates a Connection String for connecting to the database
        /// </summary>
        /// <returns>The Connection String</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "DESKTOP-C6KBH7L\\SQLEXPRESS";

            Builder.InitialCatalog = "Chinook";
            Builder.IntegratedSecurity = true;
            return Builder.ConnectionString;
            
        }
    }
}
