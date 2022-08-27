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
    /// Interaction logic for ChargingPlaceCRUD.xaml
    /// </summary>
    public partial class ChargingPlaceCRUD : Window
    {
        private int ID;
        private string naziv;
        private int stanica;
        private bool eNaplata;
        public ChargingPlaceCRUD()
        { 
            InitializeComponent();
            FillDataGrid();
            
        }
        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB");
        

        private void FillDataGrid()
        {
            string query = "SELECT * from naplatno_mesto";
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


        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is null)
            {
                return;
            }
            DataRowView dataRowView = (DataRowView)dataGrid.SelectedItem;
            ID = Convert.ToInt32(dataRowView.Row[0]);
            naziv = dataRowView.Row[1].ToString();
            stanica = Convert.ToInt32(dataRowView.Row[3]);
            eNaplata = (bool)dataRowView.Row[2];
            idTextBox.Text = ID.ToString();
            nazivTextBox.Text = naziv;
            stanicaTextBox.Text = stanica.ToString();
            if (eNaplata)
            {
                eNaplataCheckBox.IsChecked = true;
            }
            else
            {
                eNaplataCheckBox.IsChecked = false;
            }
            
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            var createWindow = new CreateTollPlace();
            createWindow.ShowDialog();
            FillDataGrid();
            this.Show();
        }

        private void confirmEdit_Click(object sender, RoutedEventArgs e)
        {
            
            if ( nazivTextBox.Text != "")
            {
                string update = "UPDATE naplatno_mesto SET naziv = (@naziv), Elektronska_naplata = (@eNaplata) WHERE ID_Naplatno_mesto = (@ID)";
                using var cmd = new MySqlCommand(update, connection);
                cmd.Parameters.AddWithValue("@naziv", nazivTextBox.Text);
                cmd.Parameters.AddWithValue("@ID", ID);
                if ((bool)eNaplataCheckBox.IsChecked)
                {
                    cmd.Parameters.AddWithValue("eNaplata", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("eNaplata", 0);
                }
                cmd.ExecuteNonQuery();
                FillDataGrid();
                nazivTextBox.IsReadOnly = true;
                eNaplataCheckBox.IsHitTestVisible = false;
                confirmEdit.Visibility = Visibility.Hidden;
                dataGrid.IsHitTestVisible = true;

            }
            else
            {
                MessageBox.Show("Naziv stanice ne može biti prazan!", "Poruka", MessageBoxButton.OK);
            }
            


        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is not null)
            {
                nazivTextBox.IsReadOnly = false;
                eNaplataCheckBox.IsHitTestVisible = true;
                confirmEdit.Visibility = Visibility.Visible;
                dataGrid.IsHitTestVisible = false;
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati stanicu za izmenu!", "Poruka", MessageBoxButton.OK);
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var deleteConfirmation = MessageBox.Show("Da li sigurno želite da izbrišete naplatno mesto(id: " + ID + " naziv: " + naziv + " stanica broj: " + stanica + ")", "Potvrda brisanja", MessageBoxButton.YesNo);
            if ( deleteConfirmation == MessageBoxResult.Yes)
            {
                string update = "DELETE FROM naplatno_mesto WHERE ID_Naplatno_mesto = (@ID)";
                using var cmd = new MySqlCommand(update, connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                nazivTextBox.Clear();
                idTextBox.Clear();
                stanicaTextBox.Clear();
                eNaplataCheckBox.IsChecked = false;

                FillDataGrid();
            }
        }
    }
}
