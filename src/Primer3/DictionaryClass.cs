using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer2;

namespace Modul1Termin05.Primer3
{
    class DictionaryClass
    {
        static void Main(string[] args)
        {
            //Kreiranje liste i inicijalizacija sa CoLListaStudenataection Initializer-om
            //1 - Dictionary<int, Student>
            Dictionary<int, Student> RecnikStudenata = new Dictionary<int, Student> () {
            //2 - SortedList<int, Student>
            //SortedList<int, Student> RecnikStudenata = new SortedList<int, Student> () {
            //3  SortedDictionary<int, Student>
            //SortedDictionary<int, Student> RecnikStudenata = new SortedDictionary<int, Student>() {
                { 0, new Student () { Ime = "Marko", Prezime = "Novaković", Id = 0 } },
                { 1, new Student () { Ime = "Žarko", Prezime = "Komarčević", Id = 1 } },
                { 2, new Student () { Ime = "Milan", Prezime = "Janković", Id = 2 } },
                { 3, new Student () { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 } },
                { 4, new Student () { Ime = "Jovana", Prezime = "Đokić", Id = 4 } },
                { 5, new Student () { Ime = "Stanko", Prezime = "Lukić", Id = 5 } }
            };

            //Dodavanje studenata. 
            //RecnikStudenata.Add (0, new Student () { Ime = "Marko", Prezime = "Novaković", Id = 0 });
            //RecnikStudenata.Add (1, new Student () { Ime = "Žarko", Prezime = "Komarčević", Id = 1 });
            //RecnikStudenata.Add (2, new Student () { Ime = "Milan", Prezime = "Janković", Id = 2 });
            //RecnikStudenata.Add (3, new Student () { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 });
            //RecnikStudenata.Add (4, new Student () { Ime = "Jovana", Prezime = "Đokić", Id = 4 });
            //RecnikStudenata.Add (5, new Student () { Ime = "Stanko", Prezime = "Lukić", Id = 5 });

            //Metoda Add izaziva izuzetak tipa ArgumentException ako se ključ ponovi
            try
            {
                RecnikStudenata.Add(5, new Student() { Ime = "Stanko", Prezime = "Lukić", Id = 5 });
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Student sa datim ključem već postoji!");
            }

            //Vrednost rečnika se preuzima indeksiranjem uz pomoć ključeva (KeyNotFoundException u slučaju da ne postoji dati ključ)
            Console.WriteLine("Za ključ <3> se dobija sledeći student: {0}", RecnikStudenata[3]);

            //Nove vrednosti se takođe smeštaju uz pomoć indeksa
            RecnikStudenata[3] = new Student() { Ime = "Marija", Prezime = "Jugović", Id = 3 };
            Console.WriteLine("Za ključ <3> se dobija sledeći student: {0}.", RecnikStudenata[3]);

            //Ako postoji vrednost za dati ključ onda se ista prepisuje novim vrednostima
            Student stud = new Student() { Ime = "Rade", Prezime = "Baćić", Id = 6 };
            RecnikStudenata[stud.Id] = stud;
            Console.WriteLine($"Za ključ {stud.Id} se dobija student {RecnikStudenata[3]}.");

            //Ako se pokuša preuzeti vrednost za nepostojeći ključ - izuzetak
            try
            {
                Console.WriteLine("Za ključ <11> se dobija sledeći student: {0}", RecnikStudenata[11]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Student sa ključem <11> ne postoji!");
            }

            //Kako bi izbegli try/catch blok i izuzetke, koristi se metoda TryGetValue
            Student s;
            if (RecnikStudenata.TryGetValue(6, out s))
            {
                Console.WriteLine("Za ključ <6> se dobija sledeći student: {0}", s);
            }
            else
            {
                Console.WriteLine("Student sa ključem <6> ne postoji!");
            }

            //Pre dodavanja vrednosti se može proveriti da li dati ključ već postoji - ContainsKey
            if (!RecnikStudenata.ContainsKey(7))
            {
                RecnikStudenata.Add(7, new Student() { Ime = "Zdravko", Prezime = "Arsić", Id = 7 });
                Console.WriteLine("Za ključ <7> se dobija sledeći student: {0}", RecnikStudenata[7]);
            }

            //Ispisivanje rečnika foreach petljom
            //Elementi se preuzimaju kao KeyValuePair<TKey, TValue> objekat
            Console.WriteLine();
            foreach (KeyValuePair<int, Student> kvp in RecnikStudenata)
            {
                Console.WriteLine("Ključ = {0}, Vrednost = {1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("Ispis uz pomoć iteratora: ");
            //Kreiranje iteratora za različite kolekcije
            //1 - Dictionary<int, Student>
            IEnumerator<KeyValuePair<int, Student>> it = RecnikStudenata.GetEnumerator();
            //2 - SortedList<int, Student>
            //IEnumerator<KeyValuePair<int, Student>> it = RecnikStudenata.GetEnumerator();
            //3  SortedDictionary<int, Student>
            //SortedDictionary<int, Student>.Enumerator it = RecnikStudenata.GetEnumerator();
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }

            //Moguće je preuzeti samo vrednosti
            //1 - Dictionary<int, Student>
            Dictionary<int, Student>.ValueCollection vrednosti = RecnikStudenata.Values;
            //2 - SortedList<int, Student>
            //IList<Student> vrednosti = RecnikStudenata.Values;
            //3  SortedDictionary<int, Student>
            //SortedDictionary<int, Student>.ValueCollection vrednosti = RecnikStudenata.Values;

            Console.WriteLine();
            foreach (Student v in vrednosti)
            {
                Console.WriteLine("Vrednost: {0}", v);
            }

            //Moguće je preuzeti samo ključeve
            //1 - Dictionary<int, Student>
            Dictionary<int, Student>.KeyCollection kljucevi = RecnikStudenata.Keys;
            //2 - SortedList<int, Student>
            //IList<int> kljucevi = RecnikStudenata.Keys;
            //3  SortedDictionary<int, Student>
            //SortedDictionary<int, Student>.KeyCollection kljucevi = RecnikStudenata.Keys;
            
            Console.WriteLine();
            foreach (int k in kljucevi)
            {
                Console.WriteLine("Ključ: {0}", k);
            }

            //Uklanjanje vrednosti
            Console.WriteLine("\nUklanjanje studenta: " + stud);
            RecnikStudenata.Remove(stud.Id);

            if (!RecnikStudenata.ContainsKey(stud.Id))
            {
                Console.WriteLine("Ne postoji vrednost sa tim ključem!");
            }
            Console.ReadKey();
        }
    }
}
