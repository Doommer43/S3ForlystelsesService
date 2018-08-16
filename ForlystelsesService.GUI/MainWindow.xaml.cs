using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entities;
using ForlystelsesService.DBHandler;

namespace ForlystelsesService.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess dbh = new DataAccess(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ForlystelsesServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        List<Ride> rides = new List<Ride>();
        public MainWindow()
        {
            InitializeComponent();
            UpdateDG();
            DGForlystelser.ItemsSource = rides;
            
        }

        private void DGForlystelser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ride s_ride = (Ride)DGForlystelser.SelectedItem;

            TxtBlockSelectedRideName.Text = s_ride.Name;
            TxtBlockSelectedRideCategory.Text = s_ride.Category;
            TxtBlockSelectedRideStatus.Text = s_ride.Status;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRide addride = new AddRide();

            if(addride.ShowDialog() == true)
            {
                Ride ride = new Ride(addride.TxtBoxRideName.Text, addride.ComBoxRideCategori.SelectedItem.ToString(), "Virker");
                dbh.Save(ride);
                UpdateDG();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ride ride = (Ride)DGForlystelser.SelectedItem;
            AddReport addReport = new AddReport(ride);

            if(addReport.ShowDialog() == true)
            {
                string d = addReport.DatePicker.SelectedDate.Value.ToShortDateString();
                Report report = new Report(ride, addReport.ComBoxRideStatus.SelectedItem.ToString(), addReport.DatePicker.SelectedDate.Value, addReport.TxtBoxWrittenNotes.Text);
                ride.Status = report.Status;
                dbh.Save(report);
                dbh.UpdateStatus(ride);
                UpdateDG();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Ride ride = (Ride)DGForlystelser.SelectedItem;
            ViewReports reportwindow = new ViewReports(dbh.GetAllReports(ride));
            reportwindow.ShowDialog();
        }

        private void UpdateDG()
        {
            rides = dbh.GetAllRides();
            DGForlystelser.Items.Refresh();
        }
    }
}
