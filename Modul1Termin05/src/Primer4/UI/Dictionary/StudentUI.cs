using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer4.Model;
using Modul1Termin05.Primer4.Utils;

namespace Modul1Termin05.Primer4.Dictionary.UI
{
    static class StudentUI
    {
        /** ATRIBUTI KLASE ****/
        public static Dictionary<int, Student> RecnikStudenata { get; set; }

        static StudentUI()
        {
            RecnikStudenata = new Dictionary<int, Student>();
        }

        /** MENI OPCJA ****/
        public static void MeniStudentUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOpcijeStudenta();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        UnosNovogStudenta();
                        break;
                    case 2:
                        IzmenaPodatakaOStudentu();
                        break;
                    case 3:
                        BrisanjePodatakaOStudentu();
                        break;
                    case 4:
                        IspisiSveStudente();
                        break;
                    case 5:
                        Student st = PronadjiStudentaPoIndeksu();
                        if (st != null)
                        {
                            Console.WriteLine(st.ToStringAll());
                        }
                        break;
                    case 6:
                        //TO DO
                        break;
                    case 7:
                        //TO DO
                        break;
                    case 8:
                        IspisiSveStudente(SortirajStudentePoImenu());
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }

        /** METODE ZA ISPIS OPCIJA ****/
        //ispis teksta osnovnih opcija

