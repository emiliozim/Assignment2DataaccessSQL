using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixB.Connection
{
    public class DbConnection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
