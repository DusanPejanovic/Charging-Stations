using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class Cenovnik
    {
        private int id;
        private Stanica stanicaPocetna;
        private Stanica stanicaKrajnja;
        private KategorijaVozila kategorija;
        private Cena cena;

        public Cenovnik(int id, Stanica stanicaPocetna, Stanica stanicaKrajnja, KategorijaVozila kategorija, Cena cena)
        {
            Id = id;
            StanicaPocetna = stanicaPocetna;
            StanicaKrajnja = stanicaKrajnja;
            Kategorija = kategorija;
            Cena = cena;
        }

        protected int Id { get => id; set => id = value; }
        protected Stanica StanicaPocetna { get => stanicaPocetna; set => stanicaPocetna = value; }
        protected Stanica StanicaKrajnja { get => stanicaKrajnja; set => stanicaKrajnja = value; }
        protected KategorijaVozila Kategorija { get => kategorija; set => kategorija = value; }
        protected Cena Cena { get => cena; set => cena = value; }
    }
}
