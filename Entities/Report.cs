using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Represent a report
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Field containing the id assigned by the database
        /// </summary>
        private int id;
        /// <summary>
        /// Field containing the report's ride
        /// </summary>
        private Ride ride;
        /// <summary>
        /// Field containing the report's ride's status
        /// </summary>
        private string status;
        /// <summary>
        /// Field containing the datetime the report is created
        /// </summary>
        private DateTime reportTime;
        /// <summary>
        /// Field containing the report's notes
        /// </summary>
        private string notes;
        /// <summary>
        /// Constructor used for creating a new report
        /// </summary>
        /// <param name="ride">nvarchar(50)</param>
        /// <param name="status">nvarchar(50)</param>
        /// <param name="reportTime">nvarchar(50)</param>
        /// <param name="notes">nvarchar(MAX)</param>
        public Report(Ride ride, string status, DateTime reportTime, string notes)
        {
            this.ride = ride;
            this.status = status;
            this.reportTime = reportTime;
            this.notes = notes;
        }
        /// <summary>
        /// Constructor used for creating a report stored in the database
        /// </summary>
        /// <param name="id">Assigned by the database</param>
        /// <param name="ride"></param>
        /// <param name="status"></param>
        /// <param name="reportTime"></param>
        /// <param name="notes"></param>
        public Report(int id, Ride ride, string status, DateTime reportTime, string notes)
        {
            this.id = id;
            this.ride = ride;
            this.status = status;
            this.reportTime = reportTime;
            this.notes = notes;
        }
        #region Properties
        /// <summary>
        /// Property for getting and setting the report' notes
        /// </summary>
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
        /// <summary>
        /// property for getting the datetime
        /// </summary>
        public DateTime ReportTime
        {
            get { return reportTime; }
        }
        /// <summary>
        /// Property for getting and setting the report's status
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Property for getting the report's ride
        /// </summary>
        public Ride Ride
        {
            get { return ride; }
        }
        /// <summary>
        /// Property for getting the report's id
        /// This is assigned be the database and cannot be changed
        /// </summary>
        public int Id
        {
            get { return id; }
        }
        #endregion
    }
}
