using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "N-SE-01-1694\\SQLEXPRESS";

            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
            
        }
    }
}
