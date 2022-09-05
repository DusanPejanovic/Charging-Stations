using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class KategorijaVozila
    {
        private int id;
        private string? naziv;

        public KategorijaVozila(int id, string? naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public int Id { get => id; set => id = value; }
        public string? Naziv { get => naziv; set => naziv = value; }
    }
}
