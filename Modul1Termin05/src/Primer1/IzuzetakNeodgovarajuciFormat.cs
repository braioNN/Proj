using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer1
{
    class IzuzetakNeodgovarajuciFormat : FormatException
    {
        private string porukaGreske;

        public IzuzetakNeodgovarajuciFormat() : base() { }

        public IzuzetakNeodgovarajuciFormat(string poruka) : base(poruka)
        {
            this.porukaGreske = poruka;
        }

        public override string ToString()
        {
            return "Greska je nastala u delu teksta " + porukaGreske;
        }

    }
}
