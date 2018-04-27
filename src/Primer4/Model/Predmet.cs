using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer4.Model
{
    class Predmet
    {
        private static int brojacId = 0;

        internal int BrojacId
        {
            get { return brojacId; }
            set { brojacId = value; }
        }
        internal int Id { get; set; }
        public string Oznaka { get; set; }
        internal string Naziv { get; set; }
        //studenti koje pohađaju predmet
        private List<Student> studenti = new List<Student>();

        public List<Student> Studenti
        {
            get { return studenti; }
            set { studenti = value; }
        }

        //konstruktori
        // konstruktor bez parametra
        public Predmet()
        {
            //Studenti = new List<Student>();
        }

        //konstruktor sa vise parametara
        public Predmet(string naziv, string oznaka, int id=-1) : this()
        {
            if (id == -1)
            {
                id = brojacId++;
            }
            this.Id = id;
            this.Oznaka = oznaka;
            this.Naziv = naziv;
        }

        public Predmet(string naziv, string oznaka, List<Student> studenti, int id = -1) : this(naziv, oznaka, id) 
        {
            this.Studenti = studenti;
        }

        //konstruktor koji popunjava podatke na osnovu očitanog teksta iz fajla predmet.csv
        public Predmet(string tekst) : this()
        {
            string[] tokeni = tekst.Split(',');
            //npr. 		1,M01E2,Matematika
            //tokeni 	0	1   2	 

            if (tokeni.Length != 3)
            {
                Console.WriteLine("Greska pri ocitavanju predmeta " + tekst);
                //izlazak iz aplikacije
                Environment.Exit(0);
            }

            Id = Int32.Parse(tokeni[0]);
            Oznaka = tokeni[1];
            Naziv = tokeni[2];
        }

        //metode

        //metoda koja kreira tekstualnu reprezentaciju klase za datoteku
        //kraci naziv metode PreuzmiTekstualnuReprezentacijuKlaseZaDatoteku
        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id + "," + Oznaka + "," + Naziv);
            return sb.ToString();
        }

        public override string ToString()
        {
            return "Predmet [id:" + Id + "] " + Oznaka + " " + Naziv;
        }

        public string ToStringAll()
        {
            StringBuilder sb = new StringBuilder("Predmet [id:" + Id + "] " + Oznaka + " " + Naziv + "\n");

            if (Studenti.Count > 0)
            {
                sb.AppendLine("Pohađaju sledeći studenti: ");
                for (int i = 0; i < Studenti.Count; i++)
                {
                    sb.AppendLine("\t" + Studenti[i] + "\n");
                }
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Predmet))
                return false;
            Predmet p = (Predmet)obj;
            return this.Id == p.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Naziv.GetHashCode();
        }



    }
}
