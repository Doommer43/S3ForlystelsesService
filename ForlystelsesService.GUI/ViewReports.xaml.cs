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
    /// Interaction logic for ViewReports.xaml
    /// This is now a Github project
    /// </summary>
    public partial class ViewReports : Window
    {
        public ViewReports(List<Report> reports)
        {
            InitializeComponent();
            DGReports.ItemsSource = reports;
        }

        private void DGReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Report report = (Report)DGReports.SelectedItem;
            TxtBlockRideName.Text = report.Ride.Name;
            TxtBlockSelectedRideStatus.Text = report.Status;
            TxtBlockReportDate.Text = report.ReportTime.ToShortDateString();
            TxtBlockSelectedReportNotes.Text = report.Notes;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
