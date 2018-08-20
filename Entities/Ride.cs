using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Represent a ride at the amusementpark
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// The id assigned to the ride in by the database
        /// </summary>
        private int id;
        /// <summary>
        /// The ride's name
        /// </summary>
        private string name;
        /// <summary>
        /// The ride's category
        /// </summary>
        private string category;
        /// <summary>
        /// The ride's current status
        /// </summary>
        private string status;
        /// <summary>
        /// All reports from the database attached to the ride
        /// </summary>
        private List<Report> reports = new List<Report>();
        /// <summary>
        /// A Constructor used for creating new rides
        /// </summary>
        /// <param name="name">name of the ride</param>
        /// <param name="catagory">Category of the ride</param>
        /// <param name="status">Status os the ride</param>
        public Ride(string name, string catagory, string status)
        {
            this.name = name;
            this.category = catagory;
            this.status = status;
        }
        /// <summary>
        /// A constructor used for creating a ride stored in the database
        /// </summary>
        /// <param name="id">id assigned from database</param>
        /// <param name="name"></param>
        /// <param name="catagory"></param>
        /// <param name="status"></param>
        public Ride(int id, string name, string catagory, string status)
        {
            this.id = id;
            this.name = name;
            this.category = catagory;
            this.status = status;
        }
        #region Properties
        /// <summary>
        /// Property for getting and setting the List of reports from the database
        /// </summary>
        public List<Report> Reports
        {
            get { return reports; }
            set { reports = value; }
        }
        /// <summary>
        /// Property for getting and setting the status for the ride
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Property for getting and setting the category for the ride
        /// </summary>
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        /// <summary>
        /// Property for getting and setting the name for the ride
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Property for getting the id for the ride
        /// This is from the database cannot be changed
        /// </summary>
        public int Id
        {
            get { return id; }
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
