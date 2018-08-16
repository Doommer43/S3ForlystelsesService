using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ride
    {
        private int id;
        private string name;
        private string category;
        private string status;
        private List<Report> reports = new List<Report>();

        public Ride(string name, string catagory, string status)
        {
            this.name = name;
            this.category = catagory;
            this.status = status;
        }

        public Ride(int id, string name, string catagory, string status)
        {
            this.id = id;
            this.name = name;
            this.category = catagory;
            this.status = status;
        }
        #region Fields
        public List<Report> Reports
        {
            get { return reports; }
            set { reports = value; }
        }


        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public string Category
        {
            get { return category; }
            set { category = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        public int NumberOfShutdowns()
        {
            throw new NotImplementedException();
        }

        public int DaysSinceLastShutdown()
        {
            throw new NotImplementedException();
        }
    }
}
