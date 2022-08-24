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
using MySql.Data.MySqlClient;

namespace NaplatnaRampaProjekat.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string cs = @"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT Korisnicko_Ime, Sifra FROM Administrator";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            bool nadjen = false;

            while (rdr.Read())
            {
                string pass = rdr.GetString(1);
                string user = rdr.GetString(0);


                // Trace.WriteLine(user);
                // Trace.WriteLine(korisnickoImeTextBox.Text);  korisno za ispisivanje

                if (pass == sifraTextBox.Text && user == korisnickoImeTextBox.Text)
                {

                    nadjen = true;
                    MessageBox.Show("Doboro dosao ti si admin", "Notifikacija", MessageBoxButton.YesNoCancel);
                    break;
                }
            }

            rdr.Close();

            if (nadjen == true)
                return;

            sql = "SELECT Korisnicko_Ime, Sifra FROM Radnik";
            using var cmd2 = new MySqlCommand(sql, con);

            using MySqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                string pass = rdr2.GetString(1);
                string user = rdr2.GetString(0);

                if (pass == sifraTextBox.Text && user == korisnickoImeTextBox.Text)
                {
                    nadjen = true;
                    MessageBox.Show("Dobro dosao ti si radnik", "Notifikacija", MessageBoxButton.YesNoCancel);
                    break;
                }
            }

            if (nadjen == true)
                return;

            MessageBox.Show("Nisi dobro dosao", "Notifikacija", MessageBoxButton.YesNoCancel);

        }
    }
}
