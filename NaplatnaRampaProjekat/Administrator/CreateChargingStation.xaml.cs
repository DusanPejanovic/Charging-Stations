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
    /// Interaction logic for CreateChargingStation.xaml
    /// </summary>
    public partial class CreateChargingStation : Window
    {
        public CreateChargingStation()
        {
            InitializeComponent();
            FillComboBox();
        }
        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB");
        private void FillComboBox()
        {
            string query = "SELECT Ime, Prezime from administrator";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(0);
                var surname = reader.GetString(1);
                adminComboBox.Items.Add(name + " " + surname);
            }
            reader.Close();
        }
        private int getAdminID(string name, string surname)
        {
            string query = "SELECT ID_Administrator from administrator WHERE ime = (@name) AND prezime = (@surname);";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            int adminID = (int)cmd.ExecuteScalar();


            return adminID;
        }
        private bool checkInputValidity()
        {
            string query = "SELECT COUNT(*) from stanica WHERE ID_Stanica = " + idTextBox.Text + ';';
            int i;
            if (!int.TryParse(idTextBox.Text, out i))
            {
                MessageBox.Show("ID " + idTextBox.Text + " nije validan ID za stanicu!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }
            var cmd = new MySqlCommand(query, connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if (nazivTextBox.Text == "")
            {
                MessageBox.Show("Naziv stanice ne može biti prazan!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }
            else if (result != 0)
            {
                MessageBox.Show("Već postoji stanicasa ID-om " + idTextBox.Text + "!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }
            else if (adminComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Morate izabrati administrator stanice!", "Notifikacija", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkInputValidity())
            {
                var id = idTextBox.Text;
                var naziv = nazivTextBox.Text;
                var adminFullName = adminComboBox.SelectedItem.ToString();
                string update = "INSERT INTO stanica (ID_Stanica, Naziv, ID_Administrator) VALUES (@ID, @Naziv, @admin);";
                using var cmd = new MySqlCommand(update, connection);
                cmd.Parameters.AddWithValue("@Naziv", naziv);
                cmd.Parameters.AddWithValue("@ID", id);
                string name = adminFullName.Split(' ')[0];
                string surname = adminFullName.Split(' ')[1];
                cmd.Parameters.AddWithValue("@admin", getAdminID(name, surname));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspešno dodavanje stanice!", "Notifikacija", MessageBoxButton.OK);
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void adminComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
