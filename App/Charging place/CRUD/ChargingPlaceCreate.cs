using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charging_place
{
    public partial class ChargingPlaceCreate : Form
    {
        public ChargingPlaceCreate()
        {
            InitializeComponent();
        }

        private void ChargingPlaceCreate_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string referent = referentTextBox.Text;
            string id = idTextBox.Text;
            int number = (int)numberNumeric.Value;
            if (referent == "" || id == "" || number <= 0)
            {
                MessageBox.Show("Neipravan unos!");
            }
            else if ( ! ChargingPlace.CheckAvailability(id, number))
            {
                MessageBox.Show("Id ili redni broj je vec postoji!");
            }
            else
            {
                ChargingPlace.CreateChargingPlace(referent, id, number);
                MessageBox.Show("Uspesno dodato naplatno mesto");
            }
            this.Close();
        }

        private void numberNumeric_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
