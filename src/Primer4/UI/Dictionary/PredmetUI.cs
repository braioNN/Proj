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
    class PredmetUI
    {
        /** ATRIBUTI KLASE ****/
        public static Dictionary<int, Predmet> RecnikPredmeta { get; set; }

        static PredmetUI()
        {
            RecnikPredmeta = new Dictionary<int, Predmet>();
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
                    case 6:
                        IspisiSvePredmete(SortirajPredmetePoNazivu());
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
            Console.WriteLine("\tOpcija broj 6 - sortiranje i ispis predmeta po nazivu");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS PREDMETA ****/
        // ispisi sve predmete
        public static void IspisiSvePredmete()
        {
            IspisiSvePredmete(RecnikPredmeta.Values.ToList<Predmet>());
        }

        public static void IspisiSvePredmete(IList<Predmet> lista)
        {
            foreach (Predmet pr in lista)
            {
                Console.WriteLine(pr);
            }
        }

        /** METODE ZA PRETRAGU PREDMETA ****/
        // pronadji predmet
        public static Predmet PronadjiPredmetPoId()
        {
            Predmet retVal = null;
            Console.WriteLine("Unesi id predmeta:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            try
            {
                retVal = PronadjiPredmetPoId(id);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Predmet sa id-om " + id + " ne postoji u evidenciji");
            }

            return retVal;
        }

        // pronadji predmet
        public static Predmet PronadjiPredmetPoId(int id)
        {
            try
            {
                return RecnikPredmeta[id];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Ne postoji vrednost u rečniku RecnikStudenata za dati ključ!");
                throw;
            }
        }

        /** METODA ZA SORTIRANJE PREDMETA****/
        public static IList<Predmet> SortirajPredmetePoNazivu()
        {
            //kako mapa studenata ne može da se sortira tako 
            //sve studente moramo prebaciti u listu čiji elementi mogu da se sortiraju
            List<Predmet> sortiraniPredmeti = new List<Predmet>(RecnikPredmeta.Values);
            Console.WriteLine("Studente je moguće sortirati po nazivu\n\t1 - Rastuće\n\t2 - Opadajuće\nIzaberi opciju:");
            int sortOpcija = IOPomocnaKlasa.OcitajCeoBroj();
            switch (sortOpcija)
            {
                case 1:
                    //TO DO
                    break;
                case 2:
                    //TO DO
                    break;
                default:
                    break;
            }
            return sortiraniPredmeti;
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
            RecnikPredmeta.Add(pred.Id, pred);

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
                RecnikPredmeta.Remove(pr.Id);
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
                        Predmet pr = new Predmet(linija);
                        RecnikPredmeta.Add(pr.Id, pr);
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
                    foreach (Predmet p in RecnikPredmeta.Values)
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
