using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
    public class ITSupport : Support
    {
        public ITSupport(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren,String ibanNummer, string functie = "IT Support", string typecontract = "Voltijds", double startloon = 2050.00, double tweedagenperweekextra = 50.0) : base(naam, geslacht, geboorteDatum, rijksRegisterNummer, indiensttreding, aantalGepresenteerdUren, ibanNummer, functie, typecontract, startloon, tweedagenperweekextra)
        {

        }
        public double afgetrokken;
        public override double Uurberekendstartloon()
        {
            double uurberekening;
            uurberekening = AantalGepresenteerdUren / 38 * Startloon;
            afgetrokken = uurberekening * 0.06;
            uurberekening -= afgetrokken;
            return Math.Round(uurberekening, 2);
        }
        public override double Ancienniteit()
        {
            double ancienniteit = Uurberekendstartloon();
            int aantaljaren = DateTime.Now.Year - Indiensttreding.Year;
            for (int i = 1; i <= aantaljaren; i++)
            {
                ancienniteit *= 1.01;
            }
            ancienniteit -= Uurberekendstartloon();
            ancienniteit += afgetrokken;
            return ancienniteit;
        }

        public override string Beschrijf()
        {
            return base.Beschrijf();

        }
    }
}