using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szabo_filmek
{
    class Film
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
        public double Ertekeles { get; set; }

        public Film(string cim, string mufaj, int hossz, double ertekeles)
        {
            Cim = cim;
            Mufaj = mufaj;
            Hossz = hossz;
            Ertekeles = ertekeles;
        }
    }
}
