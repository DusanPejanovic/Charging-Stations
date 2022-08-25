using MySql.Data.MySqlClient;
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

namespace NaplatnaRampaProjekat
{
    /// <summary>
    /// Interaction logic for RadnikWindow.xaml
    /// </summary>
    public partial class RadnikWindow : Window
    {
        public RadnikWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }


        private void ObaviTransakciju(object sender, RoutedEventArgs e)
        {

            string cs = @"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT Datum_Pocetka_vazenja, Datum_Zavrsetka_vazenja, Cena FROM Cena WHERE ID_Cena in (  SELECT ID_Cena FROM Cenovnik WHERE ID_Stanica_pocetna IN (SELECT ID_Stanica FROM Stanica WHERE Naziv= '" + pocetnaStanicaTextBox.Text + "') AND  ID_Stanica_krajnja IN (SELECT ID_Stanica FROM Stanica WHERE Naziv= '" + krajnjaStanicaTextBox.Text + "') AND  ID_Kategorija_vozila IN (SELECT ID_Kategorija_vozila FROM Kategorija_vozila WHERE Naziv_kategorije='" + kategorijaVozilaTextBox.Text  + "'));";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            bool nadjen = false;

            while (rdr.Read())
            {
                string pass = rdr.GetString(1);
                string user = rdr.GetString(0);


                // Trace.WriteLine(user);
                // Trace.WriteLine(korisnickoImeTextBox.Text);  korisno za ispisivanje

                if (pass == pocetnaStanicaTextBox.Text && user == kategorijaVozilaTextBox.Text)
                {

                    nadjen = true;
                    MessageBox.Show("Dobro dosao ti si admin", "Notifikacija", MessageBoxButton.YesNoCancel);
                    break;
                }
            }

            rdr.Close();
        }

    }
}
