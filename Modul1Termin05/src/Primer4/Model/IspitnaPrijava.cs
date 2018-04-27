using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin05.Primer4.Model;

namespace Modul1Termin05.Primer4
{
    class IspitnaPrijava
    {
        protected int Id { get; set; }
        protected Student Student { get; set; }
        protected Predmet Predmet { get; set; }
        protected IspitniRok IspitniRok { get; set; }
        protected int Teorija { get; set; }
        protected int Zadaci { get; set; }

        public IspitnaPrijava(Student st, Predmet pr, IspitniRok ir, int teorija, int zadaci)
        {
            this.Student = st;
            this.Predmet = pr;
            this.IspitniRok = ir;
            this.Teorija = teorija;
            this.Zadaci = zadaci;
        }

        public IspitnaPrijava(string tekst)
        {
            string[] tokeni = tekst.Split(',');

            //student, predmet, ispitni rok, teorija, zadaci
            //npr. 		1,1,1,88,89
            //tokeni 	0 1	2 3  4		

            //TO DO
        }

        //kraci naziv metode PreuzmiTekstualnuReprezentacijuKlaseZaDatoteku
        //implementirati isto ponašanje
        public string ToFileString()
        {
            //TO DO
            return "";
        }

        public int IzracunajOcenu()
        {
            double bodovi = IzracunajProsek();
            int ocena;
            if (bodovi >= 95)
                ocena = 10;
            else if (bodovi >= 85)
                ocena = 9;
            else if (bodovi >= 75)
                ocena = 8;
            else if (bodovi >= 65)
                ocena = 7;
            else if (bodovi >= 55)
                ocena = 6;
            else
                ocena = 5;

            return ocena;
        }

        public double IzracunajProsek()
        {
            int bodovi = Teorija + Zadaci;
            return bodovi / 2;
        }

        public override string ToString()
        {
            return "Ispitna prijava [id:" + Id + "]\nStudent: " + this.Student + "\nPredmet: "
                    + this.Predmet + "\nRok: " + IspitniRok + "\nBodovi iz teorije: " + Teorija
                    + "\nBodovi iz zadataka: " + Zadaci;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IspitnaPrijava))
                return false;
            
            IspitnaPrijava ip = (IspitnaPrijava)obj;
            if (ip.IspitniRok == null || ip.Student == null || ip.Predmet == null)
                return false;

            if (ip.Id != this.Id || !ip.IspitniRok.Equals(this.IspitniRok))
                return false;
            
            return this.Student.Equals(ip.Student) && this.Predmet.Equals(ip.Predmet);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Student.GetHashCode() ^ Predmet.GetHashCode() ^ IspitniRok.GetHashCode();
        }
        
    }
}
