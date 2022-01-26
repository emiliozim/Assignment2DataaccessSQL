using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.SqlHelper
{
    internal class DbConnect
    {
        public static string GetDbConnect()
        {
            // Build connection string (CHANGE TO YOUR INSTANCE)
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-C6KBH7L\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }
        

    }
}
