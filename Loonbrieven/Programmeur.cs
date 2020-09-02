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
        public Programmeur(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, bool bedrijfswagen,bool bedrijfWagen ,string functie="Programmeur", string typecontract = "Voltijds", double startloon = 2200.00, double socialeZekerheid = 200, double bedrijfsVoorheffing = 13.68) : base(naam, geslacht,geboorteDatum, rijksRegisterNummer, indiensttreding, aantalGepresenteerdUren, bedrijfswagen,functie, typecontract,startloon,socialeZekerheid, bedrijfsVoorheffing)
        {
            
            BedrijfWagen = bedrijfWagen;

        }
        public override double Uurberekening()
        {
            double uurberekening;
            uurberekening = AantalGepresenteerdUren / 38 * Startloon;
            return Math.Round(uurberekening, 2);
        }
        public override double Ancienniteit()
        {
            int aantaljaren = 0;
            double ancienniteit = Uurberekening();
            aantaljaren = DateTime.Now.Year - Indiensttreding.Year;

            for (int i = 0; i < aantaljaren; i++)
            {
                ancienniteit *= 1.01;
            }
            ancienniteit -= Startloon;
            return Math.Round(ancienniteit, 2);
        }
        public override double NaSocialeZekerheid()
        {
            double Nasociale = Uurberekening() + Ancienniteit();
            Nasociale -= 200;
            return Math.Round(Nasociale, 2);
        }
        public override double Netto()
        {
            double netto = NaSocialeZekerheid();
            netto -= (netto * 0.1368);
            return Math.Round(netto, 2);
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
    }
}
