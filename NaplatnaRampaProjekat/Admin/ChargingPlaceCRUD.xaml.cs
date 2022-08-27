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
            connection.Open();
            using var cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }


        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
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
            // TODO check input validity
            /*nazivTextBox.Clear();
            idTextBox.Clear();
            stanicaTextBox.Clear();
            */
        }

        private void confirmEdit_Click(object sender, RoutedEventArgs e)
        {
            //TODO SQL EDIT
            FillDataGrid();

            nazivTextBox.IsReadOnly = true;
            //idTextBox.IsReadOnly = true ;
            //stanicaTextBox.IsReadOnly = true ;
            eNaplataCheckBox.IsHitTestVisible = false;
            confirmEdit.Visibility = Visibility.Hidden;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            nazivTextBox.IsReadOnly = false;
            //idTextBox.IsReadOnly = false ;
            //stanicaTextBox.IsReadOnly = false ;
            eNaplataCheckBox.IsHitTestVisible = true;
            confirmEdit.Visibility = Visibility.Visible;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var deleteConfirmation = MessageBox.Show("Da li sigurno želite da izbrišete naplatno mesto(id: " + ID + " naziv: " + naziv + " stanica: " + stanica, "Potvrda brisanja", MessageBoxButton.YesNo);
            if ( deleteConfirmation == MessageBoxResult.Yes)
            {
                // TODO SQL deletion
                FillDataGrid();
            }
        }
    }
}
