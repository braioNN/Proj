using System;
using System.Collections;
using System.Collections.Generic;

namespace Modul1Termin05.Primer2
{
	class MainClass1
	{

		static void Main()
		{
			ArrayListMethod ();
            Console.ReadKey();
            Console.Clear();

            HashTableMethod ();
            Console.ReadKey();
            Console.Clear();

            SortedListMethod ();
            Console.ReadKey();
            Console.Clear();

            StackMethod ();
            Console.ReadKey();
            Console.Clear();

            QueueMethod ();
            Console.ReadKey();
            Console.Clear();
            Console.ReadKey();
        }

		static void ArrayListMethod ()
		{
			ArrayList al = new ArrayList ();

			Console.WriteLine ("Dodaju se brojevi.");
			al.Add (20);
			al.Add (73);
			al.Add (65);
			al.Add (56);
			al.Add (14);
			al.Add (87);
			al.Add (19);

			Console.WriteLine ("Kapacitet: {0} ", al.Capacity);
			Console.WriteLine ("Duzina (broj elemenata): {0}", al.Count);

			Console.Write ("Sadrzaj: ");
			foreach (int i in al) {
				Console.Write (i + " ");
			}

			Console.WriteLine ();
			Console.Write ("Sortirani sadržaj:  ");
			al.Sort ();
			foreach (int i in al) {
				Console.Write (i + " ");
			}
			Console.WriteLine ();
			Console.ReadKey ();
		}

		static void HashTableMethod ()
		{
			Hashtable ht = new Hashtable ();

			ht.Add ("3", "Žarko Kostović");
			ht.Add ("4", "Milan Stankić");
			ht.Add ("1", "Jovan Majaroš");
			ht.Add ("2", "Jelena Dimitrijević");
			ht.Add ("7", "Saška Bojić");
			ht.Add ("5", "Aleksandar Marković");
			ht.Add ("6", "Ana Janković");

			if (ht.ContainsValue ("Vladan Polić")) {
				Console.WriteLine ("Student sa tim imenom i prezimenom je već dodat u listu!");
			} else {
				ht.Add ("8", "Vladan Polić");
			}

			// preuyimanje ključeva
			ICollection key = ht.Keys;

			foreach (string k in key) {
				Console.WriteLine (k + ": " + ht [k]);
			}
			Console.WriteLine ();
			Console.ReadKey ();
		}

		static void SortedListMethod ()
		{
			SortedList sl = new SortedList ();

			sl.Add ("3", "Žarko Kostović");
			sl.Add ("4", "Milan Stankić");
			sl.Add ("1", "Jovan Majaroš");
			sl.Add ("2", "Jelena Dimitrijević");
			sl.Add ("7", "Saška Bojić");
			sl.Add ("5", "Aleksandar Marković");
			sl.Add ("6", "Ana Janković");

			if (sl.ContainsValue ("Vladan Polić")) {
				Console.WriteLine ("Student sa tim imenom i prezimenom je već dodat u listu!");
			} else {
				sl.Add ("8", "Vladan Polić");
			}

			// preuzimanje ključeva
			ICollection key = sl.Keys;

			foreach (string k in key) {
				Console.WriteLine (k + ": " + sl [k]);
			}
		}

		static void StackMethod ()
		{
			Stack st = new Stack ();

			st.Push (1);
			st.Push (2);
			st.Push (3);
			st.Push (4);

			Console.WriteLine ("Stanje stack-a: ");
			foreach (int i in st) {
				Console.Write (i + " ");
			}

			Console.WriteLine ();

			Console.WriteLine ("Prva vrednost sa vrha steka: {0}", st.Peek ());
			Console.WriteLine ("Stanje stack-a: ");
			foreach (int i in st) {
				Console.Write (i + " ");
			}

			Console.WriteLine ();

			Console.WriteLine ("Pražnjenje stack-a ");
			st.Pop ();
			st.Pop ();

			//ostatak ukloniti petljom
			while (st.Count > 0) {
				st.Pop ();
			}

			Console.WriteLine ("Stanje stack-a: ");
			foreach (int i in st) {
				Console.Write (i + " ");
			}
		}

		static void QueueMethod ()
		{
			Queue q = new Queue ();

			q.Enqueue (1);
			q.Enqueue (2);
			q.Enqueue (3);
			q.Enqueue (4);

			Console.WriteLine ("Stanje reda: ");
			foreach (int i in q) {
				Console.Write (i + " ");
			}

			Console.WriteLine ("Prva vrednost reda: "+q.Peek ());
			Console.WriteLine ("Uklanjanje vrednosti ");
			Console.WriteLine ("Uklonjena je vrednost: {0}", q.Dequeue ());
			Console.WriteLine ("Uklonjena je vrednost: {0}", q.Dequeue ());

			Console.ReadKey ();
		}

	}
}
