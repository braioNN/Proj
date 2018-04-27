using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer4.Model;
using Modul1Termin05.Primer4.Utils;

namespace Modul1Termin05.Primer4.List.UI
{
    class PredmetUI
    {
        /** ATRIBUTI KLASE ****/
        public static List<Predmet> ListaPredmeta { get; set; }

        static PredmetUI()
        {
            ListaPredmeta = new List<Predmet>();
        }

        public static void MeniPredmetUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOpcijePredmeta();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        UnosNovogPredmeta();
                        break;
                    case 2:
                        IzmenaPodatakaOPredmetu();
                        break;
                    case 3:
                        BrisanjePodatakaOPredmetu();
                        break;
                    case 4:
                        IspisiSvePredmete();
                        break;
                    case 5:
                        Predmet pr = PronadjiPredmetPoId();
                        if (pr != null)
                        {
                            Console.WriteLine(pr.ToStringAll());
                        }
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }

        public static void IspisiOpcijePredmeta()
        {
            Console.WriteLine("Rad sa predmetima - opcije:");
            Console.WriteLine("\tOpcija broj 1 - unos podataka o novom Predmetu");
            Console.WriteLine("\tOpcija broj 2 - izmena podataka o Predmetu");
            Console.WriteLine("\tOpcija broj 3 - brisanje podataka o Predmetu");
            Console.WriteLine("\tOpcija broj 4 - ispis podataka svih predmeta");
            Console.WriteLine("\tOpcija broj 5 - ispis podataka o odredenom Predmetu i svih studenta koji pohašaju predmet");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS PREDMETA ****/
        // ispisi sve predmete
        public static void IspisiSvePredmete()
        {
            for (int i = 0; i < ListaPredmeta.Count; i++)
            {
                Console.WriteLine(ListaPredmeta[i]);
            }
        }

        /** METODE ZA PRETRAGU PREDMETA ****/
        // pronadji predmet
        public static Predmet PronadjiPredmetPoId()
        {
            Predmet retVal = null;
            Console.WriteLine("Unesi id predmeta:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiPredmetPoId(id);
            if (retVal == null)
                Console.WriteLine("Predmet sa id-om " + id
                        + " ne postoji u evidenciji");
            return retVal;
        }

        // pronadji predmet
        public static Predmet PronadjiPredmetPoId(int id)
        {
            Predmet retVal = null;
            for (int i = 0; i < ListaPredmeta.Count; i++)
            {
                Predmet pr = ListaPredmeta[i];
                if (pr.Id == id)
                {
                    retVal = pr;
                    break;
                }
            }
            return retVal;
        }

        public static int PronadjiPozicijuPredmetaPoId()
        {
            int retVal = -1;
            Console.WriteLine("Unesi id predmeta:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            for (int i = 0; i < ListaPredmeta.Count; i++)
            {
                Predmet pr = ListaPredmeta[i];
                if (pr.Id == id)
                {
                    retVal = i;
                    break;
                }
            }
            if (retVal == -1)
                Console.WriteLine("Predmet sa id-om " + id
                        + " ne postoji u evidenciji");
            return retVal;
        }

        /** METODE ZA UNOS, IZMENU I BRISANJE PREDMETA ****/
        // unos novog predmeta
        public static void UnosNovogPredmeta()
        {
            Console.WriteLine("Naziv:");
            string naziv = IOPomocnaKlasa.OcitajTekst();

            Console.WriteLine("Oznaka:");
            string oznaka = IOPomocnaKlasa.OcitajTekst();

            Predmet pred = new Predmet(naziv,oznaka);
            ListaPredmeta.Add(pred);

            while (IOPomocnaKlasa.Potvrdi("upisati studente da pohađaju predmet"))
            {
                PohadjaUI.DodajStudentaNaPredmet(pred);
            }
        }

        // izmena predmeta
        public static void IzmenaPodatakaOPredmetu()
        {
            Predmet pred = PronadjiPredmetPoId();
            if (pred != null)
            {
                Console.WriteLine("Unesi novi naziv :");
                string naziv = IOPomocnaKlasa.OcitajTekst();
                pred.Naziv=naziv;

                Console.WriteLine("Unesi novu oznaku :");
                string oznaka = IOPomocnaKlasa.OcitajTekst();
                pred.Oznaka = oznaka;

                while (IOPomocnaKlasa.Potvrdi("Ukloniti studente da ne pohađaju predmet"))
                {
                    PohadjaUI.UkloniStudentaSaPredmeta(pred);
                }

                while (IOPomocnaKlasa.Potvrdi("Upisati studente da pohađaju predmet"))
                {
                    PohadjaUI.DodajStudentaNaPredmet(pred);
                }
            }
        }

        //brisanje predmeta
        public static void BrisanjePodatakaOPredmetu()
        {
            Predmet pr = PronadjiPredmetPoId();
            if (pr != null)
            {
                ListaPredmeta.Remove(pr);
                PohadjaUI.UkloniPredmetIzStudenata(pr);
                Console.WriteLine("Podaci obrisani iz evidencije");
            }
        }

        /** METODA ZA UCITAVANJE PODATAKA****/
        public static void UcitajPredmeteIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader reader1 = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = reader1.ReadLine()) != null)
                    {
                        ListaPredmeta.Add(new Predmet(linija));
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static void SacuvajPredmeteUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (Predmet p in ListaPredmeta)
                    {
                        writer.WriteLine(p.ToFileString());
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