        public static void IspisiOpcijeStudenta()
        {
            Console.WriteLine("Rad sa studentima - opcije:");
            Console.WriteLine("\tOpcija broj 1 - unos podataka o novom studentu");
            Console.WriteLine("\tOpcija broj 2 - izmena podataka o studentu");
            Console.WriteLine("\tOpcija broj 3 - brisanje podataka o studentu");
            Console.WriteLine("\tOpcija broj 4 - ispis podataka svih studenata");
            Console.WriteLine("\tOpcija broj 5 - ispis podataka o odredenom studentu sa njegovim predmetima koje pohađa i ispitnim prijavama");
            Console.WriteLine("\tOpcija broj 6 - ispis podataka o odredenom studentu sa njegovim predmetima koje pohađa");
            Console.WriteLine("\tOpcija broj 7 - ispis podataka o odredenom studentu sa njegovim ispitnim prijavama");
            Console.WriteLine("\tOpcija broj 8 - sortiranje i ispis studenata po imenu");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS STUDENATA i ocena ****/
        //ispisi sve studente
        public static void IspisiSveStudente()
        {
            //1. način
            IspisiSveStudente(RecnikStudenata.Values.ToList<Student>());

            //2. način
            //foreach (int key in RecnikStudenata.Keys)
            //{
            //    Console.WriteLine(RecnikStudenata[key]);
            //}

            //3. način
            //foreach (KeyValuePair<int, Student> kvp in RecnikStudenata)
            //{
            //    Console.WriteLine(kvp.Value);
            //}
        }

        public static void IspisiSveStudente(IList<Student> lista)
        {
            foreach (Student stud in lista)
            {
                Console.WriteLine(stud);
            }
        }

        /** METODE ZA PRETRAGU STUDENATA****/
        //pronadji studenta
        public static Student PronadjiStudentaPoIndeksu()
        {
            Student retVal = null;
            Console.WriteLine("Unesi indeks studenta:");
            String stIndex = IOPomocnaKlasa.OcitajTekst();
            retVal = PronadjiStudentaPoIndeksu(stIndex);
            if (retVal == null)
                Console.WriteLine("Student sa indeksom " + stIndex + " ne postoji u evidenciji");
            return retVal;
        }

        //pronadji studenta
        public static Student PronadjiStudentaPoIndeksu(String stIndex)
        {
            Student retVal = null;
            foreach (Student st in RecnikStudenata.Values)
            {
                if (st.Indeks.Equals(stIndex))
                {
                    retVal = st;
                    break;
                }
            }
            return retVal;
        }

        //pronadji studenta
        public static Student PronadjiStudentaPoId(int id)
        {
            Student retVal = null;
            try
            {
                retVal = RecnikStudenata[id];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Ne postoji vrednost u rečniku RecnikStudenata za dati ključ!");
                throw;
            }
            return retVal;
        }

        /** METODA ZA SORTIRANJE STUDENATA****/
        public static IList<Student> SortirajStudentePoImenu()
        {
            //kako mapa studenata ne može da se sortira tako 
            //sve studente moramo prebaciti u listu čiji elementi mogu da se sortiraju
            List<Student> sortiraniStudenti = new List<Student>(RecnikStudenata.Values);
            Console.WriteLine("Studente je moguće sortirati po imenu\n\t1 - Rastuće\n\t2 - Opadajuće\nIzaberi opciju:");
            int sortOpcija = IOPomocnaKlasa.OcitajCeoBroj();
            switch (sortOpcija)
            {
                case 1:
                    sortiraniStudenti.Sort(new KomparatorStudenataPoImenu(1));
                    break;
                case 2:
                    sortiraniStudenti.Sort(new KomparatorStudenataPoImenu(-1));
                    break;
                default:
                    break;
            }
            return sortiraniStudenti;
        }


        /** METODE ZA UNOS i IZMENU STUDENATA****/

        //unos novog studenta
        public static void UnosNovogStudenta()
        {
            Console.WriteLine("Unesi index:");
            String stIndex = IOPomocnaKlasa.OcitajTekst();
            stIndex = stIndex.ToUpper();
            while (PronadjiStudentaPoIndeksu(stIndex) != null)
            {
                Console.WriteLine("Student sa indeksom " + stIndex + " vec postoji");
                stIndex = IOPomocnaKlasa.OcitajTekst();
            }
            Console.WriteLine("Unesi ime:");
            String stIme = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Unesi prezime:");
            String stPrezime = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Unesi grad:");
            String stGrad = IOPomocnaKlasa.OcitajTekst();

            //ID atribut ce se dodeliti automatski
            Student st = new Student(stIme, stPrezime, stGrad, stIndex);
            RecnikStudenata.Add(st.Id,st);

            while (IOPomocnaKlasa.Potvrdi("Upisati studenta da pohađa određene predmete?"))
            {
                PohadjaUI.DodajStudentaNaPredmet(st);
            }
        }

        //izmena studenta
        public static void IzmenaPodatakaOStudentu()
        {
            Student st = PronadjiStudentaPoIndeksu();
            if (st != null)
            {
                Console.WriteLine("Unesi ime:");
                String stIme = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi prezime:");
                String stPrezime = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi grad:");
                String stGrad = IOPomocnaKlasa.OcitajTekst();

                st.Ime = stIme;
                st.Prezime = stPrezime;
                st.Grad = stGrad;

                while (IOPomocnaKlasa.Potvrdi("Ukloniti studenta da ne pohađa određene predmet"))
                {
                    PohadjaUI.UkloniStudentaSaPredmeta(st);
                }

                while (IOPomocnaKlasa.Potvrdi("Upisati studenta da pohađa određene predmete?"))
                {
                    PohadjaUI.DodajStudentaNaPredmet(st);
                }
            }
        }

        //brisanje predmeta
        public static void BrisanjePodatakaOStudentu()
        {
            //neophodno redefinisati ToString metodu
            Student stud = PronadjiStudentaPoIndeksu();
            if (stud != null)
            {
                RecnikStudenata.Remove(stud.Id);
                PohadjaUI.UkloniStudentaIzPredmeta(stud);
                Console.WriteLine("Podaci obrisani iz evidencije");
            }
        }

        /** METODA ZA UCITAVANJE PODATAKA****/
        public static void UcitajStudenteIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader reader1 = File.OpenText(nazivDatoteke))
                {
                    Student stud;
                    string linija = "";
                    while ((linija = reader1.ReadLine()) != null)
                    {
                        stud = new Student(linija);
                        RecnikStudenata.Add(stud.Id, stud);
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static void SacuvajStudenteUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (Student s in RecnikStudenata.Values)
                    {
                        writer.WriteLine(s.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        
    }
}
