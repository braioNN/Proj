using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer4.Utils;

namespace Modul1Termin05.Primer1
{
    class MainClass2
    {
        static void Main()
        {
            double a = 88, b = 0;
            double rezultat = 0;
            bool greska = false;
            try
            {
                rezultat = SigurnoDeljenje1(a, b);
                Console.WriteLine(Double.IsInfinity(rezultat));
                Console.WriteLine("{0} / {1} = {2}", a, b, rezultat);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Pokušaj deljenja sa nulom!");
                greska = true;
            }
            finally
            {
                Console.WriteLine("Blok koji se svakako izvršava!");
                if (greska == true)
                {
                    if (!IOPomocnaKlasa.Potvrdi("nastaviti aplikaciju"))
                        Environment.Exit(1);
                }
            }
            Console.WriteLine("Nastavak aplikacije");
            //...
            Console.ReadKey();
        }

        static double SigurnoDeljenje1(double a, double b)
        {
            double rezultat = 0;
            try
            {
                rezultat = SigurnoDeljenje2(a, b);
            }
            catch (Exception e)
            {
                Console.WriteLine("Obrada greške tipa " + e.GetType().Name);
                //prosleđivanje izuzetka na "višu istancu"
                //throw;
            }
            return rezultat;
        }

        static double SigurnoDeljenje2(double a, double b)
        {
            double rezultat = 0;
            try
            {
                if (b == 0)
                {
                    //throw new DivideByZeroException();
                }
                rezultat = a / b;
            }
            catch (Exception e)
            {
                Console.WriteLine("Obrada greške tipa " + e.GetType().Name);
                //prosleđivanje izuzetka na "višu istancu"
                //throw;
            }


            return rezultat;
        }

        
    }
}
