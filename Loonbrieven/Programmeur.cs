using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
   public class Programmeur:Werknemer
    {
        public bool BedrijfWagen;
        public Programmeur(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, string  ibanNummer, bool bedrijfWagen ,string functie="Programmeur", string typecontract = "Voltijds", double startloon = 2200.00, double socialeZekerheid = 200, double bedrijfsVoorheffing = 13.68) : base(naam, geslacht,geboorteDatum, rijksRegisterNummer, indiensttreding, aantalGepresenteerdUren, ibanNummer, functie, typecontract,startloon,socialeZekerheid, bedrijfsVoorheffing)
        {
            
            BedrijfWagen = bedrijfWagen;

        }
        
        public override string Beschrijf()
        {
            return base.Beschrijf() + $"BEDRIJFSWAGEN: {(BedrijfWagen ? "Ja" : "Nee")}";
        }
        public override string Loonbrieven()
        {
            BedrijfsVoorheffing = (BedrijfWagen == true ? 17.30 : 13.68);
            return base.Loonbrieven();
        }
        public override double Bedrijfsvoorheffing()
        {
            if (BedrijfWagen)
            {
                return NaSocialeZekerheid() * 0.173;
            }
            return base.Bedrijfsvoorheffing();
        }
    }
}
