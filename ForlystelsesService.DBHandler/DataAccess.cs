using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ForlystelsesService.DBHandler
{
    /// <summary>
    /// Regulates all access to the database. Inherits from CommenDataAccess; inheritance
    /// </summary>
    public class DataAccess : CommonDataAccess
    {
        public DataAccess(string conString) : base(conString)
        {

        }
        /// <summary>
        /// Compiles a list of all rides currently in the database
        /// </summary>
        /// <returns>Returns all rides in as a List.Ride item</returns>
        public List<Ride> GetAllRides()
        {
            string query = $"SELECT * FROM Rides";
            List<Ride> rides = new List<Ride>();
            DataSet dataset = ExecuteQuery(query);

            foreach (DataTable table in dataset.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    string name = row.Field<string>("name").ToString();
                    string category = row.Field<string>("category").ToString();
                    string status = row.Field<string>("status").ToString();
                    int id = row.Field<int>("id");
                    Ride ride = new Ride(id, name, category, status);
                    rides.Add(ride);
                }
            }
            return rides;
        }
        /// <summary>
        /// Compiles a list of all reports currently in the database
        /// </summary>
        /// <param name="ride"></param>
        /// <returns>Returns all reports in as a List.Report item</returns>
        public List<Report> GetAllReports(Ride ride)
        {
            string query = $"SELECT * FROM Reports WHERE rideId = {ride.Id}";
            List<Report> reports = new List<Report>();
            DataSet dataset = ExecuteQuery(query);

            foreach (DataTable table in dataset.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    string status = row.Field<string>("status").ToString();
                    DateTime reportTime = row.Field<DateTime>("reportTime");
                    string notes = row.Field<string>("notes").ToString();
                    Report report = new Report(ride, status, reportTime, notes);
                    reports.Add(report);
                }
            }
            return reports;
        }
        /// <summary>
        /// Saves the given ride in the database. This is a polymorphic method
        /// </summary>
        /// <param name="ride"></param>
        /// <returns>Returns number of rows affected</returns>
        public int Save (Ride ride)
        {
            string sqlQuery = $"INSERT INTO Rides (name, category, status) VALUES ('{ride.Name}', '{ride.Category}', '{ride.Status}')";
            int rowsAffected = ExecuteNonQuery(sqlQuery);
            return rowsAffected;
        }
        /// <summary>
        /// Saves the given report in the database. This is a polymorphic method
        /// </summary>
        /// <param name="report"></param>
        /// <returns>Returns number of rows affected</returns>
        public int Save (Report report)
        {
            string sqlQuery = $"INSERT INTO Reports (status, reportTime, notes, rideId) VALUES ('{report.Status}', '{report.ReportTime.ToString("yyyy-MM-dd")}', '{report.Notes}', '{report.Ride.Id}')";
            int rowsAffected = ExecuteNonQuery(sqlQuery);
            return rowsAffected;
        }
        /// <summary>
        /// Updates the status of the given ride
        /// </summary>
        /// <param name="ride"></param>
        /// <returns>Returns number of rows affected</returns>
        public int UpdateStatus (Ride ride)
        {
            string query = $"UPDATE Rides SET status = '{ride.Status}' WHERE id = '{ride.Id}'";
            int rowsAffected = ExecuteNonQuery(query);
            return rowsAffected;
        }
    }
}
