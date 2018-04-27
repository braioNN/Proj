using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer2;

namespace Modul1Termin05.Primer3
{
    class QueueClass
    {
        static void Main(string[] args)
        {
            Queue<Student> RedStudenata = new Queue<Student>();
            RedStudenata.Enqueue(new Student() { Ime = "Marko", Prezime = "Novaković", Id = 0 });
            RedStudenata.Enqueue(new Student() { Ime = "Žarko", Prezime = "Komarčević", Id = 1 });
            RedStudenata.Enqueue(new Student() { Ime = "Milan", Prezime = "Janković", Id = 2 });
            RedStudenata.Enqueue(new Student() { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 });
            RedStudenata.Enqueue(new Student() { Ime = "Jovana", Prezime = "Đokić", Id = 4 });            
            RedStudenata.Enqueue(new Student() { Ime = "Stanko", Prezime = "Lukić", Id = 5 });

            Console.WriteLine("Foreach ispis: ");
            foreach (Student s in RedStudenata)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Ispis uz pomoć iteratora: ");
            Queue<Student>.Enumerator it = RedStudenata.GetEnumerator();
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }

            Console.WriteLine("\nPreuzimanje prvog sa reda {0}", RedStudenata.Dequeue());
            Console.WriteLine("Provera prvog elementa bez brisanja iz reda {0}", RedStudenata.Peek());
            Console.WriteLine("Preuzimanje prvog sa reda  {0}", RedStudenata.Dequeue());

            Queue<Student> RedStudenataKopija = new Queue<Student>(RedStudenata.ToArray());

            Console.WriteLine("\nKopija reda: ");
            foreach (Student s in RedStudenataKopija)
            {
                Console.WriteLine(s);
            }

            Student stud = new Student() { Ime = "Stanko", Prezime = "Lukić", Id = 5 };
            Console.WriteLine("\nDa li se u kopiji reda nalazi student: {0} -> {1}", stud, RedStudenataKopija.Contains(stud));

            Console.WriteLine("\nBrisanje kopije");
            RedStudenataKopija.Clear();
            Console.WriteLine("\nBroj studenata u orginalnom redu je {0}", RedStudenata.Count);

            Console.ReadKey();
        }
    }
}
