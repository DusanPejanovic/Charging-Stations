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
using NaplatnaRampaProjekat;
using Admin;

namespace Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string user = "";
        private string pass = "";
        public LoginWindow()
        {
            InitializeComponent();
            
        }
        private bool checkUserPassword(string type)
        {
            string cs = @"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT Korisnicko_Ime, Sifra FROM " + type;
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                 pass = rdr.GetString(1);
                 user = rdr.GetString(0);
                if (pass == sifraTextBox.Password && user == korisnickoImeTextBox.Text)
                {
                    MessageBox.Show("Dobro dosao ti si " + type, "Notifikacija");
                    return true;
                }
            }
            rdr.Close();

            return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkUserPassword("Administrator"))
            {
                this.Hide();
                var mainApp = new AdministratorWindow();
                mainApp.Show();
                this.Close();

            }
            else if (checkUserPassword("Radnik"))
            {
                RadnikWindow radnikWindow = new RadnikWindow(user);
                radnikWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Neuspesan login", "Notifikacija", MessageBoxButton.YesNoCancel);
            }

            

        }
    }
}
