using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charging_stations
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string passwrod = passwordTextBox.Text;
            if((User.Login(username, passwrod) != null))
            {
                MessageBox.Show("Uspesan login!");
                this.Hide();
                var mainApp = new App.App();
                mainApp.Show();
            }
            else
            {
                MessageBox.Show("Neuspesan login!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
