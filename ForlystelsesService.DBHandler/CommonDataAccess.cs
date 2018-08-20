using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ForlystelsesService.DBHandler
{
    /// <summary>
    /// Contains methods for executing queries and non-queries alike. Queries are recieved from DataAccess class.
    /// </summary>
    public abstract class CommonDataAccess
    {
        /// <summary>
        /// Contains the string to establish a connection to the database. Encapsulated in the protected execute methods
        /// </summary>
        private string connectionString;
        /// <summary>
        /// Constructer recieving the database's connection string as a parameter
        /// </summary>
        /// <param name="connectionString"></param>
        public CommonDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// A method for inserting or updating data in the database
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Returns number of rows affected</returns>
        protected int ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }
        /// <summary>
        /// A method for retrieving data from the database
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Returns the data as a DataSet</returns>
        protected DataSet ExecuteQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
            }
        }
    }
}
