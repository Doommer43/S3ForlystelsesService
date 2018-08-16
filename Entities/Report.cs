using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Report
    {
        private int id;
        private Ride ride;
        private string status;
        private DateTime reportTime;
        private string notes;

        public Report(Ride ride, string status, DateTime reportTime, string notes)
        {
            this.ride = ride;
            this.status = status;
            this.reportTime = reportTime;
            this.notes = notes;
        }

        public Report(int id, Ride ride, string status, DateTime reportTime, string notes)
        {
            this.id = id;
            this.ride = ride;
            this.status = status;
            this.reportTime = reportTime;
            this.notes = notes;
        }
        #region Fields
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public DateTime ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }


        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public Ride Ride
        {
            get { return ride; }
            set { ride = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}
