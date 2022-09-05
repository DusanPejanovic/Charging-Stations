using Admin;
using Login;
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

namespace NaplatnaRampaProjekat.Menadzer
{
    /// <summary>
    /// Interaction logic for MenadzerWindow.xaml
    /// </summary>
    public partial class MenadzerWindow : Window
    {
        public MenadzerWindow()
        {
            InitializeComponent();
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
        private void report_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var report = new Reports();
            report.ShowDialog();
            this.Show();
        }

        private void cenovnik_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var prices = new Prices();
            prices.ShowDialog();
            this.Show();
        }
    }
}
