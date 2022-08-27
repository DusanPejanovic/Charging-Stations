using System;
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
    /// Interaction logic for CreateTollPlace.xaml
    /// </summary>
    public partial class CreateTollPlace : Window
    {
        public CreateTollPlace()
        {
            InitializeComponent();
            FillComboBox();
        }
        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB");
        private void FillComboBox()
        {
            string query = "SELECT naziv from stanica";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stanicaComboBox.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool checkInputValidity()
        {
            string query = "SELECT COUNT(*) from naplatno_mesto WHERE ID_Naplatno_mesto = " + idTextBox.Text + ';';
            int i;
            if (!int.TryParse(idTextBox.Text, out i))
            {
                MessageBox.Show("ID "+ idTextBox.Text + " nije validan ID za naplatno mesto!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }
            var cmd = new MySqlCommand(query, connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());            
            if ( nazivTextBox.Text == "")
            {
                MessageBox.Show("Naziv naplatnog mesta ne može biti prazan!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }else if (result != 0 ){
                MessageBox.Show("Već postoji naplatno mesto sa ID-om " + idTextBox.Text + "!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }else if ( stanicaComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Morate izabrati naplatno stanicu kojoj pripada mesto!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
        private int FindStation(string stationName)
        {
            string query = "SELECT ID_Stanica from stanica WHERE naziv = " + '"' + stationName + '"' + ';';
            var cmd = new MySqlCommand(query, connection);
            int  stationID = (int)cmd.ExecuteScalar();


            return stationID;

        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkInputValidity())
            {
                var id = idTextBox.Text;
                var naziv = nazivTextBox.Text;
                var stanicaNaziv = stanicaComboBox.SelectedItem.ToString();
                var enaplata = eNaplataCheckBox.IsChecked;
                var stanicaID = FindStation(stanicaNaziv);
                string update = "INSERT INTO naplatno_mesto (ID_Naplatno_mesto, Naziv, Elektronska_naplata, ID_stanica) VALUES (@ID, @Naziv, @eNaplata, @stanica);";
                using var cmd = new MySqlCommand(update, connection);
                cmd.Parameters.AddWithValue("@Naziv", naziv);
                cmd.Parameters.AddWithValue("@ID", id);
                if ((bool)eNaplataCheckBox.IsChecked)
                {
                    cmd.Parameters.AddWithValue("eNaplata", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("eNaplata", 0);
                }
                cmd.Parameters.AddWithValue("@stanica", stanicaID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspešno dodavanje naplatnog mesta!", "Notifikacija", MessageBoxButton.OK);
                this.Close();
            }
        }

        private void stanicaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(stanicaComboBox.SelectedItem.ToString(), "YE", MessageBoxButton.OK);
        }
    }
}
