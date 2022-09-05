using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class Radnik : Korisnik
    {
        protected int idStanice;
        public Radnik(int id, string ime, string prezime, string korisnicko_ime, string sifra, string adresa, int plata, DateTime datumRaposlenja, DateTime datumRodjenja, int idStanice)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Korisnicko_ime = korisnicko_ime;
            this.Sifra = sifra;
            this.Adresa = adresa;
            this.Plata = plata;
            this.DatumRaposlenja = datumZaposlenja;
            this.DatumRodjenja = datumRodjenja;
            this.idStanice = idStanice;
        }



        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Korisnicko_ime { get => korisnicko_ime; set => korisnicko_ime = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public int Plata { get => plata; set => plata = value; }
        public DateTime DatumRaposlenja { get => datumZaposlenja; set => datumZaposlenja = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public int IdStanice { get => idStanice; set => idStanice = value; }
    }
}
