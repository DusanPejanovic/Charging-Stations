using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class App : Form
    {
        public Login.User loggedUser;
        public App()
        {
            InitializeComponent();
        }
        public App(Login.User user)
        {
            InitializeComponent();
            this.loggedUser = user;
            loggedUserLabel.Text += loggedUser.Username;
        }
        
        private void App_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createWindow = new Charging_place.ChargingPlaceCreate() ;
            createWindow.ShowDialog();
            this.Show();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var login = new Login.Login();
            //login.Show();
            this.Close();
        }
    }
}
