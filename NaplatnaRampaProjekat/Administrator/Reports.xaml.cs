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
            //FillDataGridBasic();
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

            query = "";
            using var cmd1 = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=kula254;database=Naplatne_Rampe_DB";

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string pocetno_vreme = pocetakTextBox.Text;
            string krajnje_vreme = krajTextBox.Text;
            string query = "select distinct t.ID_Stanica_pocetna, t.ID_Stanica_krajnja, t.ID_Kategorija_vozila, t.Registraciona_tablica, t.ID_Cena, t.Datum_Transakcije, c.cena from transakcija t, cena c where '" + pocetno_vreme + "' < Datum_Transakcije and '" + krajnje_vreme + "' > Datum_Transakcije and t.ID_cena = t.id_cena group by t.ID_Stanica_pocetna, t.ID_Stanica_krajnja, t.ID_Kategorija_vozila, t.Registraciona_tablica, t.ID_Cena, t.Datum_Transakcije;";

            using var cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            query = "select count(*) as posecenost, max(ID_Stanica_pocetna), ID_Stanica_pocetna from transakcija group by ID_Stanica_pocetna limit 1;";
            MySqlDataReader dr;
            using var cmd1 = new MySqlCommand(query, connection);
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
            dr.Read();
            string max = dr.GetString("ID_Stanica_Pocetna");
            dr.Close();
            maxPoseta.Content = max;
            query = "select sum(cena) as ukupanPazar from transakcija inner join cena on transakcija.id_cena = cena.id_cena; ";
            using var cmd2 = new MySqlCommand(query, connection);
            MySqlDataReader dr1;
            dr1 = cmd.ExecuteReader(CommandBehavior.SingleResult);
            dr1.Read();
            int pazarInt = dr1.GetInt32(1);
            string pazar = pazarInt.ToString();
            ukupanPazar.Content = pazar;
            pocetakTextBox.Text = "";
            krajTextBox.Text = "";
            dataGrid1.ItemsSource = dt.DefaultView;
            dr.Close();
        }

    }
}
