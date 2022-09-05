using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class NaplatnoMesto
    {

        private int id;
        private bool elektronskaNaplata;
        private Stanica stanica;
        private string naziv;

        public NaplatnoMesto(string naziv, int id, bool elektronskaNaplata, Stanica stanica)
        {
            Id = id;
            ElektronskaNaplata = elektronskaNaplata;
            Naziv = naziv;
            Stanica = stanica;
        }

        public int Id { get => id; set => id = value; }
        public bool ElektronskaNaplata { get => elektronskaNaplata; set => elektronskaNaplata = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        internal Stanica Stanica { get => stanica; set => stanica = value; }
    }
}
