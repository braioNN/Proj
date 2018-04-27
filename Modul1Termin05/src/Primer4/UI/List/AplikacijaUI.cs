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
    class AplikacijaUI
    {
        private static readonly string DataDir = "data";
        private static readonly string StudDat = "studenti.csv";
        private static readonly string PredDat = "predmeti.csv";
        private static readonly string PohDat = "pohadja.csv";
        private static char sep = Path.DirectorySeparatorChar;
        private static string putanjaDataDirRelease = "data";

        private static string PodesiPutanju(string[] args)
        {
            string trenutnaPutanja = Directory.GetCurrentDirectory();
            string putanja = "";

            switch (args.Length)
            {
                case 0:
                    goto default;
                case 1:
                    if (args[0] != "-r")
                    {
                        goto default;
                    }
                    putanja = putanjaDataDirRelease + sep;
                    break;
                case 2:                    
                    if (args[0] != "-r")
                    {
                        goto default;
                    }
                    putanjaDataDirRelease = args[1];
                    putanja = putanjaDataDirRelease + sep;
                    break;
                default:
                    string putanjaProjekta = new DirectoryInfo(trenutnaPutanja).Parent.Parent.FullName;
                    putanja = putanjaProjekta + sep + DataDir + sep;
                    break;
            }
                  

            return putanja;
        }

        private static void ProveraDatotekaIDirektorijuma(string putanjaDataDir)
        {
            if (!Directory.Exists(putanjaDataDir))
            {
                Console.WriteLine("Putanja nije ispravna ili ne postoji direktorijum " + putanjaDataDir);
            }
            else if (!File.Exists(putanjaDataDir + StudDat) || !File.Exists(putanjaDataDir + PredDat) || !File.Exists(putanjaDataDir + PohDat))
            {
                Console.WriteLine("Nedostaju datoteke!");
            }
            else
            {
                return;
            }
            Console.WriteLine("\nPritisnite bilo koji taster...");
            Console.ReadKey(true);
            Environment.Exit(1);
        }

        public static void IspisiOsnovneOpcije()
        {
            Console.WriteLine("Studentska Sluzba - Osnovne opcije:");
            Console.WriteLine("\tOpcija broj 1 - Rad sa studentima");
            Console.WriteLine("\tOpcija broj 2 - Rad sa predmetima");
            Console.WriteLine("\tOpcija broj 3 - Rad sa nastavnicima");
            Console.WriteLine("\tOpcija broj 4 - Rad sa ispitnim rokovima");
            Console.WriteLine("\tOpcija broj 5 - Rad sa pohađa");
            Console.WriteLine("\tOpcija broj 6 - Rad sa predaje");
            Console.WriteLine("\tOpcija broj 7 - Rad sa ispitnim prijavama");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - IZLAZ IZ PROGRAMA");
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string putanjaDataDir = PodesiPutanju(args);

            //provera da li postoji direktorijum sa potrebnim datotekama
            ProveraDatotekaIDirektorijuma(putanjaDataDir);

            StudentUI.UcitajStudenteIzDatoteke(putanjaDataDir + StudDat);

            PredmetUI.UcitajPredmeteIzDatoteke(putanjaDataDir + PredDat);

            PohadjaUI.UcitajPohadjanjaIzDatoteke(putanjaDataDir + PohDat);

            //IspitniRokUI.UcitajIspitneRokoveIzDatoteke(putanjaDataDir + IspRokDat);

            //IspitnaPrijavaUI.UcitajIspitnePrijaveIzDatoteke(putanjaDataDir + IspPrijDat);

            //treba proveriti trenuti max id kako se ne bi ponovio id
            AplikacijaUI.PodesiIdBrojace();

            int odluka = -1;
            while (odluka != 0)
            {
                AplikacijaUI.IspisiOsnovneOpcije();
                Console.WriteLine("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz iz programa");
                        break;
                    case 1:
                        StudentUI.MeniStudentUI();
                        break;
                    case 2:
                        PredmetUI.MeniPredmetUI();
                        break;
                    case 5:
                        PohadjaUI.MeniPohadjaUI();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }

            StudentUI.SacuvajStudenteUDatoteku(putanjaDataDir + StudDat);
            PredmetUI.SacuvajPredmeteUDatoteku(putanjaDataDir + PredDat);
            PohadjaUI.SacuvajPohadjanjaUDatoteku(putanjaDataDir + PohDat);
            //IspitniRokUI.SacuvajIspitneRokoveUDatoteku(putanjaDataDir + IspRokDat);
            //IspitnaPrijavaUI.SacuvajIspitnePrijaveUDatoteku(putanjaDataDir + IspPrijDat);
            Console.WriteLine("Pritisnite bilo koji taster...");
            Console.ReadKey(true);
        }

        private static void PodesiIdBrojace()
        {
            int max = -1;
            foreach (Student s in StudentUI.ListaStudenata)
            {
                if (s.Id > max)
                {
                    max = s.Id;
                }
            }
            StudentUI.ListaStudenata[0].BrojacId = ++max;
            max = -1;
            foreach (Predmet s in PredmetUI.ListaPredmeta)
            {
                if (s.Id > max)
                {
                    max = s.Id;
                }
            }
            PredmetUI.ListaPredmeta[0].BrojacId = ++max;
        }
    }
}
