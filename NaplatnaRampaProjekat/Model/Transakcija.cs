using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class Transakcija
    {
        private int id;
        private DateTime datumTransakcije;
        private string registracionaTablica;
        private Stanica pocetenaStanica;
        private Stanica krajnjaStanica;
        private KategorijaVozila kategorijaVozila;
        private Cena cena;

        public Transakcija(int id, DateTime datumTransakcije, string registracionaTablica, Stanica pocetenaStanica, Stanica krajnjaStanica, KategorijaVozila kategorijaVozila, Cena cena)
        {
            Id = id;
            DatumTransakcije = datumTransakcije;
            RegistracionaTablica = registracionaTablica;
            PocetenaStanica = pocetenaStanica;
            KrajnjaStanica = krajnjaStanica;
            KategorijaVozila = kategorijaVozila;
            Cena = cena;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DatumTransakcije { get => datumTransakcije; set => datumTransakcije = value; }
        public string RegistracionaTablica { get => registracionaTablica; set => registracionaTablica = value; }
        internal Stanica PocetenaStanica { get => pocetenaStanica; set => pocetenaStanica = value; }
        internal Stanica KrajnjaStanica { get => krajnjaStanica; set => krajnjaStanica = value; }
        internal KategorijaVozila KategorijaVozila { get => kategorijaVozila; set => kategorijaVozila = value; }
        internal Cena Cena { get => cena; set => cena = value; }
    }
}
