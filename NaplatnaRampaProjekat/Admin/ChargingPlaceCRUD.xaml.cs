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
        public ChargingPlaceCRUD()
        { 
            InitializeComponent();
            FillData();
        }
        MySqlConnection connection = new MySqlConnection(@"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB");

        private void FillData()
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

        }
    }
}
