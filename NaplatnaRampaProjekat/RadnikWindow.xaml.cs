using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace NaplatnaRampaProjekat
{
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
            string idCena = "";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT Datum_Pocetka_vazenja, Datum_Zavrsetka_vazenja, Cena, ID_Cena FROM Cena WHERE ID_Cena in (  SELECT ID_Cena FROM Cenovnik WHERE ID_Stanica_pocetna IN (SELECT ID_Stanica FROM Stanica WHERE Naziv= '" + pocetnaStanicaTextBox.Text + "') AND  ID_Stanica_krajnja IN (SELECT ID_Stanica FROM Stanica WHERE Naziv= '" + krajnjaStanicaTextBox.Text + "') AND  ID_Kategorija_vozila IN (SELECT ID_Kategorija_vozila FROM Kategorija_vozila WHERE Naziv_kategorije='" + kategorijaVozilaTextBox.Text  + "'));";
            using var cmd = new MySqlCommand(sql, con);


            using MySqlDataReader rdr = cmd.ExecuteReader();



            while (rdr.Read())
            {
                DateTime datumPocetkaVazenja = rdr.GetDateTime(0);


                DateTime datumZavrsetkaVazenja = DateTime.Now.AddDays(1);

                if (rdr.IsDBNull(1) == false) 
                    datumZavrsetkaVazenja = rdr.GetDateTime(1);


                Double cena = rdr.GetDouble(2);
               

                if (DateTime.Now >  datumPocetkaVazenja && DateTime.Now < datumZavrsetkaVazenja)
                {
                    idCena = rdr.GetString(3);
                    MessageBox.Show("Naplati " + cena.ToString() + " dinara.", "Notifikacija", MessageBoxButton.OK);
                    MessageBox.Show("Obavljenja transakcija", "Notifikacija", MessageBoxButton.OK);
                    break;
                }
            }

            rdr.Close();


            using var cmd2 = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = " INSERT INTO Transakcija (Datum_Transakcije, Registraciona_tablica, ID_Stanica_pocetna, ID_Stanica_krajnja, ID_Kategorija_vozila, ID_Cena) VALUES( NOW(), '" + registracionaTablicaTextBox.Text + "', (SELECT ID_Stanica  FROM Stanica WHERE Naziv='" + pocetnaStanicaTextBox.Text + "' ), (SELECT ID_Stanica FROM Stanica WHERE Naziv='" + krajnjaStanicaTextBox.Text + "' ), (SELECT ID_Kategorija_vozila FROM Kategorija_vozila WHERE Naziv_kategorije='" + kategorijaVozilaTextBox.Text + "'), " + idCena + ");";
            cmd.ExecuteNonQuery();
        }


    }
}
