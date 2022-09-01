﻿using Login;
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

namespace Admin
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void chargingPlace_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var chargingCRUD = new ChargingPlaceCRUD();
            chargingCRUD.ShowDialog();
            this.Show();
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cenovnik_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chargingStations_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var chargingCRUD = new ChargingStationCRUD();
            chargingCRUD.ShowDialog();
            this.Show();
        }
    }
}
