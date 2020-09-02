using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
    public class ITSupport:Support
    {
        public ITSupport (string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, bool bedrijfswagen, string functie="IT Support", string typecontract = "Voltijds", double startloon = 2050.00, double tweedagenperweekextra = 50.0) : base(naam, geslacht, geboorteDatum, rijksRegisterNummer, indiensttreding, aantalGepresenteerdUren, bedrijfswagen, functie, typecontract, startloon, tweedagenperweekextra)
        {

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
            Startloon -= Startloon * .06;
            double ancienniteit = Startloon;
            aantaljaren = DateTime.Now.Year - Indiensttreding.Year;
            for (int i = 0; i < aantaljaren; i++)
            {
                ancienniteit *= 1.01;
            }
            ancienniteit += ancienniteit * .06;
            ancienniteit -= Startloon;
            return ancienniteit;
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
            return base.Beschrijf();
        }
    }
}
