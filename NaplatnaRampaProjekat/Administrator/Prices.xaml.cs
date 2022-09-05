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
    /// Interaction logic for Prices.xaml
    /// </summary>
    public partial class Prices : Window
    {
        public Prices()
        {
            InitializeComponent();
            FillDataGrid();
        }


        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=kula254;database=Naplatne_Rampe_DB");

        private void FillDataGrid()
        {
            string query = "select s.naziv as naziv_pocetne, s1.naziv as naziv_krajnje  , c1.cena as cena, k.naziv_kategorije as naziv_kategorije from stanica s1, stanica s, cenovnik c , cena c1, Kategorija_vozila k where s.id_stanica = c.id_stanica_pocetna and s1.id_stanica = c.ID_Stanica_krajnja and c1.id_cena = c.id_cena and k.ID_Kategorija_vozila = c.ID_Kategorija_vozila and c1.Datum_Zavrsetka_vazenja is null";
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
    }
}
