using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer6
{
    class MainClass1
    {
        static void Main(string[] args)
        {
            int broj;
            int[] niz = new int[] {1,2,3};
            try
            {
                //1 
                //broj = Int32.Parse("tri");

                //2
                varb = ParsirajStringUInt("tri");

                //3 
                //KopirajObjekte(null);

                //4
                //CitajIzDatoteke();
                
                //5
                //PreuzmiVrednostIzNiza(niz, niz.Length);

                //6
                //PreuzmiVrednostIzNiza(null, niz.Length);

            }
            catch (FormatException e)
            {
                Console.WriteLine("GREŠKA: Nemoguće parsiranje teksta!");
                Console.WriteLine("\nPoruka: "+e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("GREŠKA: Nevalidni argumenti!");
                Console.WriteLine("Poruka: "+e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Tačan tip greške je: "+e.InnerException.GetType().Name);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Tip greške: " + e.GetType().Name);
                Console.WriteLine("GREŠKA: Datoteka ne postoji!");
                //Console.WriteLine("Poruka: "+e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Tip greške: " + e.GetType().Name);
                Console.WriteLine("GREŠKA: Direktorijum ne postoji!");
                //Console.WriteLine("Poruka: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Tip greške: " + e.GetType().Name);
                Console.WriteLine("GREŠKA: IO greška prilikom pokušaja čitanja/pisanja!");
                //Console.WriteLine("Poruka: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Tip greške: " + e.GetType().Name);
                Console.WriteLine("GREŠKA: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Blok koji se svakako izvršava!");
                Console.WriteLine("Koristi se za osobađanje resursa koji su zauzeti u try bloku!");
            }

            Console.ReadKey();
        }

        private static int ParsirajStringUInt(string str)
        {
            return Int32.Parse(str);
        }

        static Object KopirajObjekte(Object org)
        {
            Object kopija = null;
            if (org == null)
            {
                throw new ArgumentNullException("Parametar ne može biti null","org");
                //throw new ArgumentNullException();
            }
            //...kopiranje objekta
            return kopija;
        }

        static void CitajIzDatoteke()
        {
           using (StreamReader reader1 = File.OpenText("datoteka.txt")) // "direktorijum\\datoeka.txt"
            {
                string linija = "";
                while ((linija = reader1.ReadLine()) != null)
                {
                    Console.WriteLine(linija);
                }
            }
        }

        static int PreuzmiVrednostIzNiza(int[] niz, int indeks)
        {
            try
            {
                return niz[indeks];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("GREŠKA: Pristup lokaciji van niza!");
                throw new ArgumentException("Indeks mora biti u opsegu!","indeks",e);
            }
            catch (NullReferenceException e)
            {
                throw new ArgumentNullException("Niz ne sme biti null!", e);
                //ili uopšteni tip
                //throw new ArgumentException("Niz ne sme biti null!", "niz", e);
            }
        }
    }
}
