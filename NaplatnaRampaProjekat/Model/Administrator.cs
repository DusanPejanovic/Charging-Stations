using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class Administrator : Korisnik
    {

        public Administrator(int id,  string ime, string prezime, string korisnicko_ime, string sifra, string adresa, int plata, DateTime datumRaposlenja, DateTime datumRodjenja)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.KorisnickoIme = korisnicko_ime;
            this.Sifra = sifra;
            this.Adresa = adresa;
            this.Plata = plata;
            this.DatumZaposlenja = datumRaposlenja;
            this.DatumRodjenja = datumRodjenja;
        }



        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public int Plata { get => plata; set => plata = value; }
        public DateTime DatumZaposlenja { get => datumZaposlenja; set => datumZaposlenja = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }

    }
}
