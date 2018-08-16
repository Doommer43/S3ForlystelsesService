using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ForlystelsesService.DBHandler
{
    public abstract class CommonDataAccess
    {
        private string connectionString;

        public CommonDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected int ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        protected DataSet ExecuteQuery (string sql)
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
