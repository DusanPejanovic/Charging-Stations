using MySql.Data.MySqlClient;
using System;
using System.Windows;
using Login;
using System.Windows.Controls;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Media.Animation;
using System.Drawing;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace NaplatnaRampaProjekat
{
    public partial class RadnikWindow : Window
    {
        private string idCena = "";
        private string nazivKrajnjeStanice = "";
        public RadnikWindow(string radnikUsername)
        {
            
            InitializeComponent();
            textBlockRadnikUsername.Text = "Radnik: " + radnikUsername;

            string cs = @"server=localhost;userid=root;password=admin;database=Naplatne_Rampe_DB";


            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT Naziv FROM Stanica WHERE Id_Stanica in (SELECT ID_Stanica FROM Radnik WHERE Korisnicko_Ime='"+radnikUsername+"');";
            using var cmd = new MySqlCommand(sql, con);


            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            nazivKrajnjeStanice = rdr.GetString(0);
            rdr.Close();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }


        private void PrikaziCenu(object sender, RoutedEventArgs e)
        {
            bool nadjen = false;

            string cs = @"server=localhost;userid=root;password=kula254;database=Naplatne_Rampe_DB";
           

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT Datum_Pocetka_vazenja, Datum_Zavrsetka_vazenja, Cena, ID_Cena FROM Cena WHERE ID_Cena in (  SELECT ID_Cena FROM Cenovnik WHERE ID_Stanica_pocetna IN (SELECT ID_Stanica FROM Stanica WHERE Naziv= '" + pocetnaStanicaTextBox.Text + "') AND  ID_Stanica_krajnja IN (SELECT ID_Stanica FROM Stanica WHERE Naziv= '" + nazivKrajnjeStanice + "') AND  ID_Kategorija_vozila IN (SELECT ID_Kategorija_vozila FROM Kategorija_vozila WHERE Naziv_kategorije='" + kategorijaVozilaTextBox.Text + "'));";
            using var cmd = new MySqlCommand(sql, con);


            using MySqlDataReader rdr = cmd.ExecuteReader();



            while (rdr.Read())
            {
                DateTime datumPocetkaVazenja = rdr.GetDateTime(0);


                DateTime datumZavrsetkaVazenja = DateTime.Now.AddDays(1);

                if (rdr.IsDBNull(1) == false)
                    datumZavrsetkaVazenja = rdr.GetDateTime(1);


                Double cena = rdr.GetDouble(2);


                if (DateTime.Now > datumPocetkaVazenja && DateTime.Now < datumZavrsetkaVazenja)
                {
                    idCena = rdr.GetString(3);
                    textBoxCena.Text = cena.ToString() + " rsd";
                    nadjen = true;
                    break;
                }
            }

            rdr.Close();

            if(nadjen == false)
                MessageBox.Show("Uneti podaci nisu ispravni.", "Notifikacija", MessageBoxButton.OK);



        }


        private void RacunajKusur(object sender, RoutedEventArgs e)
        {
            if(textBoxCena.Text == "")
            {
                MessageBox.Show("Prvo prikazi cenu.", "Notifikacija", MessageBoxButton.OK);
                return;
            }


            if (textBoxUplacenoNovca.Text == "")
            {
                MessageBox.Show("Unesi kolicinu novca.", "Notifikacija", MessageBoxButton.OK);
                return;
            }

            int cena = Int32.Parse(textBoxCena.Text.Split(' ')[0]);
            int uplacenoNovca = 0;

            if (Int32.TryParse(textBoxUplacenoNovca.Text, out uplacenoNovca) == false)
            {
                MessageBox.Show("Unesi samo brojeve kod kolicine novca.", "Notifikacija", MessageBoxButton.OK);
                return;
            }

            if (radioButtonEur.IsChecked == true)
            {
                uplacenoNovca = uplacenoNovca * 120; 
            }

            if(cena > uplacenoNovca)
            {
                MessageBox.Show("Cena je veca od kolicine uplacenog novca.", "Notifikacija", MessageBoxButton.OK);
                return;
            }

            textBoxKusur.Text = (uplacenoNovca - cena).ToString() + "rsd";


        }

        private void ObaviTransakcijju(object sender, RoutedEventArgs e)
        {

            if (idCena == "")
            {
                MessageBox.Show("Prvo prikazi cenu.", "Notifikacija", MessageBoxButton.OK);
                return;
            }

            string cs = @"server=localhost;userid=root;password=kula254;database=Naplatne_Rampe_DB";

            using var con = new MySqlConnection(cs);
            con.Open();
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = " INSERT INTO Transakcija (Datum_Transakcije, Registraciona_tablica, ID_Stanica_pocetna, ID_Stanica_krajnja, ID_Kategorija_vozila, ID_Cena) VALUES( NOW(), '" + registracionaTablicaTextBox.Text + "', (SELECT ID_Stanica  FROM Stanica WHERE Naziv='" + pocetnaStanicaTextBox.Text + "' ), (SELECT ID_Stanica FROM Stanica WHERE Naziv='" + nazivKrajnjeStanice + "' ), (SELECT ID_Kategorija_vozila FROM Kategorija_vozila WHERE Naziv_kategorije='" + kategorijaVozilaTextBox.Text + "'), " + idCena + ");";
            cmd.ExecuteNonQuery();

            idCena = "";
            textBoxKusur.Text = "";
            textBoxCena.Text = "";
            textBoxUplacenoNovca.Text = "";
            registracionaTablicaTextBox.Text = "";
            kategorijaVozilaTextBox.Text = "";
            pocetnaStanicaTextBox.Text = "";

            StartAnimation();


        }
        private void StartAnimation()
        {

            Color fromRGB = Color.FromRgb(255, 255, 255); 
            Color ToRGB = Color.FromRgb(0, 255, 0);

            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = Colors.Black;
            ColorAnimation myAnimation = new ColorAnimation();
            myAnimation.From = fromRGB;
            myAnimation.To = ToRGB;
            myAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(10000));
            myAnimation.AutoReverse = true;

            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myAnimation);

            MyButton.Fill = myBrush;
        }


    }
    }
