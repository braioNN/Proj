using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer3
{
    class SetClass
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Definicija i inicijalizacija
            //1 -  HashSet<T>
            HashSet<string> Gradovi = new HashSet<string>()
            //2 -  SortedSet<T>
            //SortedSet<string> Gradovi = new SortedSet<string>()
            {"Novi Sad", "Loznica", "Subotica", "Raška", "Kragujevac"};
            
            Gradovi.Add("Novi Sad");
            Gradovi.Add("Beograd");
            Gradovi.Add("Subotica");
            Gradovi.Add("Niš");
            Gradovi.Add("Kragujevac");

            Console.WriteLine("Broj unetih gradova je: {0}", Gradovi.Count);
            Ispis(Gradovi);

            Console.WriteLine("Brisanje grada <kragujevac>");
            Gradovi.Remove("kragujevac");

            Console.WriteLine();
            //Ispis(Gradovi);
            Console.WriteLine("Ispis uz pomoć iteratora: ");
            //1 -  HashSet<T>
            HashSet<string>.Enumerator it = Gradovi.GetEnumerator();
            //2 -  SortedSet<T>
            //SortedSet<string>.Enumerator it = Gradovi.GetEnumerator();
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }
            Console.WriteLine();

            Console.WriteLine("Brisanje grada <Kragujevac>");
            Gradovi.Remove("Kragujevac");
            Ispis(Gradovi);

            HashSet<string> DodatniGradovi = new HashSet<string>() { "Beograd", "Irig", "Valjevo" };

            Console.WriteLine("Da li se kolekcije preklapaju: "+Gradovi.Overlaps(DodatniGradovi));

            //Gradovi.IntersectWith(DodatniGradovi);        //presek
            //Gradovi.UnionWith(DodatniGradovi);            //unija
            //Gradovi.ExceptWith(DodatniGradovi);           //oduzimanje
            //Gradovi.SymmetricExceptWith(DodatniGradovi);  //simetrična razlika

            Console.WriteLine("Broj elemenata: {0}", Gradovi.Count);
            Ispis(Gradovi);
            foreach (string item in Gradovi.Reverse())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Brisanje elemenata iz liste");
            Gradovi.Clear();
            
            Console.WriteLine("Broj elemenata: {0}", Gradovi.Count);
            Console.ReadKey();
        }

        private static void Ispis(ICollection<string> kolekcija)
        {
            foreach (var item in kolekcija)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
