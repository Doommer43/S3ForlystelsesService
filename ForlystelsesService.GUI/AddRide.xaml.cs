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

namespace ForlystelsesService.GUI
{
    /// <summary>
    /// Interaction logic for AddRide.xaml
    /// </summary>
    public partial class AddRide : Window
    {
        public AddRide()
        {
            InitializeComponent();
            List<string> categories = new List<string>();
            categories.Add("Rutsjebane");
            categories.Add("Pendulforlystelse");
            categories.Add("Vandforlystelse");
            ComBoxRideCategori.ItemsSource = categories;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
