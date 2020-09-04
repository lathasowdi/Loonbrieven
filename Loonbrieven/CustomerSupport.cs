using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
   public class CustomerSupport:Support
    {
       
       public CustomerSupport( string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, string ibanNummer, string functie="CustomerSupport", string typecontract = "Voltijds", double startloon = 2050.00, double tweedagenperweekextra = 69.50) : base(naam, geslacht, geboorteDatum, rijksRegisterNummer, indiensttreding,aantalGepresenteerdUren, ibanNummer, functie,typecontract, startloon, tweedagenperweekextra)
        {
            

        }
        public override double Netto()
        {
            return base.Netto() + 19.50;
        }
        public override string Loonbrieven()
        {
            return base.Loonbrieven() + "\n" + "Extra €50 added" + "\n" + "to Netto voor Tweedagenperweekextrathuis"
                + "\n" + "Terug betaald OpledingKost €19.50";
        }
    }
}
