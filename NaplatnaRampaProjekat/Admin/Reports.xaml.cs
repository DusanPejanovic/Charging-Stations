using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;
namespace Admin
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        public Reports()
        {
            InitializeComponent();
            FillDataGridBasic();
        }

        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=kula254;database=Naplatne_Rampe_DB");

        private void FillDataGridBasic()
        {
            string query = "select s.naziv as naziv_pocetne, s1.naziv as naziv_krajnje  , c1.cena as cena, k.naziv_kategorije as naziv_kategorije , c.registraciona_tablica as registraciona_tablica,  c.Datum_Transakcije as Datum_Transakcije from stanica s1, stanica s, transakcija c , cena c1 , Kategorija_vozila k where s.id_stanica = c.id_stanica_pocetna and s1.id_stanica = c.ID_Stanica_krajnja and c1.id_cena = c.id_cena and k.ID_Kategorija_vozila = c.ID_Kategorija_vozila and c1.Datum_Zavrsetka_vazenja is null;";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //var createWindow = new CreateChargingPlace();
            //createWindow.ShowDialog();
            //this.Show();
            dataGrid1.ItemsSource = null;

            string cs = @"server=localhost;userid=root;password=kula254;database=Naplatne_Rampe_DB";
            string date1 = "2015-10-06 11:16:10";
            string date2 = "2023-10-06 14:14:25";

            //string query = "select * from transakcija where " + pocetakTextBox.Text + " < Datum_Transakcije and " + krajTextBox.Text + " > Datum_Transakcije; ";
            string query = "select * from transakcija where " + date1 + " < Datum_Transakcije and " + date2 + " > Datum_Transakcije; ";


            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;

            /*using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from transakcija where @date1 < NOW() and @date2 > NOW(); ";
            cmd.ExecuteNonQuery();
            */
            pocetakTextBox.Text = "";
            krajTextBox.Text = "";
        }

    }
}
