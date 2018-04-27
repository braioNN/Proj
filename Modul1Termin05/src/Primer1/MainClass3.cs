using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer1
{
    class MainClass3
    {
        public static void Main(String[] args)
        {
            //Ako metoda unutar sebe ima obradu izuzetaka
            //onda ovde nije neophodan try/catch blok.
            //Napomena: Na korisniku je da odluči da li je
            //potreban try/catch na osnovu prirode metode.
            Metoda();

            try
            {
                ParsiranjeStringaUInt();

            }
            catch (IzuzetakNeodgovarajuciFormat e)
            {
                Console.WriteLine("Moj izuzetak IzuzetakNeodgovarajuciFormat");
                Console.WriteLine(e);
                //Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("Kraj aplikacije");
            Console.ReadKey();
        }

        public static void Metoda()
        {
            try
            {
                ParsiranjeStringaUInt();
            }
            catch (Exception e)
            {
                Console.WriteLine("Tip greške: " + e.GetType().Name);
                Console.WriteLine("GREŠKA: " + e.Message);
            }
        }

        public static int ParsiranjeStringaUInt()
        {
            String tekst = "tri";
            int a;
            if (!Int32.TryParse(tekst, out a))
                throw new IzuzetakNeodgovarajuciFormat("Pokušaj parsiranja vrednosti \""+tekst+"\" u int!");

            return Int32.Parse(tekst);
        }

        
    }
}
