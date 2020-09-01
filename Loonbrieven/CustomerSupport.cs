using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
   public class CustomerSupport:Support
    {
       
       public CustomerSupport( string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, bool bedrijfswagen, string functie="CustomerSupport", string typecontract = "Voltijds", double startloon = 2050.00, double tweedagenperweekextra = 69.50) : base(naam, geslacht, geboorteDatum, rijksRegisterNummer, indiensttreding,aantalGepresenteerdUren,bedrijfswagen, functie,typecontract, startloon, tweedagenperweekextra)
        {
            

        }
        public override string Beschrijf()
        {
            return base.Beschrijf();
        }
        public override string Loonbrieven()
        {
            return base.Loonbrieven();
        }
    }
}
