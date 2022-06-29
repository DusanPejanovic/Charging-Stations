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

namespace Login
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
            User loggedUser = User.Login(username, passwrod);
            if ( loggedUser != null)
            {
                MessageBox.Show("Uspesan login!");
                this.Hide();
                var mainApp = new App.App(loggedUser);
                mainApp.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Neuspesan login!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

}
