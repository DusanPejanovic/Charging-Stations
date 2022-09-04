using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class Cena
    {
        private int id;
        private DateTime datumPocetkaVazenja;
        private DateTime? datumZavrsetkaVazenja;
        private int sumaCene;

        protected int Id { get => id; set => id = value; }
        protected DateTime DatumPocetkaVazenja { get => datumPocetkaVazenja; set => datumPocetkaVazenja = value; }
        protected DateTime? DatumZavrsetkaVazenja { get => datumZavrsetkaVazenja; set => datumZavrsetkaVazenja = value; }
        protected int SumaCene { get => sumaCene; set => sumaCene = value; }
    }
}
