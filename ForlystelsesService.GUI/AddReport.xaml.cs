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
using System.Windows.Shapes;
using Entities;

namespace ForlystelsesService.GUI
{
    /// <summary>
    /// Interaction logic for AddReport.xaml
    /// </summary>
    public partial class AddReport : Window
    {
        public AddReport(Ride ride)
        {
            InitializeComponent();
            TxtBlockSelectedRideName.Text = ride.Name;

            List<string> status = new List<string>();
            status.Add("Virker");
            status.Add("Mangler service");
            status.Add("Nedbrud");

            ComBoxRideStatus.ItemsSource = status;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
