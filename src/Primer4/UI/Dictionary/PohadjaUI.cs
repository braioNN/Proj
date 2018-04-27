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
    class PohadjaUI
    {
        private static void IspisiMeni()
        {
            Console.WriteLine("Rad sa predmetima studenta - opcije:");
            Console.WriteLine("\tOpcija broj 1 - predmeti koje student pohadja");
            Console.WriteLine("\tOpcija broj 2 - studenti koji pohadjaju predmet");
            Console.WriteLine("\tOpcija broj 3 - dodavanje studenta na predmet");
            Console.WriteLine("\tOpcija broj 4 - uklanjanje studenta sa predmeta");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        public static void MeniPohadjaUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiMeni();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        IspisiPredmeteZaStudenta();
                        break;
                    case 2:
                        IspisiStudenteZaPredmet();
                        break;
                    case 3:
                        DodajStudentaNaPredmet();
                        break;
                    case 4:
                        UkloniStudentaSaPredmeta();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }

        public static void IspisiPredmeteZaStudenta()
        {
            // najpre pronadjemo studenta za kojeg zelimo ispis predmeta
            Student student = StudentUI.PronadjiStudentaPoIndeksu();
            if (student != null)
            {
                List<Predmet> predmeti = student.Predmeti;

                foreach (Predmet p in predmeti)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public static void IspisiStudenteZaPredmet()
        {
            // najpre pronadjemo predmet za koji zelimo ispis studenata
            Predmet predmet = PredmetUI.PronadjiPredmetPoId();
            if (predmet != null)
            {
                List<Student> studenti = predmet.Studenti;

                foreach (Student s in studenti)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public static void DodajStudentaNaPredmet()
        {
            // najpre pronadjemo studenta kojeg zelimo da dodamo na predmet
            Student student = StudentUI.PronadjiStudentaPoIndeksu();

            if (student != null)
            {
                //pronadjemo predmet na koji zelimo da dodamo studenta
                Predmet predmet = PredmetUI.PronadjiPredmetPoId();
                if (predmet != null)
                {
                    DodajStudentaNaPredmet(student, predmet);
                }
            }
        }

        public static void DodajStudentaNaPredmet(Student student)
        {
            //pronadjemo predmet na koji zelimo da dodamo studenta
            Predmet predmet = PredmetUI.PronadjiPredmetPoId();

            DodajStudentaNaPredmet(student, predmet);
        }

        public static void DodajStudentaNaPredmet(Predmet predmet)
        {
            // najpre pronadjemo studenta kojeg zelimo da dodamo na predmet
            Student student = StudentUI.PronadjiStudentaPoIndeksu();

            DodajStudentaNaPredmet(student, predmet);
        }

        public static void DodajStudentaNaPredmet(Student student, Predmet predmet)
        {
            if (student != null && predmet != null)
            {
                //uspostavimo vezu izmedju studenta i predmeta
                List<Predmet> predmeti = student.Predmeti;
                bool found = false;
                for (int i = 0; i < predmeti.Count; i++)
                {
                    if (predmet.Equals(predmeti[i]))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    student.Predmeti.Add(predmet);
                    predmet.Studenti.Add(student);
                }
            }
        }
        public static void UkloniPredmetIzStudenata(Predmet pr)
        {
            foreach (KeyValuePair<int, Student> kvp in StudentUI.RecnikStudenata)
            {
                if (kvp.Value.Predmeti.Contains(pr))
                {
                    kvp.Value.Predmeti.Remove(pr);
                }
            }
        }

        public static void UkloniStudentaIzPredmeta(Student st)
        {
            foreach (KeyValuePair<int, Predmet> kvp in PredmetUI.RecnikPredmeta)
            {
                if (kvp.Value.Studenti.Contains(st))
                {
                    kvp.Value.Studenti.Remove(st);
                }
            }
        }

        public static void UkloniStudentaSaPredmeta()
        {
            // najpre pronadjemo studenta kojeg zelimo da dodamo na predmet
            Student student = StudentUI.PronadjiStudentaPoIndeksu();

            if (student != null)
            {
                //pronadjemo predmet na koji zelimo da dodamo studenta
                Predmet predmet = PredmetUI.PronadjiPredmetPoId();
                if (predmet != null)
                {
                    UkloniStudentaSaPredmeta(student, predmet);
                }
            }   
        }

        public static void UkloniStudentaSaPredmeta(Student student)
        {
            //pronadjemo predmet sa kojeg zelimo da ukloniko studenta
            Predmet predmet = PredmetUI.PronadjiPredmetPoId();

            UkloniStudentaSaPredmeta(student, predmet);
        }

        public static void UkloniStudentaSaPredmeta(Predmet predmet)
        {
            // najpre pronadjemo studenta kojeg zelimo da uklonimo sa predmeta
            Student student = StudentUI.PronadjiStudentaPoIndeksu();

            UkloniStudentaSaPredmeta(student, predmet);
        }

        public static void UkloniStudentaSaPredmeta(Student student, Predmet predmet)
        {
            if (student != null && predmet != null)
            {
                //brisemo vezu izmedju studenta i predmeta u studentu
                List<Predmet> predmeti = student.Predmeti;
                bool found = false;
                for (int i = 0; i < predmeti.Count; i++)
                {
                    if (predmet.Equals(predmeti[i]))
                    {
                        found = true;
                        predmeti.RemoveAt(i);
                        break;
                    }
                }
                if (found)
                {
                    //brisemo vezu izmedju studenta i predmeta u predmetu
                    List<Student> studenti = predmet.Studenti;
                    for (int i = 0; i < studenti.Count; i++)
                    {
                        if (student.Equals(studenti[i]))
                        {
                            studenti.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }
        /** METODA ZA UCITAVANJE PODATAKA****/
        public static void UcitajPohadjanjaIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader reader1 = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = reader1.ReadLine()) != null)
                    {
                        string[] pohadjanja = linija.Split(',');
                        int idStudenta = Int32.Parse(pohadjanja[0]);
                        int idPredmeta = Int32.Parse(pohadjanja[1]);
                        Student st = StudentUI.PronadjiStudentaPoId(idStudenta);
                        Predmet pr = PredmetUI.PronadjiPredmetPoId(idPredmeta);
                        if (st != null && pr != null)
                        {
                            st.Predmeti.Add(pr);
                            pr.Studenti.Add(st);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static void SacuvajPohadjanjaUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (Student st in StudentUI.RecnikStudenata.Values)
                    {
                        foreach (Predmet pr in st.Predmeti)
                        {
                            writer.WriteLine(st.Id + "," + pr.Id);
                        }
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
