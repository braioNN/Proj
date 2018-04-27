using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer2;

namespace Modul1Termin05.Primer3
{
    class LinkedListClass
    {
        static void Main(string[] args)
        {
            // Create and initialize a new LinkedList.
            LinkedList<Student> LListaStudenata = new LinkedList<Student>();
            LListaStudenata.AddLast(new Student() { Ime = "Marko", Prezime = "Novaković", Id = 0 });
            LListaStudenata.AddLast(new Student() { Ime = "Žarko", Prezime = "Komarčević", Id = 1 });
            LListaStudenata.AddLast(new Student() { Ime = "Milan", Prezime = "Janković", Id = 2 });
            LListaStudenata.AddLast(new Student() { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 });
            LListaStudenata.AddLast(new Student() { Ime = "Jovana", Prezime = "Đokić", Id = 4 });
            LListaStudenata.AddFirst(new Student() { Ime = "Stanko", Prezime = "Lukić", Id = 5 });

            // Display the contents of the LinkedList.
            if (LListaStudenata.Count > 0)
            {
                Console.WriteLine("Prvi element liste je {0}.", LListaStudenata.First.Value);
                Console.WriteLine("Poslednji element liste je {0}.", LListaStudenata.Last.Value);

                Console.WriteLine("Ispisivanje liste");
                foreach (Student s in LListaStudenata)
                {
                    Console.WriteLine("{0}", s);
                }

                //dodavanje novog studenta
                Student stud = new Student() { Ime = "Rade", Prezime = "Baćić", Id = 6 };
                LListaStudenata.AddAfter(LListaStudenata.First, stud);

                Console.WriteLine("Da li postoji student sa id=6: ", LListaStudenata.Contains(stud));
                LListaStudenata.RemoveLast();

                Console.WriteLine("Ispisivanje liste");
                foreach (Student s in LListaStudenata)
                {
                    Console.WriteLine("{0}", s);
                }
                
                Console.WriteLine("Ispis uz pomoć iteratora: ");
                IEnumerator<Student> it = LListaStudenata.GetEnumerator();
                while (it.MoveNext())
                {
                    Console.WriteLine(it.Current);
                }

            }
            else
            {
                Console.WriteLine("Lista je prazna!");
            }
            Console.ReadKey();
        }
    }
}
