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
    /// Interaction logic for ChargingStationCRUD.xaml
    /// </summary>
    public partial class ChargingStationCRUD : Window
    {
        private int ID;
        private string naziv;
        private int administratorID;
        private string adminName;
        public ChargingStationCRUD()
        {
            InitializeComponent();
            FillDataGrid();
        }
        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB");
        private void FillDataGrid()
        {
            string query = "SELECT * from stanica";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            
        }
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateChargingStation();
            createWindow.ShowDialog();
            FillDataGrid();
            this.Show();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is not null)
            {
                nazivTextBox.IsReadOnly = false;
                confirmEdit.Visibility = Visibility.Visible;
                adminTextBox.IsReadOnly = false;
                dataGrid.IsHitTestVisible = false;
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati stanicu za izmenu!", "Poruka", MessageBoxButton.OK);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var deleteConfirmation = MessageBox.Show("Da li sigurno želite da izbrišete stabnicu(id: " + ID + " naziv: " + naziv + " administrator: " + getAdminName(administratorID)+ ")", "Potvrda brisanja", MessageBoxButton.YesNo);
            if (deleteConfirmation == MessageBoxResult.Yes)
            {
                try
                {
                    string update = "DELETE FROM stanica WHERE ID_Stanica = (@ID)";
                    using var cmd = new MySqlCommand(update, connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    nazivTextBox.Clear();
                    idTextBox.Clear();
                    adminTextBox.Clear();

                    FillDataGrid();
                }catch (MySql.Data.MySqlClient.MySqlException) {
                    MessageBox.Show("Ne mozete izbrisati stanicu koja trenutno ima naplatna mesta!", "Poruka", MessageBoxButton.OK);
                }
                
            }
        }
        private bool checkAdmin(int idAdmin)
        {
            string query = "SELECT COUNT(*) from administrator WHERE ID_Administrator = " + idAdmin + ';';
            var cmd = new MySqlCommand(query, connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        private bool checkAdmin(string name, string surname)
        {

            string query = "SELECT COUNT(*) from administrator WHERE Ime = (@name) AND prezime = (@surname);";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        private string getAdminName(int idAdmin)
        {
            string query = "SELECT Ime, Prezime from administrator WHERE ID_Administrator = " + idAdmin + ';';
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = (string)reader["Ime"];
                string surname = (string)reader["Prezime"];
                adminName = name + " " + surname;
            }
            reader.Close();
            return adminName;

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
        
        private void confirmEdit_Click(object sender, RoutedEventArgs e)
        {
            if (nazivTextBox.Text != "")
            {
                if (adminTextBox.Text != "")
                {
                    string fullName = adminTextBox.Text;
                    if (fullName.Split(' ').Count() > 1)
                    {
                        string name = fullName.Split(' ')[0];
                        string surname = fullName.Split(' ')[1];
                        if (checkAdmin(name, surname))
                        {
                            string update = "UPDATE stanica SET naziv = (@naziv), ID_Administrator = (@admin) WHERE ID_Stanica = (@ID)";
                            using var cmd = new MySqlCommand(update, connection);
                            cmd.Parameters.AddWithValue("@naziv", nazivTextBox.Text);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@admin", getAdminID(name, surname));
                            cmd.ExecuteNonQuery();
                            FillDataGrid();
                            nazivTextBox.IsReadOnly = true;
                            adminTextBox.IsReadOnly = true;
                            confirmEdit.Visibility = Visibility.Hidden;
                            dataGrid.IsHitTestVisible = true;
                            nazivTextBox.Clear();
                            idTextBox.Clear();
                            adminTextBox.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Administrator sa imenom " + adminTextBox.Text + " ne postoji!", "Poruka", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show(adminTextBox.Text + " nije validno ime i prezime!", "Poruka", MessageBoxButton.OK);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Administrator ne može biti prazan!", "Poruka", MessageBoxButton.OK);
                }

            }
            else
            {
                MessageBox.Show("Naziv stanice ne može biti prazan!", "Poruka", MessageBoxButton.OK);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is null)
            {
                return;
            }
            DataRowView dataRowView = (DataRowView)dataGrid.SelectedItem;
            ID = Convert.ToInt32(dataRowView.Row[0]);
            naziv = dataRowView.Row[1].ToString();
            administratorID = Convert.ToInt32(dataRowView.Row[2]);
            idTextBox.Text = ID.ToString();
            nazivTextBox.Text = naziv;
            //adminTextBox.Text = administratorID.ToString();
            adminTextBox.Text = (getAdminName(administratorID));
        }
    }
}
