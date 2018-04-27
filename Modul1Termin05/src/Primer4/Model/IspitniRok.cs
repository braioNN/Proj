using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer4
{
    class IspitniRok
    {
        protected int Id { get; set; }
        protected string Naziv { get; set; }
        protected string Pocetak { get; set; }
        protected string Kraj { get; set; }
        //ispitne prijave u isputnom roku
        protected List<IspitnaPrijava> ispitnePrijave = new List<IspitnaPrijava>();

        public IspitniRok(int id, string naziv, string pocetak, string kraj)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
        }

        public IspitniRok(string tekst)
        {
            string[] tokeni = tekst.Split(',');
            //npr. 		1,Januarski,2015-01-15,2015-01-29
            //tokeni 	0		1		2		3		

            //TO DO

        }

        //metode

        //kraci naziv metode PreuzmiTekstualnuReprezentacijuKlaseZaDatoteku
        //implementirati isto ponašanje
        public string ToFileString()
        {
            //TO DO
            return "";
        }

        public override string ToString()
        {
            return "Ispitni " + Naziv + " rok [id:" + Id + "] traje od " + Pocetak + " do " + Kraj;
        }

        //ispisati sve podatke sa ispitnim prijavama
        //po ugledu na metodu u klasi Predmet
        public string ToStringAll()
        {
            //TO DO
            return "";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IspitniRok))
                return false;

            IspitniRok ir = (IspitniRok)obj;

            return this.Id.Equals(ir.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Naziv.GetHashCode();
        }
    }
}
