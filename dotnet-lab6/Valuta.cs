using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab6
{
    public interface IIspis
    {
        string Ispis(); 
    }

    class Valuta : IComparable<Valuta>, IIspis
    {
        public string Naziv { set; get; }
        public double Tecaj { set; get; }

        public Valuta(string naziv, double tecaj) {
            Naziv = naziv;
            Tecaj = tecaj;
        }

        public int CompareTo(Valuta obj) {
            if (obj == null) return 1;

            return this.Tecaj.CompareTo(obj.Tecaj);

        }

        public string Ispis()
        {
            return "Naziv valute: " + Naziv + ", tečaj prema USD je " + Tecaj + "!";
        }

    }
}
                                         