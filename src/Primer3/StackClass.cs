using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer2;

namespace Modul1Termin05.Primer3
{
    class StackClass
    {
        static void Main(string[] args)
        {
            Stack<Student> StackStudenata = new Stack<Student>();
            StackStudenata.Push(new Student() { Ime = "Marko", Prezime = "Novaković", Id = 0 });
            StackStudenata.Push(new Student() { Ime = "Žarko", Prezime = "Komarčević", Id = 1 });
            StackStudenata.Push(new Student() { Ime = "Milan", Prezime = "Janković", Id = 2 });
            StackStudenata.Push(new Student() { Ime = "Ana", Prezime = "Kuzmanović", Id = 3 });
            StackStudenata.Push(new Student() { Ime = "Jovana", Prezime = "Đokić", Id = 4 });
            StackStudenata.Push(new Student() { Ime = "Stanko", Prezime = "Lukić", Id = 5 });

            Console.WriteLine("Foreach ispis: ");
            foreach (Student s in StackStudenata)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Ispis uz pomoć iteratora: ");
            Stack<Student>.Enumerator it = StackStudenata.GetEnumerator();
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }

            Console.WriteLine("\nPreuzimanje prvog sa stack-a {0}", StackStudenata.Pop());
            Console.WriteLine("Provera prvog elementa bez brisanja iz stack-a {0}", StackStudenata.Peek());
            Console.WriteLine("Preuzimanje prvog sa stack-a  {0}", StackStudenata.Pop());

            //posto su slične kolekcije, može iz jedne da se kreira druga
            Queue<Student> RedStudenataKopija = new Queue<Student>(StackStudenata.ToArray());

            Console.WriteLine("\nKopija stack-a je sad red: ");
            foreach (Student s in RedStudenataKopija)
            {
                Console.WriteLine(s);
            }

            Student stud = new Student() { Ime = "Stanko", Prezime = "Lukić", Id = 5 };
            Console.WriteLine("\nDa li se u kopiji reda nalazi student: {0} -> {1}", stud, RedStudenataKopija.Contains(stud));

            Console.WriteLine("\nBrisanje kopije");
            RedStudenataKopija.Clear();
            Console.WriteLine("\nBroj studenata u orginalnom stack-u je {0}", StackStudenata.Count);

            Console.ReadKey();
        }
    }
}
