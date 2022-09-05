using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampaProjekat.Model
{
    internal class Stanica
    {
        private int id;
        private Administrator administrator;
        private string naziv;

        public Stanica(int id, string naziv, Administrator administrator)
        {
            Id = id;
            Naziv = naziv;
            Administrator = administrator;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        internal Administrator Administrator { get => administrator; set => administrator = value; }
    }
}
