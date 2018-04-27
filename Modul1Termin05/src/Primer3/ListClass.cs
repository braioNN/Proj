using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer2;
using Modul1Termin05.Primer4.Utils;

namespace Modul1Termin05.Primer3
{
    class ListClass
    {
        static void Main(string[] args)
        {
            //Kreiranje liste i inicijalizacija sa CoLListaStudenataection Initializer-om
            List<Student> ListaStudenata = new List<Student>() {
                new Student () { Ime = "Marko", Prezime = "Novaković", Id = 0 },
                new Student () { Ime = "Žarko", Prezime = "Komarčević", Id = 1 },
                new Student () { Ime = "Milan", Prezime = "Janković", Id = 2 },
                new Student () { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 },
                new Student () { Ime = "Jovana", Prezime = "Đokić", Id = 4 },
                new Student () { Ime = "Stanko", Prezime = "Lukić", Id = 5 }
            };

            //Dodavanje studenata
            //ListaStudenata.Add (new Student () { Ime = "Marko", Prezime = "Novaković", Id = 0 });
            //ListaStudenata.Add (new Student () { Ime = "Žarko", Prezime = "Komarčević", Id = 1 });
            //ListaStudenata.Add (new Student () { Ime = "Milan", Prezime = "Janković", Id = 2 });
            //ListaStudenata.Add (new Student () { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 });
            //ListaStudenata.Add (new Student () { Ime = "Jovana", Prezime = "Đokić", Id = 4 });
            //ListaStudenata.Add (new Student () { Ime = "Stanko", Prezime = "Lukić", Id = 5 });

            //Ispisivanje liste studenata. Implicitno se poziva ToString metoda
            Console.WriteLine();
            foreach (Student stud in ListaStudenata)
            {
                Console.WriteLine(stud);
            }


            //Metoda Contains proverava da li se određeni objekat nalazi u listi.
            //Potrebno je redefinisati metodu Equals unutar klase Student
            Console.WriteLine("\nDa li je dodat student sa Id=2: {0}",
                ListaStudenata.Contains(new Student { Id = 2, Ime = "", Prezime = "" }));


            Console.WriteLine("\nDodavanje studenta na 3. poziciju");
            ListaStudenata.Insert(2, new Student() { Ime = "Rade", Prezime = "Baćić", Id = 6 });

            Console.WriteLine("\nListaStudenata[2]: {0}", ListaStudenata[2]);

            //Console.WriteLine();
            foreach (Student stud in ListaStudenata)
            {
                Console.WriteLine(stud);
            }

            //Za sortiranje je potrebno implementirati interfejs IComparable<T> ili definisati IComparer<T> 
            //ListaStudenata.Sort();

            Console.WriteLine("\nBrisanje studenta sa Id=5");

            //Bez obzira što se student drugačije zove i preziva
            //unutar metode Equals je određeno šta se poredi.
            ListaStudenata.Remove(new Student() { Id = 5, Ime = "Branko", Prezime = "Zarić" });

            Console.WriteLine();
            foreach (Student stud in ListaStudenata)
            {
                Console.WriteLine(stud);
            }
            Console.WriteLine("\nRemoveAt(3)");

            //Brisanje studenta koji je na 4. mestu (indeks 3).
            ListaStudenata.RemoveAt(3);

            Console.WriteLine("Foreach ispis: ");
            foreach (Student stud in ListaStudenata)
            {
                Console.WriteLine(stud);
            }

            Console.WriteLine("Ispis uz pomoć iteratora: ");
            IEnumerator<Student> it = ListaStudenata.GetEnumerator();
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }            
            
            Console.WriteLine();

            Console.WriteLine("Kapacitet liste: {0}", ListaStudenata.Capacity);
            Console.WriteLine("Broj elemenata: {0}", ListaStudenata.Count);

            Console.WriteLine("Trimovanje liste");
            ListaStudenata.TrimExcess();

            Console.WriteLine("Kapacitet liste: {0}", ListaStudenata.Capacity);
            Console.WriteLine("Broj elemenata: {0}", ListaStudenata.Count);

            Console.WriteLine("Brisanje elemenata iz liste");
            ListaStudenata.Clear();

            Console.WriteLine("Kapacitet liste: {0}", ListaStudenata.Capacity);
            Console.WriteLine("Broj elemenata: {0}", ListaStudenata.Count);
            Console.ReadKey();
        }
    }
}
