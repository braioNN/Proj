using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer4.Model
{
    //klasa
    class Student
    {
        //atributi tj property-i
        private static int brojacId = 0;

        internal int BrojacId
        {
            get { return brojacId; }
            set { brojacId = value; }
        }

        internal int Id { get; set; }
        internal string Ime { get; set; }
        internal string Prezime { get; set; }
        internal string Grad { get; set; }
        internal string Indeks { get; set; }

        //predmete koje pohađa student
        private List<Predmet> predmeti = new List<Predmet>();

        public List<Predmet> Predmeti
        {
            get { return predmeti; }
            set { predmeti = value; }
        }
        
        //sve ispitne prijave za studenta
        private List<IspitnaPrijava> ispitnePrijave = new List<IspitnaPrijava>();

        public List<IspitnaPrijava> IspitnePrijave
        {
            get { return ispitnePrijave; }
            set { ispitnePrijave = value; }
        }


        //konstruktori

        // konstruktor bez parametra
        public Student()
        {
            //Predmeti = new List<Predmet>();
            //IspitnePrijave = new List<IspitnaPrijava>();
        }

        //konstruktor sa vise parametara
        public Student(string ime, string prezime, string grad, string indeks, int id=-1) : this()
        {
            if (id == -1)
            {
                id = brojacId++;
            }
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Grad = grad;
            this.Indeks = indeks;
        }

        public Student(string ime, string prezime, string grad, string indeks, List<Predmet> predmeti, int id=-1) : this(ime,prezime,grad,indeks,id)
        {
            this.Predmeti = predmeti;
        }

        //konstruktor koji popunjava podatke na osnovu očitanog teksta iz datoteke studenata
        public Student(string tekst)
        {
            string[] tokeni = tekst.Split(',');
            //npr. 		1,E2 01/2016,Jevrić,Srđan,Loznica
            //tokeni 	0		1		2		3			4

            if (tokeni.Length != 5)
            {
                Console.WriteLine("Greska pri ocitavanju studenta " + tekst);
                //izlazak iz aplikacije
                Environment.Exit(0);
            }

            Id = Int32.Parse(tokeni[0]);
            Indeks = tokeni[1];
            Prezime = tokeni[2];
            Ime = tokeni[3];
            Grad = tokeni[4];
        }

        //metode

        //metoda koja kreira tekstualnu reprezentaciju klase za datoteku
        //kraci naziv metode PreuzmiTekstualnuReprezentacijuKlaseZaDatoteku
        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id + "," + Indeks + "," + Prezime + "," + Ime + "," + Grad);
            return sb.ToString();
        }

        public override string ToString()
        {
            return "Student [id:" + Id + "] " + Ime + " " + Prezime + " " + Indeks + ", " + Grad;
        }

        public string ToStringAll()
        {
            StringBuilder sb = new StringBuilder("Student [id:" + Id + "] " + Ime + " " + Prezime + " " + Indeks + ", " + Grad+"\n");

            if (Predmeti.Count > 0)
            {
                sb.AppendLine("Pohađa predmete:");
                for (int i = 0; i < Predmeti.Count; i++)
                {
                    sb.AppendLine("\t" + Predmeti[i]);
                }
            }

            if (IspitnePrijave.Count > 0)
            {
                sb.Append("Ima sledeće ispitne prijave:");
                for (int i = 0; i < IspitnePrijave.Count; i++)
                {
                    sb.AppendLine("\t" + IspitnePrijave[i]);
                }
            }
            return sb.ToString();
        }

        public double IzracunajProsek()
        {
            double retVal = 0;
            int brojacPolozenihPredmeta = 0;
            foreach (IspitnaPrijava ip in IspitnePrijave)
            {
                if (ip.IzracunajOcenu() > 5)
                {
                    retVal += ip.IzracunajOcenu();
                    brojacPolozenihPredmeta++;
                }

            }
            return retVal / brojacPolozenihPredmeta;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student))
                return false;
            Student s = (Student)obj;
            return this.Id == s.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Ime.GetHashCode() ^ Prezime.GetHashCode();
        }

    }
}
